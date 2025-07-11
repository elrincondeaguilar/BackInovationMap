using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using BCrypt.Net;
using BackInovationMap.Data;
using BackInovationMap.Models;
using BackInovationMap.DTOs;
using BackInovationMap.Services;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthController(AppDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<object>.ErrorResult("Datos de registro inválidos", errors));
            }

            // Verificar si el email ya existe
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());

            if (existingUser != null)
            {
                return BadRequest(ApiResponse<object>.ErrorResult("El email ya está registrado"));
            }

            // Crear nuevo usuario
            var usuario = new Usuario
            {
                Nombre = request.Nombre.Trim(),
                Apellido = request.Apellido.Trim(),
                Email = request.Email.Trim().ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Telefono = request.Telefono?.Trim(),
                Organizacion = request.Organizacion?.Trim(),
                Rol = "user",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Generar token
            var token = _jwtService.GenerateToken(usuario);
            var expiration = DateTime.UtcNow.AddHours(24);

            // Actualizar último login
            usuario.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var response = new AuthResponse
            {
                Token = token,
                Expiration = expiration,
                Usuario = MapToUsuarioResponse(usuario)
            };

            return CreatedAtAction(nameof(GetProfile), null, response);
        }

        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<object>.ErrorResult("Datos de login inválidos", errors));
            }

            // Buscar usuario por email
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());

            if (usuario == null)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Credenciales inválidas"));
            }

            // Verificar contraseña
            if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Credenciales inválidas"));
            }

            // Verificar si el usuario está activo
            if (!usuario.IsActive)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Cuenta deshabilitada. Contacte al administrador"));
            }

            // Generar token
            var token = _jwtService.GenerateToken(usuario);
            var expiration = DateTime.UtcNow.AddHours(24);

            // Actualizar último login
            usuario.LastLoginAt = DateTime.UtcNow;
            usuario.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var response = new AuthResponse
            {
                Token = token,
                Expiration = expiration,
                Usuario = MapToUsuarioResponse(usuario)
            };

            return Ok(response);
        }

        [HttpGet("profile")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Token inválido"));
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null || !usuario.IsActive)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Usuario no encontrado o inactivo"));
            }

            return Ok(ApiResponse<UsuarioResponse>.SuccessResult(MapToUsuarioResponse(usuario)));
        }

        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetMe()
        {
            // Alias para GetProfile - algunos frontends usan /me en lugar de /profile
            return await GetProfile();
        }

        [HttpPut("profile")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<object>.ErrorResult("Datos inválidos", errors));
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Token inválido"));
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null || !usuario.IsActive)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Usuario no encontrado o inactivo"));
            }

            // Actualizar datos
            usuario.Nombre = request.Nombre.Trim();
            usuario.Apellido = request.Apellido.Trim();
            usuario.Telefono = request.Telefono?.Trim();
            usuario.Organizacion = request.Organizacion?.Trim();
            usuario.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(ApiResponse<UsuarioResponse>.SuccessResult(MapToUsuarioResponse(usuario), "Perfil actualizado exitosamente"));
        }

        [HttpPost("change-password")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<object>.ErrorResult("Datos inválidos", errors));
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Token inválido"));
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null || !usuario.IsActive)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Usuario no encontrado o inactivo"));
            }

            // Verificar contraseña actual
            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, usuario.PasswordHash))
            {
                return BadRequest(ApiResponse<object>.ErrorResult("La contraseña actual es incorrecta"));
            }

            // Actualizar contraseña
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            usuario.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(ApiResponse<string>.SuccessResult("OK", "Contraseña actualizada exitosamente"));
        }

        [HttpPost("refresh-token")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> RefreshToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Token inválido"));
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null || !usuario.IsActive)
            {
                return Unauthorized(ApiResponse<object>.ErrorResult("Usuario no encontrado o inactivo"));
            }

            // Generar nuevo token
            var token = _jwtService.GenerateToken(usuario);
            var expiration = DateTime.UtcNow.AddHours(24);

            var response = new AuthResponse
            {
                Token = token,
                Expiration = expiration,
                Usuario = MapToUsuarioResponse(usuario)
            };

            return Ok(response);
        }

        [HttpGet("validate")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> ValidateToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized(new { valid = false, message = "Token inválido" });
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null || !usuario.IsActive)
            {
                return Unauthorized(new { valid = false, message = "Usuario no encontrado o inactivo" });
            }

            return Ok(new
            {
                valid = true,
                user = MapToUsuarioResponse(usuario),
                message = "Token válido"
            });
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Direct response", timestamp = DateTime.Now });
        }

        [HttpGet("test-wrapped")]
        public IActionResult TestWrapped()
        {
            return Ok(ApiResponse<object>.SuccessResult(new { message = "Wrapped response", timestamp = DateTime.Now }, "Success"));
        }

        // Método helper para mapear entidad a DTO
        private UsuarioResponse MapToUsuarioResponse(Usuario usuario)
        {
            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Rol = usuario.Rol,
                IsActive = usuario.IsActive,
                CreatedAt = usuario.CreatedAt,
                LastLoginAt = usuario.LastLoginAt,
                Telefono = usuario.Telefono,
                Organizacion = usuario.Organizacion
            };
        }
    }
}
