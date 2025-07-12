# 🚀 BackInovationMap - API REST para Gestión de Innovación

Una API REST robusta desarrollada en .NET 9 para la gestión de empresas, convocatorias y usuarios en plataformas de innovación. **Desplegada en Render y conectada a Supabase PostgreSQL** para máximo rendimiento y escalabilidad.

## 🌐 URLs de Producción

- **🚀 API en Producción**: https://backinovationmap.onrender.com
- **📚 Documentación Swagger**: https://backinovationmap.onrender.com/swagger
- **📊 Estado de la API**: https://backinovationmap.onrender.com/api/companies/health

## ⭐ Características Principales

- **🏢 Gestión de Empresas**: CRUD completo con health checks
- **📢 Gestión de Convocatorias**: Sistema avanzado con estados automáticos y manuales
- **🔐 Autenticación JWT**: Sistema de autenticación seguro con tokens JWT
- **☁️ Base de Datos en la Nube**: PostgreSQL en Supabase con pooling automático
- **📚 Documentación**: Swagger/OpenAPI integrado en desarrollo y producción
- **🛡️ Seguridad**: Validación de datos, logging avanzado y manejo de errores
- **🌐 CORS**: Configurado para localhost:3000 y Vercel production
- **🎯 Estados Flexibles**: Control manual y automático de estados de convocatorias
- **🔍 Health Checks**: Endpoints de monitoreo para producción
- **📝 Logging Avanzado**: Tracking detallado de requests y errores

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

### 2. Configuración de Base de Datos Supabase

✅ **La aplicación ya está configurada y desplegada con conexión a Supabase:**

**📊 Credenciales de Producción:**

- 🔒 \*[Información sensible eliminada]\*\*\*: Ide0qDV5AJeb83wL
- **Pooler**: Habilitado para máximo rendimiento

**🔧 Migraciones Aplicadas:**

- ✅ **InitialCreate** - Tablas básicas (Users, Companies, Convocatorias)
- ✅ **AddEstadoManualToConvocatoria** - Control manual de estados

> La configuración está en `appsettings.json` y las migraciones ya están aplicadas en Supabase

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

🎉 **La API estará disponible en:**

- **Desarrollo**: `http://localhost:5297`
- **Producción**: `https://backinovationmap.onrender.com`

### 4. Verificar Conexión

**En desarrollo:**

- Abre tu navegador en: `http://localhost:5297/swagger`

**En producción:**

- API: `https://backinovationmap.onrender.com/api/convocatorias`
- Swagger: `https://backinovationmap.onrender.com/swagger`
- Health Check: `https://backinovationmap.onrender.com/api/companies/health`

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

#### � Health Checks

| Método | Endpoint                    | Descripción                | Status |
| ------ | --------------------------- | -------------------------- | ------ |
| GET    | `/api/companies/health`     | Health check general       | ✅     |
| GET    | `/api/convocatorias/health` | Health check convocatorias | ✅     |
| GET    | `/api/companies/debug`      | Debug info empresas        | ✅     |

#### �🔐 Autenticación (`/api/auth`)

| Método | Endpoint           | Descripción               | Requiere Auth |
| ------ | ------------------ | ------------------------- | ------------- |
| POST   | `/register`        | Registrar nuevo usuario   | ❌            |
| POST   | `/login`           | Iniciar sesión            | ❌            |
| GET    | `/profile`         | Obtener perfil de usuario | ✅            |
| PUT    | `/change-password` | Cambiar contraseña        | ✅            |
| POST   | `/refresh-token`   | Refrescar token JWT       | ✅            |
| GET    | `/validate`        | Validar token             | ✅            |

#### 🏢 Empresas (`/api/companies`)

| Método | Endpoint  | Descripción                | Requiere Auth | Status |
| ------ | --------- | -------------------------- | ------------- | ------ |
| GET    | `/`       | Obtener todas las empresas | ❌            | ✅     |
| GET    | `/{id}`   | Obtener empresa por ID     | ❌            | ✅     |
| POST   | `/`       | Crear nueva empresa        | ✅            | ✅     |
| PUT    | `/{id}`   | Actualizar empresa         | ✅            | ✅     |
| DELETE | `/{id}`   | Eliminar empresa           | ✅            | ✅     |
| GET    | `/health` | Health check               | ❌            | ✅     |
| GET    | `/debug`  | Debug info                 | ❌            | ✅     |

#### 📢 Convocatorias (`/api/convocatorias`)

| Método | Endpoint                   | Descripción                     | Requiere Auth | Status |
| ------ | -------------------------- | ------------------------------- | ------------- | ------ |
| GET    | `/`                        | Obtener todas las convocatorias | ❌            | ✅     |
| GET    | `/{id}`                    | Obtener convocatoria por ID     | ❌            | ✅     |
| POST   | `/`                        | **Crear nueva convocatoria**    | ❌            | ✅     |
| PUT    | `/{id}`                    | Actualizar convocatoria         | ✅            | ✅     |
| DELETE | `/{id}`                    | Eliminar convocatoria           | ✅            | ✅     |
| GET    | `/categoria/{categoria}`   | Buscar por categoría            | ❌            | ✅     |
| GET    | `/estado/{estado}`         | Buscar por estado               | ❌            | ✅     |
| GET    | `/por-empresa/{companyId}` | Convocatorias por empresa       | ❌            | ✅     |
| PUT    | `/{id}/estado`             | **Cambio manual de estado**     | ✅            | ✅     |
| PUT    | `/{id}/estado/automatico`  | **Volver a estado automático**  | ✅            | ✅     |
| GET    | `/empresas-disponibles`    | **Empresas para convocatorias** | ❌            | ✅     |
| GET    | `/health`                  | **Health check**                | ❌            | ✅     |

## � Frontend Integration

### 📡 **CORS Configurado para:**

- ✅ `http://localhost:3000` (Next.js desarrollo)
- ✅ `http://localhost:3001` (puerto alternativo)
- ✅ `https://localhost:3000` (HTTPS local)
- ✅ `https://innovation-map-frontend.vercel.app` (producción)

### 🚀 **Crear Convocatoria desde Frontend**

**URL del endpoint:**

```javascript
POST https://backinovationmap.onrender.com/api/convocatorias
```

**Ejemplo de petición:**

```javascript
const crearConvocatoria = async (datosConvocatoria) => {
  try {
    const response = await fetch(
      `${process.env.NEXT_PUBLIC_API_URL}/api/convocatorias`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json",
        },
        body: JSON.stringify({
          Titulo: "Convocatoria de Innovación 2025",
          Descripcion: "Programa de apoyo a startups tecnológicas",
          FechaInicio: "2025-01-15T00:00:00Z",
          FechaFin: "2025-03-15T00:00:00Z",
          Categoria: "tecnología",
          Entidad: "Isagen",
          CompanyId: 1,
          Presupuesto: 50000000,
          Requisitos: ["Empresa constituida", "Proyecto innovador"],
        }),
      }
    );

    if (!response.ok) throw new Error(`Error ${response.status}`);
    return await response.json();
  } catch (error) {
    console.error("Error al crear convocatoria:", error);
    throw error;
  }
};
```

**⚠️ Configuración Frontend:**

```bash
# Variable de entorno requerida en Vercel:
NEXT_PUBLIC_API_URL=https://backinovationmap.onrender.com
```

### 🎯 Características Especiales de Convocatorias

#### **Estados Inteligentes**

- **Automático**: Basado en fechas (pendiente → activa → cerrada)
- **Manual**: Control total del estado independiente de fechas
- **Híbrido**: Cambio entre modo manual y automático

#### **Relación con Empresas**

- Cada convocatoria puede estar asociada a una empresa
- Filtrado por empresa convocante
- Información completa de la empresa en las respuestas
- Endpoint específico: `/api/convocatorias/empresas-disponibles`

### 🔑 Autenticación JWT

Para acceder a endpoints protegidos (✅), incluye el token en el header:

```bash
Authorization: Bearer tu_jwt_token_aqui
```

## 💡 Ejemplos de Uso

### 🧪 **Probar Endpoints en Producción**

```bash
# 1. Health Check
curl https://backinovationmap.onrender.com/api/companies/health

# 2. Listar empresas disponibles
curl https://backinovationmap.onrender.com/api/convocatorias/empresas-disponibles

# 3. Listar convocatorias
curl https://backinovationmap.onrender.com/api/convocatorias
```

### 📝 Registrar Usuario

```bash
curl -X POST "https://backinovationmap.onrender.com/api/auth/register" \
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
curl -X POST "https://backinovationmap.onrender.com/api/companies" \
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

### 📢 Crear Convocatoria

```bash
curl -X POST "https://backinovationmap.onrender.com/api/convocatorias" \
  -H "Content-Type: application/json" \
  -d '{
    "Titulo": "Convocatoria de Innovación Tecnológica 2025",
    "Descripcion": "Programa para startups tecnológicas",
    "FechaInicio": "2025-01-15T00:00:00Z",
    "FechaFin": "2025-03-15T00:00:00Z",
    "Categoria": "tecnología",
    "Entidad": "Isagen",
    "CompanyId": 1,
    "Presupuesto": 50000000,
    "Requisitos": ["Empresa constituida", "Proyecto innovador"]
  }'
```

### 🔄 Cambiar Estado Manualmente

```bash
# Cambiar a estado manual
curl -X PUT "https://backinovationmap.onrender.com/api/convocatorias/1/estado" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer tu_token" \
  -d '{ "estado": "cerrada" }'

# Volver a estado automático
curl -X PUT "https://backinovationmap.onrender.com/api/convocatorias/1/estado/automatico" \
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
    "SecretKey": "[ELIMINADO]",
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

### 🧪 Testing y Monitoreo

#### 🔍 **Endpoints de Prueba en Producción**

```bash
# Verificar estado de la API
curl https://backinovationmap.onrender.com/api/companies/health

# Verificar convocatorias
curl https://backinovationmap.onrender.com/api/convocatorias

# Verificar empresas disponibles para convocatorias
curl https://backinovationmap.onrender.com/api/convocatorias/empresas-disponibles
```

#### 📊 **Monitoreo**

- **Swagger UI**: `https://backinovationmap.onrender.com/swagger`
- **Health Check**: Endpoints públicos responden con datos
- **Logs**: Logging avanzado configurado en producción
- **Database**: Supabase dashboard para monitoreo de BD

## 🚀 Deployment y Producción

### ☁️ **Estado Actual de Producción**

✅ **API completamente desplegada en Render:**

- **URL de Producción**: https://backinovationmap.onrender.com
- **Swagger en Producción**: https://backinovationmap.onrender.com/swagger
- **Health Check**: https://backinovationmap.onrender.com/api/companies/health
- **Base de Datos**: Supabase PostgreSQL conectada y operacional
- **Redespliegue**: Automático con cada push a GitHub

### 🔧 **Configuración de Render**

El proyecto incluye configuración para Render:

```dockerfile
# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["BackInovationMap.csproj", "."]
RUN dotnet restore "BackInovationMap.csproj"
COPY . .
RUN dotnet build "BackInovationMap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackInovationMap.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "BackInovationMap.dll"]
```

**Start Command en Render:**

```bash
dotnet BackInovationMap.dll
```

### 📦 Desarrollo Local vs Producción

#### 🏠 **Desarrollo Local**

```bash
# Ejecutar en modo desarrollo
dotnet run --environment Development

# Con puerto específico
dotnet run --urls "http://localhost:5001"

# Swagger local disponible en:
http://localhost:5297/swagger
```

#### ☁️ **Producción (Render)**

- **URL**: https://backinovationmap.onrender.com
- **Redespliegue**: Automático con cada `git push`
- **Variables de entorno**: Configuradas en Render
- **Base de datos**: Supabase PostgreSQL
- **CORS**: Configurado para localhost y Vercel

### 🌐 **Otras plataformas**

El proyecto está listo para desplegar en:

- **Azure App Service**
- **AWS Elastic Beanstalk**
- **Google Cloud Run**
- **Railway**, **Fly.io**

> La base de datos ya está en Supabase, solo necesitas desplegar la API.

## 📞 Contacto y Soporte

### 👨‍💻 Información del Desarrollador

- **Desarrollador**: Juan [Tu Nombre]
- **Proyecto**: BackInovationMap - API de Gestión de Innovación
- **Universidad**: EAFIT - Especialización
- **Año**: 2025

### 🔗 Enlaces Útiles

- **� API en Producción**: https://backinovationmap.onrender.com
- **�📖 Documentación Swagger**: https://backinovationmap.onrender.com/swagger
- **☁️ Base de Datos**: [Supabase Dashboard](https://supabase.com/dashboard)
- **🛠️ Entity Framework**: [Documentación oficial](https://docs.microsoft.com/ef/)
- **📦 Repositorio GitHub**: https://github.com/elrincondeaguilar/BackInovationMap

## 🎯 Estado del Proyecto

**✅ COMPLETADO Y DESPLEGADO EN PRODUCCIÓN**

- Backend API completo ✅
- **Desplegado en Render** ✅ (`https://backinovationmap.onrender.com`)
- Base de datos Supabase conectada ✅
- Autenticación JWT implementada ✅
- CRUD de empresas y convocatorias ✅
- Estados manuales/automáticos ✅
- **Health checks y monitoring** ✅
- **Logging avanzado** ✅
- **CORS para localhost y Vercel** ✅
- Documentación completa ✅
- Listo para integración con frontend ✅

### 📊 **Datos de Producción**

**Empresas disponibles**: 2 (Isagen, MinCiencias)  
**Convocatorias**: 1 (Test Convocatoria)  
**Uptime**: 24/7 en Render  
**Base de datos**: PostgreSQL en Supabase

### 🚀 **Para Frontend Developers**

**URL de la API**: `https://backinovationmap.onrender.com`  
**Documentación**: `https://backinovationmap.onrender.com/swagger`  
**Variable de entorno**: `NEXT_PUBLIC_API_URL=https://backinovationmap.onrender.com`

## 🙏 Agradecimientos

- 👩‍🏫 **Prof. Marinellys Figueroa** – Por su orientación y acompañamiento en este proyecto
- 👨‍💻 **Juan Fernando Aguilar Rincón** – Desarrollador del backend y autor del proyecto
- 🏫 **EAFIT** – Universidad por la formación académica

---

⭐ **¡No olvides darle una estrella al proyecto si te fue útil!** ⭐

#
