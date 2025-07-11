# 🚀 BackInovationMap - API REST para Gestión de Innovación

Una API REST robusta desarrollada en .NET 9 para la gestión de empresas, convocatorias y usuarios en plataformas de innovación. **Conectada a Supabase PostgreSQL** para máximo rendimiento y escalabilidad.

## ⭐ Características Principales

- **🏢 Gestión de Empresas**: CRUD completo para empresas innovadoras
- **📢 Gestión de Convocatorias**: Sistema avanzado con estados automáticos y manuales
- **🔐 Autenticación JWT**: Sistema de autenticación seguro con tokens JWT
- **☁️ Base de Datos en la Nube**: PostgreSQL en Supabase
- **📚 Documentación**: Swagger/OpenAPI integrado
- **🛡️ Seguridad**: Validación de datos y manejo de errores
- **🌐 CORS**: Configurado para integraciones frontend
- **🎯 Estados Flexibles**: Control manual y automático de estados de convocatorias

## 🛠️ Stack Tecnológico

- **.NET 9**: Framework principal
- **ASP.NET Core**: API REST
- **Entity Framework Core**: ORM con PostgreSQL
- **Supabase**: Base de datos PostgreSQL en la nube
- **JWT**: Autenticación y autorización
- **BCrypt**: Hasheo seguro de contraseñas
- **Swagger**: Documentación automática de API
- **Npgsql**: Driver PostgreSQL optimizado

## 🚀 Instalación y Configuración

### Prerrequisitos

- .NET 9 SDK
- Cuenta en Supabase (ya configurada)
- Editor de código (Visual Studio, VS Code, etc.)

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/BackInovationMap.git
cd BackInovationMap
```

### 2. Configuración de Base de Datos

✅ **La aplicación ya está configurada para conectarse a Supabase:**

**Credenciales configuradas:**

- **Host**: aws-0-us-east-2.pooler.supabase.com
- **Puerto**: 5432
- **Base de datos**: postgres
- **Usuario**: postgres.jsddkeyspzigizepdvoy
- **Contraseña**: Ide0qDV5AJeb83wL

> La configuración está en `appsettings.json` y `appsettings.Development.json`

### 3. Instalación y Ejecución

```bash
# 1. Restaurar dependencias
dotnet restore

# 2. Compilar proyecto
dotnet build

# 3. Aplicar migraciones (ya aplicadas a Supabase)
dotnet ef database update

# 4. Ejecutar la aplicación
dotnet run
```

🎉 **La API estará disponible en:** `http://localhost:5297`

### 4. Verificar Conexión

Abre tu navegador en: `http://localhost:5297/swagger` para ver la documentación interactiva.

## 🏗️ Arquitectura del Proyecto

```
BackInovationMap/
├── Controllers/         # Controladores de API
│   ├── AuthController.cs      # Autenticación y usuarios
│   ├── CompaniesController.cs # Gestión de empresas
│   └── ConvocatoriasController.cs # Gestión de convocatorias
├── Data/               # Contexto de base de datos
│   └── AppDbContext.cs        # Configuración EF Core
├── DTOs/               # Objetos de transferencia de datos
│   ├── AuthDto.cs            # DTOs de autenticación
│   └── ConvocatoriaDto.cs    # DTOs de convocatorias
├── Models/             # Modelos de entidad
│   ├── Company.cs            # Modelo de empresa
│   ├── Convocatoria.cs       # Modelo de convocatoria
│   └── Usuario.cs            # Modelo de usuario
├── Services/           # Servicios de negocio
│   └── JwtService.cs         # Servicio JWT
├── Migrations/         # Migraciones aplicadas a Supabase
└── Program.cs          # Configuración y startup
```

## 📖 Documentación de la API

### 🔍 Swagger UI

**Documentación interactiva disponible en:**

```
http://localhost:5297/swagger
```

### 📋 Endpoints Principales

#### 🔐 Autenticación (`/api/auth`)

| Método | Endpoint           | Descripción               | Requiere Auth |
| ------ | ------------------ | ------------------------- | ------------- |
| POST   | `/register`        | Registrar nuevo usuario   | ❌            |
| POST   | `/login`           | Iniciar sesión            | ❌            |
| GET    | `/profile`         | Obtener perfil de usuario | ✅            |
| PUT    | `/change-password` | Cambiar contraseña        | ✅            |
| POST   | `/refresh-token`   | Refrescar token JWT       | ✅            |
| GET    | `/validate`        | Validar token             | ✅            |

#### 🏢 Empresas (`/api/companies`)

| Método | Endpoint | Descripción                | Requiere Auth |
| ------ | -------- | -------------------------- | ------------- |
| GET    | `/`      | Obtener todas las empresas | ❌            |
| GET    | `/{id}`  | Obtener empresa por ID     | ❌            |
| POST   | `/`      | Crear nueva empresa        | ✅            |
| PUT    | `/{id}`  | Actualizar empresa         | ✅            |
| DELETE | `/{id}`  | Eliminar empresa           | ✅            |

#### 📢 Convocatorias (`/api/convocatorias`)

| Método | Endpoint                   | Descripción                     | Requiere Auth |
| ------ | -------------------------- | ------------------------------- | ------------- |
| GET    | `/`                        | Obtener todas las convocatorias | ❌            |
| GET    | `/{id}`                    | Obtener convocatoria por ID     | ❌            |
| POST   | `/`                        | Crear nueva convocatoria        | ✅            |
| PUT    | `/{id}`                    | Actualizar convocatoria         | ✅            |
| DELETE | `/{id}`                    | Eliminar convocatoria           | ✅            |
| GET    | `/categoria/{categoria}`   | Buscar por categoría            | ❌            |
| GET    | `/estado/{estado}`         | Buscar por estado               | ❌            |
| GET    | `/por-empresa/{companyId}` | Convocatorias por empresa       | ❌            |
| PUT    | `/{id}/estado`             | **Cambio manual de estado**     | ✅            |
| PUT    | `/{id}/estado/automatico`  | **Volver a estado automático**  | ✅            |
| GET    | `/empresas-disponibles`    | Empresas para convocatorias     | ❌            |

### 🎯 Características Especiales de Convocatorias

#### **Estados Inteligentes**

- **Automático**: Basado en fechas (pendiente → activa → cerrada)
- **Manual**: Control total del estado independiente de fechas
- **Híbrido**: Cambio entre modo manual y automático

#### **Relación con Empresas**

- Cada convocatoria puede estar asociada a una empresa
- Filtrado por empresa convocante
- Información completa de la empresa en las respuestas

### 🔑 Autenticación JWT

Para acceder a endpoints protegidos (✅), incluye el token en el header:

```bash
Authorization: Bearer tu_jwt_token_aqui
```

## 💡 Ejemplos de Uso

### 📝 Registrar Usuario

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

### 🏢 Crear Empresa

```bash
curl -X POST "http://localhost:5297/api/companies" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer tu_token" \
  -d '{
    "name": "TechCorp",
    "description": "Empresa de tecnología e innovación",
    "sector": "Tecnología",
    "department": "Antioquia",
    "url": "https://techcorp.com",
    "logoUrl": "https://techcorp.com/logo.png"
  }'
```

### 📢 Crear Convocatoria con Estado Manual

```bash
curl -X POST "http://localhost:5297/api/convocatorias" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer tu_token" \
  -d '{
    "titulo": "Convocatoria de Innovación Tecnológica",
    "descripcion": "Programa para startups tecnológicas",
    "fechaInicio": "2025-08-01T00:00:00Z",
    "fechaFin": "2025-12-31T23:59:59Z",
    "categoria": "tecnología",
    "entidad": "TechCorp S.A.S",
    "companyId": 1,
    "presupuesto": 500000000,
    "estado": "pendiente",
    "estadoManual": true,
    "requisitos": ["Empresa constituida", "Proyecto innovador"]
  }'
```

### 🔄 Cambiar Estado Manualmente

```bash
# Cambiar a estado manual
curl -X PUT "http://localhost:5297/api/convocatorias/1/estado" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer tu_token" \
  -d '{ "estado": "cerrada" }'

# Volver a estado automático
curl -X PUT "http://localhost:5297/api/convocatorias/1/estado/automatico" \
  -H "Authorization: Bearer tu_token"
```

## ☁️ Base de Datos - Supabase PostgreSQL

### � Configuración Actual

✅ **Conectado a Supabase PostgreSQL**

**Detalles de conexión:**

- **Proveedor**: Supabase (PostgreSQL en la nube)
- **Región**: AWS US-East-2
- **Base de datos**: postgres
- **Pooler**: Habilitado para máximo rendimiento

### 📋 Migraciones Aplicadas

- ✅ **InitialCreate** - Tablas básicas (Users, Companies, Convocatorias)
- ✅ **AddEstadoManualToConvocatoria** - Control manual de estados

### 🗄️ Modelo de Datos

#### **Usuario**

- ID, Nombre, Apellido, Email
- Password (hasheado con BCrypt)
- Rol, Organización, Teléfono
- Fechas de creación y último login

#### **Empresa**

- ID, Nombre, Descripción, Sector
- URL, Logo, Departamento
- Fecha de creación

#### **Convocatoria**

- ID, Título, Descripción
- Fechas de inicio y fin
- Categoría, Entidad, Presupuesto
- **Estado** (activa/cerrada/pendiente)
- **EstadoManual** (control automático/manual)
- **CompanyId** (empresa convocante)
- Requisitos (array de strings)
- Fechas de creación y actualización

### 🔧 Gestión de Migraciones

```bash
# Ver migraciones pendientes
dotnet ef migrations list

# Crear nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update

# Rollback a migración específica
dotnet ef database update NombreMigracionAnterior
```

## 🛡️ Seguridad y Mejores Prácticas

### 🔒 Seguridad Implementada

- **✅ Hasheo de Contraseñas**: BCrypt con salt automático
- **✅ JWT Seguro**: Tokens con expiración y claves robustas
- **✅ Validación de Datos**: Validaciones en DTOs y modelos
- **✅ Manejo de Errores**: Responses consistentes y sin información sensible
- **✅ CORS Configurado**: Protección contra requests no autorizados
- **✅ Base de Datos Segura**: Conexión cifrada a Supabase

### 🛠️ Configuración de Seguridad

```json
{
  "JwtSettings": {
    "SecretKey": "BackInovationMap_SuperSecret_Key_2025_MinLength32Characters!",
    "Issuer": "BackInovationMap",
    "Audience": "BackInovationMap",
    "ExpirationHours": "24"
  }
}
```

### 💡 Recomendaciones para Producción

1. **🔐 Variables de Entorno**: Nunca hardcodees credenciales
2. **🌐 HTTPS**: Siempre usa HTTPS en producción
3. **⏱️ Rate Limiting**: Implementa límites de requests por IP
4. **📝 Logging**: Configura logs centralizados
5. **🔄 Backup**: Configura respaldos automáticos en Supabase

## 🧪 Testing y Desarrollo

### 🔍 Endpoints de Prueba

```bash
# Verificar estado de la API
curl http://localhost:5297/api/companies

# Verificar autenticación
curl http://localhost:5297/api/auth/validate \
  -H "Authorization: Bearer tu_token"

# Verificar convocatorias
curl http://localhost:5297/api/convocatorias
```

### 📊 Monitoreo

- **Swagger UI**: `http://localhost:5297/swagger`
- **Health Check**: Endpoints públicos responden con datos
- **Logs**: Consola en desarrollo, configurables para producción

## 🚀 Deployment y Producción

### 🏠 Desarrollo Local

```bash
# Ejecutar en modo desarrollo
dotnet run --environment Development

# Con puerto específico
dotnet run --urls "http://localhost:5001"
```

### 📦 Producción

```bash
# Compilar para producción
dotnet publish -c Release -o ./publish

# Ejecutar build de producción
dotnet ./publish/BackInovationMap.dll
```

### ☁️ Despliegue en la Nube

El proyecto está listo para desplegar en:

- **Azure App Service**
- **AWS Elastic Beanstalk**
- **Google Cloud Run**
- **Railway**, **Render**, **Fly.io**

> La base de datos ya está en Supabase, solo necesitas desplegar la API.

### ☁️ Despliegue en Render

El proyecto está configurado para desplegarse fácilmente en Render:

**Start Command para Render:**

```
dotnet BackInovationMap.dll
```

**Ver guía completa:** [`DEPLOY_RENDER.md`](./DEPLOY_RENDER.md)

**URLs después del despliegue:**

- API: `https://tu-app.onrender.com`
- Swagger: `https://tu-app.onrender.com/swagger`

## 📞 Contacto y Soporte

### 👨‍💻 Información del Desarrollador

- **Desarrollador**: Juan [Tu Nombre]
- **Proyecto**: BackInovationMap - API de Gestión de Innovación
- **Universidad**: EAFIT - Especialización
- **Año**: 2025

### 🔗 Enlaces Útiles

- **📖 Documentación**: `http://localhost:5297/swagger`
- **☁️ Base de Datos**: [Supabase Dashboard](https://supabase.com/dashboard)
- **🛠️ Entity Framework**: [Documentación oficial](https://docs.microsoft.com/ef/)

## 🎯 Estado del Proyecto

**✅ COMPLETADO Y FUNCIONAL**

- Backend API completo ✅
- Base de datos Supabase conectada ✅
- Autenticación JWT implementada ✅
- CRUD de empresas y convocatorias ✅
- Estados manuales/automáticos ✅
- Documentación completa ✅
- Listo para integración con frontend ✅

## 🙏 Agradecimientos

- **EAFIT** - Universidad por la formación académica
- **Supabase** - Por la infraestructura de base de datos
- **Microsoft** - Por .NET y Entity Framework Core
- **Comunidad .NET** - Por las herramientas y documentación
- **PostgreSQL** - Por la base de datos robusta y confiable

---

⭐ **¡No olvides darle una estrella al proyecto si te fue útil!** ⭐
#   B a c k I n o v a t i o n M a p 
