# 🚀 BackInovationMap - API REST para Gestión de Innovación

Una API REST robusta desarrollada en .NET 9 para la gestión de empresas, convocatorias y usuarios en plataformas de innovación.

## 📋 Características Principales

- **🏢 Gestión de Empresas**: CRUD completo para empresas innovadoras
- **📢 Gestión de Convocatorias**: Sistema completo de convocatorias con estados automáticos
- **🔐 Autenticación JWT**: Sistema de autenticación seguro con tokens JWT
- **📊 Base de Datos**: PostgreSQL con Entity Framework Core
- **📚 Documentación**: Swagger/OpenAPI integrado
- **🛡️ Seguridad**: Validación de datos y manejo de errores
- **🌐 CORS**: Configurado para integraciones frontend

## 🛠️ Stack Tecnológico

- **.NET 9**: Framework principal
- **ASP.NET Core**: API REST
- **Entity Framework Core**: ORM
- **PostgreSQL**: Base de datos
- **JWT**: Autenticación
- **BCrypt**: Hasheo de contraseñas
- **Swagger**: Documentación de API
- **Npgsql**: Driver PostgreSQL

## 🏗️ Arquitectura

```
BackInovationMap/
├── Controllers/         # Controladores de API
│   ├── AuthController.cs
│   ├── CompaniesController.cs
│   └── ConvocatoriasController.cs
├── Data/               # Contexto de base de datos
│   └── AppDbContext.cs
├── DTOs/               # Objetos de transferencia de datos
│   ├── AuthDto.cs
│   └── ConvocatoriaDto.cs
├── Models/             # Modelos de datos
│   ├── Company.cs
│   ├── Convocatoria.cs
│   └── Usuario.cs
├── Services/           # Servicios de negocio
│   └── JwtService.cs
├── Migrations/         # Migraciones de base de datos
└── Program.cs          # Configuración principal
```

## 🚀 Instalación y Configuración

### Prerrequisitos

- .NET 9 SDK
- PostgreSQL 12+
- Editor de código (Visual Studio, VS Code, etc.)

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/BackInovationMap.git
cd BackInovationMap
```

### 2. Configurar Variables de Entorno

1. **Crear archivo .env** en la raíz del proyecto:

```bash
# Variables de entorno para BackInovationMap
TU_PASSWORD=tu_password_real_de_supabase
```

2. **Establecer variable de entorno** en PowerShell:

```powershell
# Establecer la variable de entorno
$env:TU_PASSWORD = "tu_password_real_de_supabase"

# Verificar que se estableció
echo $env:TU_PASSWORD
```

3. **Verificar configuración** en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "postgresql://postgres.jsddkeyspzigizepdvoy:${TU_PASSWORD}@aws-0-us-east-2.pooler.supabase.com:5432/postgres"
  },
  "JwtSettings": {
    "SecretKey": "BackInovationMap_SuperSecret_Key_2025_MinLength32Characters!",
    "Issuer": "BackInovationMap",
    "Audience": "BackInovationMap",
    "ExpirationHours": "24"
  }
}
```

> **Nota:** El programa automáticamente reemplaza `${TU_PASSWORD}` con el valor de la variable de entorno.

### 3. Configurar Base de Datos (Alternativo Local)

Si prefieres usar PostgreSQL local, edita `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=innovation_map;Username=tu_usuario;Password=tu_password"
  }
}
```

### 4. Restaurar Dependencias

```bash
dotnet restore
```

### 5. Ejecutar Migraciones

```bash
dotnet ef database update
```

### 6. Ejecutar la Aplicación

```bash
# 1. Establecer la variable de entorno (importante!)
$env:TU_PASSWORD = "tu_password_real_de_supabase"

# 2. Verificar que se estableció
echo $env:TU_PASSWORD

# 3. Ejecutar la aplicación
dotnet run
```

La API estará disponible en `http://localhost:5297`

## 📖 Documentación de la API

### Swagger UI

Una vez que la aplicación esté ejecutándose, puedes acceder a la documentación interactiva en:

```
http://localhost:5297/swagger
```

### Endpoints Principales

#### 🔐 Autenticación (`/api/auth`)

| Método | Endpoint           | Descripción               |
| ------ | ------------------ | ------------------------- |
| POST   | `/register`        | Registrar nuevo usuario   |
| POST   | `/login`           | Iniciar sesión            |
| GET    | `/profile`         | Obtener perfil de usuario |
| PUT    | `/change-password` | Cambiar contraseña        |
| POST   | `/refresh-token`   | Refrescar token JWT       |
| GET    | `/validate`        | Validar token             |

#### 🏢 Empresas (`/api/companies`)

| Método | Endpoint | Descripción                |
| ------ | -------- | -------------------------- |
| GET    | `/`      | Obtener todas las empresas |
| GET    | `/{id}`  | Obtener empresa por ID     |
| POST   | `/`      | Crear nueva empresa        |
| PUT    | `/{id}`  | Actualizar empresa         |
| DELETE | `/{id}`  | Eliminar empresa           |

#### 📢 Convocatorias (`/api/convocatorias`)

| Método | Endpoint                 | Descripción                     |
| ------ | ------------------------ | ------------------------------- |
| GET    | `/`                      | Obtener todas las convocatorias |
| GET    | `/{id}`                  | Obtener convocatoria por ID     |
| POST   | `/`                      | Crear nueva convocatoria        |
| PUT    | `/{id}`                  | Actualizar convocatoria         |
| DELETE | `/{id}`                  | Eliminar convocatoria           |
| GET    | `/activas`               | Obtener convocatorias activas   |
| GET    | `/categoria/{categoria}` | Buscar por categoría            |
| GET    | `/estado/{estado}`       | Buscar por estado               |
| PUT    | `/{id}/estado`           | Actualizar solo estado          |

### Autenticación JWT

Para acceder a endpoints protegidos, incluye el token en el header:

```
Authorization: Bearer tu_jwt_token_aqui
```

### Ejemplo de Uso

#### Registrar Usuario

```bash
curl -X POST "http://localhost:5297/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Juan",
    "apellido": "Pérez",
    "email": "juan@ejemplo.com",
    "password": "MiPassword123!",
    "confirmPassword": "MiPassword123!"
  }'
```

#### Crear Convocatoria

```bash
curl -X POST "http://localhost:5297/api/convocatorias" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer tu_token" \
  -d '{
    "titulo": "Convocatoria de Innovación Tecnológica",
    "descripcion": "Programa para startups tecnológicas",
    "fechaInicio": "2024-01-15T00:00:00Z",
    "fechaFin": "2024-12-31T23:59:59Z",
    "categoria": "tecnología",
    "entidad": "Ministerio de Ciencia",
    "presupuesto": 100000,
    "requisitos": ["Empresa constituida", "Proyecto innovador"]
  }'
```

## 🔧 Configuración Avanzada

### Variables de Entorno

Puedes configurar las siguientes variables de entorno:

- `ASPNETCORE_ENVIRONMENT`: Entorno de ejecución (Development, Production)
- `ConnectionStrings__DefaultConnection`: Cadena de conexión a la base de datos
- `Jwt__Key`: Clave secreta para JWT
- `Jwt__ExpiryMinutes`: Tiempo de expiración del token

### CORS

El proyecto incluye configuración CORS para permitir requests desde cualquier origen en desarrollo. Para producción, configura orígenes específicos en `Program.cs`.

### Logging

El sistema incluye logging integrado. Los logs se muestran en consola en desarrollo.

## 🗄️ Base de Datos

### Modelo de Datos

#### Usuario

- ID, Nombre, Apellido, Email
- Password (hasheado con BCrypt)
- Rol, Organización, Teléfono
- Fechas de creación y último login

#### Empresa

- ID, Nombre, Descripción, Sector
- URL, Logo, Departamento
- Fecha de creación

#### Convocatoria

- ID, Título, Descripción
- Fechas de inicio y fin
- Categoría, Entidad, Presupuesto
- Estado (activa/cerrada/pendiente)
- Requisitos (lista de strings)
- Fechas de creación y actualización

### Migraciones

Para crear nuevas migraciones:

```bash
dotnet ef migrations add NombreMigracion
dotnet ef database update
```

## 🧪 Testing

### Endpoints de Prueba

La API incluye endpoints de prueba para verificar el funcionamiento:

```bash
# Verificar estado de la API
curl http://localhost:5297/api/auth/test

# Obtener todas las convocatorias
curl http://localhost:5297/api/convocatorias
```

### Datos de Prueba

Para crear datos de prueba, puedes usar los endpoints POST con datos ficticios o crear un seeder personalizado.

## 🔒 Seguridad

### Buenas Prácticas Implementadas

- **Hasheo de Contraseñas**: BCrypt con salt automático
- **JWT Seguro**: Tokens con expiración y claves robustas
- **Validación de Datos**: Validaciones en DTOs y modelos
- **Manejo de Errores**: Responses consistentes y sin información sensible
- **CORS Configurado**: Protección contra requests no autorizados

### Recomendaciones de Seguridad

1. **Claves Secretas**: Usa claves largas y complejas para JWT
2. **HTTPS**: Siempre usa HTTPS en producción
3. **Variables de Entorno**: No hardcodees credenciales
4. **Rate Limiting**: Implementa límites de requests por IP
5. **Validation**: Siempre valida datos de entrada

## 🚀 Deployment

### Desarrollo

```bash
dotnet run --environment Development
```

### Producción

```bash
dotnet publish -c Release -o ./publish
dotnet ./publish/BackInovationMap.dll
```

### Docker (Opcional)

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY ./publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "BackInovationMap.dll"]
```

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 📞 Contacto

- **Desarrollador**: Tu Nombre
- **Email**: tu.email@ejemplo.com
- **GitHub**: [@tu-usuario](https://github.com/tu-usuario)
- **LinkedIn**: [Tu Perfil](https://linkedin.com/in/tu-perfil)

## 🙏 Agradecimientos

- Comunidad .NET por las excelentes herramientas
- Entity Framework Core por el ORM robusto
- PostgreSQL por la base de datos confiable
- Swagger por la documentación automática

---

⭐ **¡No olvides darle una estrella al proyecto si te fue útil!** ⭐
#   B a c k I n o v a t i o n M a p  
 