# 🚀 BackInovationMap - API REST para Gestión del Ecosistema de Innovación

Una API REST robusta desarrollada en .NET 9 para la gestión del ecosistema de innovación con empresas, articuladores y convocatorias. **Desplegada en Render y conectada a Supabase PostgreSQL** para máximo rendimiento y escalabilidad.

## 🌐 URLs de Producción

- **🚀 API en Producción**: https://backinovationmap.onrender.com
- **📚 Documentación Swagger**: https://backinovationmap.onrender.com/swagger
- **📊 Estado de la API**: https://backinovationmap.onrender.com/api/companies/health

---

## 📋 Índice

- [⭐ Características Principales](#-características-principales)
- [🛠️ Stack Tecnológico](#️-stack-tecnológico)
- [🏗️ Arquitectura del Sistema](#️-arquitectura-del-sistema)
- [🚀 Instalación y Configuración](#-instalación-y-configuración)
- [🎯 Endpoints Disponibles](#-endpoints-disponibles)
- [🗺️ Integración del Mapa del Ecosistema](#️-integración-del-mapa-del-ecosistema)
- [🔄 Guía de Migración del Frontend](#-guía-de-migración-del-frontend)
- [📊 Base de Datos](#-base-de-datos)
- [🛡️ Seguridad](#️-seguridad)
- [🚀 Despliegue](#-despliegue)
- [📝 Logging y Monitoreo](#-logging-y-monitoreo)

---

## ⭐ Características Principales

- **🏢 Gestión de Empresas**: CRUD completo con campos geográficos para visualización en mapa
- **🤝 Gestión de Articuladores**: Sistema completo de articuladores del ecosistema de innovación
- **📢 Gestión de Convocatorias**: Sistema avanzado con estados automáticos y manuales
- **🗺️ Mapa Unificado del Ecosistema**: API centralizada para visualización geográfica de todas las entidades
- **🔗 Relaciones Between Entidades**: Sistema de relaciones many-to-many entre articuladores, empresas y convocatorias
- **🔐 Autenticación JWT**: Sistema de autenticación seguro con tokens JWT
- **☁️ Base de Datos en la Nube**: PostgreSQL en Supabase con pooling automático
- **📚 Documentación**: Swagger/OpenAPI integrado en desarrollo y producción
- **🛡️ Seguridad**: Validación de datos, logging avanzado y manejo de errores
- **🌐 CORS**: Configurado para localhost:3000 y Vercel production
- **🎯 Estados Flexibles**: Control manual y automático de estados de convocatorias
- **🔍 Health Checks**: Endpoints de monitoreo para producción
- **📝 Logging Avanzado**: Tracking detallado de requests y errores

---

## 🛠️ Stack Tecnológico

- **.NET 9**: Framework principal
- **ASP.NET Core**: API REST con arquitectura limpia
- **Entity Framework Core**: ORM con PostgreSQL y migraciones automáticas
- **Supabase**: Base de datos PostgreSQL en la nube con pooling
- **JWT**: Autenticación y autorización
- **BCrypt**: Hasheo seguro de contraseñas
- **Swagger**: Documentación automática de API
- **Npgsql**: Driver PostgreSQL optimizado
- **AutoMapper**: Mapeo automático entre DTOs y entidades

---

## 🏗️ Arquitectura del Sistema

El sistema está diseñado con una arquitectura limpia que incluye:

### 📁 Estructura del Proyecto

```
BackInovationMap/
├── Controllers/           # Controladores API REST
│   ├── CompaniesController.cs
│   ├── ArticuladoresController.cs
│   ├── ConvocatoriasController.cs
│   ├── EcosystemMapController.cs
│   ├── EcosystemRelationsController.cs
│   └── AuthController.cs
├── Models/               # Entidades de dominio
│   ├── Company.cs
│   ├── Articulador.cs
│   ├── Convocatoria.cs
│   ├── Usuario.cs
│   ├── EcosystemMapItem.cs
│   ├── ArticuladorCompany.cs
│   └── ArticuladorConvocatoria.cs
├── Data/                 # Contexto de Entity Framework
│   └── AppDbContext.cs
├── Services/             # Lógica de negocio
│   └── EcosystemMapService.cs
├── Migrations/           # Migraciones de BD
└── Properties/
    └── launchSettings.json
```

### 🎯 Entidades Principales

1. **🏢 Companies**: Empresas del ecosistema de innovación
2. **🤝 Articuladores**: Facilitadores y articuladores del ecosistema
3. **📢 Convocatorias**: Llamadas y procesos de innovación
4. **👥 Usuarios**: Sistema de autenticación y roles
5. **🗺️ EcosystemMapItem**: Vista unificada para el mapa del ecosistema

---

## 🚀 Instalación y Configuración

### Prerrequisitos

- .NET 9 SDK
- Cuenta en Supabase (ya configurada)
- Editor de código (Visual Studio, VS Code, etc.)

### 1. Clonar el Repositorio

```bash
git clone https://github.com/elrincondeaguilar/BackInovationMap.git
cd BackInovationMap
```

### 2. Configuración de Variables de Entorno

Crear archivo `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=tu-host.supabase.co;Database=postgres;Username=tu-usuario;Password=tu-password;Port=5432;Pooling=true;SSL Mode=Require;Trust Server Certificate=true;"
  },
  "Jwt": {
    "Key": "tu-jwt-secret-key-muy-segura-de-al-menos-32-caracteres",
    "Issuer": "BackInovationMap",
    "Audience": "BackInovationMapUsers"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### 3. Instalación y Ejecución

```bash
# Restaurar paquetes
dotnet restore

# Aplicar migraciones
dotnet ef database update

# Ejecutar en desarrollo
dotnet run

# Ejecutar con hot reload
dotnet watch run
```

### 4. Verificar Instalación

- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/api/companies/health

---

## 🎯 Endpoints Disponibles

### 🏢 **Companies API**
```
GET    /api/companies           # Obtener todas las empresas
GET    /api/companies/{id}      # Obtener empresa por ID
POST   /api/companies           # Crear nueva empresa
PUT    /api/companies/{id}      # Actualizar empresa
DELETE /api/companies/{id}      # Eliminar empresa
GET    /api/companies/health    # Health check
```

### 🤝 **Articuladores API**
```
GET    /api/articuladores       # Obtener todos los articuladores
GET    /api/articuladores/{id}  # Obtener articulador por ID
POST   /api/articuladores       # Crear nuevo articulador
PUT    /api/articuladores/{id}  # Actualizar articulador
DELETE /api/articuladores/{id}  # Eliminar articulador
GET    /api/articuladores/health # Health check
```

### 📢 **Convocatorias API**
```
GET    /api/convocatorias       # Obtener todas las convocatorias
GET    /api/convocatorias/{id}  # Obtener convocatoria por ID
POST   /api/convocatorias       # Crear nueva convocatoria
PUT    /api/convocatorias/{id}  # Actualizar convocatoria
DELETE /api/convocatorias/{id}  # Eliminar convocatoria
GET    /api/convocatorias/health # Health check
```

### 🗺️ **Ecosystem Map API**
```
GET    /api/ecosystemmap        # Obtener mapa unificado del ecosistema
GET    /api/ecosystemmap/stats  # Estadísticas del mapa
GET    /api/ecosystemmap/health # Health check del servicio
```

### 🔗 **Ecosystem Relations API**
```
GET    /api/ecosystemrelations/articulador-companies    # Relaciones articulador-empresa
GET    /api/ecosystemrelations/articulador-convocatorias # Relaciones articulador-convocatoria
GET    /api/ecosystemrelations/company/{id}/articuladores # Articuladores de una empresa
GET    /api/ecosystemrelations/convocatoria/{id}/articuladores # Articuladores de una convocatoria
```

### 🔐 **Auth API**
```
POST   /api/auth/login          # Iniciar sesión
POST   /api/auth/register       # Registrar usuario
GET    /api/auth/profile        # Obtener perfil del usuario
```

---

## 🗺️ Integración del Mapa del Ecosistema

### 🎯 **Objetivo**
Proporcionar una API unificada para visualizar todas las entidades del ecosistema de innovación (Companies y Articuladores) en un mapa interactivo con capacidades de filtrado avanzado.

### 🆕 **Funcionalidades del Mapa**

#### 📍 **Campos Geográficos**
Todas las entidades incluyen campos para geolocalización:

```typescript
interface GeoEntity {
  ciudad?: string;        // Ciudad donde se ubica
  departamento?: string;  // Departamento/Estado
  latitud?: number;       // Coordenada de latitud
  longitud?: number;      // Coordenada de longitud
}
```

#### 🗺️ **Modelo Unificado**
```typescript
interface EcosystemMapItem {
  id: number;
  type: "Company" | "Articulador";
  name: string;
  description?: string;
  category?: string;
  ciudad?: string;
  departamento?: string;
  latitud?: number;
  longitud?: number;
  enlace?: string;
  createdAt: string;
  updatedAt: string;
  metadata: Record<string, any>;
}
```

#### 🎛️ **Filtros Disponibles**

1. **Por Tipo de Entidad**
```
GET /api/ecosystemmap?types=Company
GET /api/ecosystemmap?types=Articulador
GET /api/ecosystemmap?types=Company,Articulador
```

2. **Por Ubicación Geográfica**
```
GET /api/ecosystemmap?departamento=Antioquia
GET /api/ecosystemmap?ciudad=Medellín
GET /api/ecosystemmap?departamento=Antioquia&ciudad=Medellín
```

3. **Combinaciones de Filtros**
```
GET /api/ecosystemmap?types=Company&departamento=Antioquia&ciudad=Medellín
```

#### 📊 **Estadísticas del Mapa**
```
GET /api/ecosystemmap/stats
```

**Respuesta:**
```json
{
  "total": 110,
  "byType": {
    "Company": 80,
    "Articulador": 30
  },
  "byDepartamento": {
    "Antioquia": 60,
    "Cundinamarca": 45,
    "Valle del Cauca": 25
  },
  "withCoordinates": 100,
  "withoutCoordinates": 10
}
```

### 🎨 **Implementación en el Frontend**

#### TypeScript/React Example
```typescript
import { useState, useEffect } from 'react';

interface EcosystemMapItem {
  id: number;
  type: "Company" | "Articulador";
  name: string;
  description?: string;
  ciudad?: string;
  departamento?: string;
  latitud?: number;
  longitud?: number;
}

const EcosystemMap = () => {
  const [items, setItems] = useState<EcosystemMapItem[]>([]);
  const [filters, setFilters] = useState({
    types: [] as string[],
    departamento: '',
    ciudad: ''
  });

  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams();
      
      if (filters.types.length > 0) {
        params.append('types', filters.types.join(','));
      }
      if (filters.departamento) {
        params.append('departamento', filters.departamento);
      }
      if (filters.ciudad) {
        params.append('ciudad', filters.ciudad);
      }

      const response = await fetch(`/api/ecosystemmap?${params.toString()}`);
      const data = await response.json();
      setItems(data);
    };

    fetchData();
  }, [filters]);

  return (
    <div>
      {/* Filtros */}
      <div className="filters">
        <select onChange={(e) => setFilters({...filters, departamento: e.target.value})}>
          <option value="">Todos los departamentos</option>
          <option value="Antioquia">Antioquia</option>
          <option value="Cundinamarca">Cundinamarca</option>
        </select>
        
        <div>
          <label>
            <input 
              type="checkbox" 
              checked={filters.types.includes('Company')}
              onChange={(e) => {
                const newTypes = e.target.checked 
                  ? [...filters.types, 'Company']
                  : filters.types.filter(t => t !== 'Company');
                setFilters({...filters, types: newTypes});
              }}
            />
            Empresas
          </label>
          
          <label>
            <input 
              type="checkbox" 
              checked={filters.types.includes('Articulador')}
              onChange={(e) => {
                const newTypes = e.target.checked 
                  ? [...filters.types, 'Articulador']
                  : filters.types.filter(t => t !== 'Articulador');
                setFilters({...filters, types: newTypes});
              }}
            />
            Articuladores
          </label>
        </div>
      </div>

      {/* Mapa */}
      <div className="map">
        {items.map(item => (
          <div key={`${item.type}-${item.id}`} className="map-marker">
            <h4>{item.name}</h4>
            <p>{item.type}</p>
            <p>{item.ciudad}, {item.departamento}</p>
          </div>
        ))}
      </div>
    </div>
  );
};
```

---

## 🔄 Guía de Migración del Frontend

### 📋 **Resumen de Cambios**

Se han agregado nuevas entidades y campos extendidos al backend .NET:

#### 🆕 **Nuevas Entidades**
1. **Articuladores** - `/api/articuladores`

#### 🔧 **Entidades Extendidas**
1. **Companies** - Campos geográficos adicionales
2. **Convocatorias** - Campos adicionales

### 🚀 **1. Nuevos Endpoints Disponibles**

#### **Articuladores**
```typescript
interface Articulador {
  id: number;
  nombre: string;          // required, max 200 chars
  tipo?: string;           // max 100 chars
  region?: string;         // max 100 chars
  contacto?: string;       // text
  ciudad?: string;         // max 100 chars
  departamento?: string;   // max 100 chars
  latitud?: number;        // coordenada geográfica
  longitud?: number;       // coordenada geográfica
  createdAt: string;       // ISO date
  updatedAt: string;       // ISO date
}
```

### 🔧 **2. Endpoints Extendidos**

#### **Companies** (✅ COMPATIBLE - Campos Opcionales)
```typescript
interface Company {
  id: number;
  name: string;            // existing
  url: string;             // existing
  logoUrl: string;         // existing
  sector: string;          // existing
  department: string;      // existing
  description: string;     // existing
  createdAt: string;       // existing
  
  // 🆕 NUEVOS CAMPOS (todos opcionales)
  tipoActor?: string;      // ⚠️ NUEVO - tipo de actor de innovación
  ciudad?: string;         // ⚠️ NUEVO - ciudad
  direccion?: string;      // ⚠️ NUEVO - dirección
  contacto?: string;       // ⚠️ NUEVO - información de contacto
  latitud?: number;        // ⚠️ NUEVO - coordenada de latitud
  longitud?: number;       // ⚠️ NUEVO - coordenada de longitud
}
```

#### **Convocatorias** (✅ COMPATIBLE - Campos Opcionales)
```typescript
interface Convocatoria {
  id: number;
  title: string;           // existing
  description: string;     // existing
  estado: string;          // existing
  categoria: string;       // existing
  fechaInicio: string;     // existing
  fechaFin: string;        // existing
  presupuesto: number;     // existing
  createdAt: string;       // existing
  updatedAt: string;       // existing
  
  // 🆕 NUEVOS CAMPOS (todos opcionales)
  companyId?: number;      // ⚠️ NUEVO - empresa asociada
  requisitos?: string[];   // ⚠️ NUEVO - lista de requisitos
}
```

### 🛠️ **3. Pasos de Migración**

#### **Paso 1: Actualizar Interfaces TypeScript**
```typescript
// types/api.ts - Actualizar con los nuevos campos
interface Company {
  // ... campos existentes
  tipoActor?: string;
  ciudad?: string;
  direccion?: string;
  contacto?: string;
  latitud?: number;
  longitud?: number;
}

interface Articulador {
  id: number;
  nombre: string;
  tipo?: string;
  region?: string;
  contacto?: string;
  ciudad?: string;
  departamento?: string;
  latitud?: number;
  longitud?: number;
  createdAt: string;
  updatedAt: string;
}
```

#### **Paso 2: Crear Servicios para Nuevas Entidades**
```typescript
// services/articuladoresService.ts
export const articuladoresService = {
  getAll: () => fetch('/api/articuladores').then(r => r.json()),
  getById: (id: number) => fetch(`/api/articuladores/${id}`).then(r => r.json()),
  create: (data: Partial<Articulador>) => 
    fetch('/api/articuladores', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(data)
    }).then(r => r.json()),
  update: (id: number, data: Partial<Articulador>) =>
    fetch(`/api/articuladores/${id}`, {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(data)
    }),
  delete: (id: number) => fetch(`/api/articuladores/${id}`, { method: 'DELETE' })
};
```

#### **Paso 3: Integrar el Mapa del Ecosistema**
```typescript
// services/ecosystemMapService.ts
export const ecosystemMapService = {
  getAll: async (filters?: {
    types?: string[];
    departamento?: string;
    ciudad?: string;
  }) => {
    const params = new URLSearchParams();
    if (filters?.types) params.append('types', filters.types.join(','));
    if (filters?.departamento) params.append('departamento', filters.departamento);
    if (filters?.ciudad) params.append('ciudad', filters.ciudad);
    
    const response = await fetch(`/api/ecosystemmap?${params.toString()}`);
    return response.json();
  },
  
  getStats: () => fetch('/api/ecosystemmap/stats').then(r => r.json())
};
```

### ✅ **4. Verificación de Compatibilidad**

#### **Verificar endpoints existentes:**
- ✅ `GET /api/companies` - funcionará normalmente con nuevos campos
- ✅ `GET /api/convocatorias` - funcionará normalmente con nuevos campos

#### **Probar nuevos endpoints:**
- 🆕 `GET /api/articuladores` - debe retornar array vacío inicialmente
- 🆕 `GET /api/ecosystemmap` - debe retornar mapa unificado
- 🆕 `GET /api/ecosystemrelations/articulador-companies` - relaciones

---

## 📊 Base de Datos

### 🗄️ **Esquema de Base de Datos**

#### Tablas Principales:
- **Companies**: Empresas del ecosistema
- **Articuladores**: Articuladores y facilitadores
- **Convocatorias**: Llamadas y procesos
- **Usuarios**: Sistema de autenticación
- **ArticuladorCompanies**: Relaciones many-to-many
- **ArticuladorConvocatorias**: Relaciones many-to-many

#### Campos Geográficos:
Todas las entidades principales incluyen:
- `Ciudad` (string, 100 caracteres)
- `Departamento` (string, 100 caracteres)
- `Latitud` (decimal nullable)
- `Longitud` (decimal nullable)

### 🔄 **Migraciones**

El sistema incluye las siguientes migraciones:
- `InitialCreate`: Estructura base
- `AddGeographicFieldsForMapIntegration`: Campos geográficos
- `AddEcosystemRelationships`: Tablas de relaciones
- `RemovePortafolioArcoTable`: Limpieza de entidades obsoletas
- `RemovePromotoresTable`: Simplificación del modelo

#### Aplicar Migraciones:
```bash
# Aplicar todas las migraciones pendientes
dotnet ef database update

# Ver historial de migraciones
dotnet ef migrations list

# Crear nueva migración
dotnet ef migrations add NombreDeLaMigracion
```

---

## 🛡️ Seguridad

### 🔐 **Autenticación JWT**
- Tokens JWT con expiración configurable
- Refresh tokens para sesiones extendidas
- Hasheo de contraseñas con BCrypt

### 🛡️ **Validación de Datos**
- Validación automática con Data Annotations
- Sanitización de inputs
- Validación de tipos y rangos

### 🚨 **Manejo de Errores**
- Logging detallado de errores
- Respuestas de error estandarizadas
- No exposición de información sensible

### 🌐 **CORS**
```csharp
// Configuración CORS para desarrollo y producción
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://tu-frontend.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

---

## 🚀 Despliegue

### 🌐 **Render (Producción)**

#### Variables de Entorno en Render:
```bash
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=tu-connection-string-supabase
Jwt__Key=tu-jwt-secret-key
Jwt__Issuer=BackInovationMap
Jwt__Audience=BackInovationMapUsers
```

#### Build & Deploy:
```bash
# Build command
dotnet publish -c Release -o out

# Start command
dotnet out/BackInovationMap.dll
```

### 🐳 **Docker (Opcional)**
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY out/ .
EXPOSE 8080
ENTRYPOINT ["dotnet", "BackInovationMap.dll"]
```

---

## 📝 Logging y Monitoreo

### 📊 **Health Checks**
```
GET /api/companies/health
GET /api/articuladores/health
GET /api/convocatorias/health
GET /api/ecosystemmap/health
```

### 🔍 **Logging**
- Structured logging con Serilog
- Logs de requests HTTP
- Tracking de errores y excepciones
- Métricas de rendimiento

### 📈 **Monitoreo**
- Health endpoints para verificación de estado
- Métricas de base de datos
- Monitoring de conexiones a Supabase

---

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está licenciado bajo la MIT License - ver el archivo [LICENSE](LICENSE) para detalles.

---

## 👥 Equipo

- **Desarrollo Backend**: .NET 9 + Entity Framework Core
- **Base de Datos**: Supabase PostgreSQL
- **Despliegue**: Render
- **Documentación**: Swagger/OpenAPI

---

## 🔧 Troubleshooting

### Problemas Comunes:

1. **Error de Conexión a Base de Datos**
   - Verificar connection string en appsettings
   - Comprobar conectividad a Supabase

2. **JWT Token Inválido**
   - Verificar configuración de JWT Key
   - Comprobar formato del token

3. **CORS Errors**
   - Verificar configuración de origins permitidos
   - Comprobar headers en requests del frontend

4. **Migraciones**
   ```bash
   # Reset database (CUIDADO: Elimina todos los datos)
   dotnet ef database drop
   dotnet ef database update
   ```

### 📞 Soporte

Para soporte técnico o preguntas:
- Crear un issue en el repositorio
- Contactar al equipo de desarrollo

---

**¡Gracias por usar BackInovationMap! 🚀**
