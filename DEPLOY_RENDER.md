# 🚀 Despliegue en Render

## Configuración para Render

### 📋 Información para el formulario de Render:

**🔧 Configuración Básica:**
- **Repository**: `https://github.com/elrincondeaguilar/BackInovationMap`
- **Branch**: `main`
- **Root Directory**: `.` (punto)
- **Environment**: `Docker`
- **Region**: `Oregon (US West)`
- **Instance Type**: `Free` (para empezar)

**⚡ Start Command (muy importante):**
```
dotnet BackInovationMap.dll
```

**🌐 Variables de Entorno (Environment Variables):**

| Key | Value |
|-----|-------|
| `ASPNETCORE_ENVIRONMENT` | `Production` |
| `ASPNETCORE_URLS` | `http://0.0.0.0:$PORT` |
| `ConnectionStrings__DefaultConnection` | `Host=aws-0-us-east-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.jsddkeyspzigizepdvoy;Password=Ide0qDV5AJeb83wL` |

**🏥 Health Check:**
- **Health Check Path**: `/api/companies`

## 📋 Pasos de Despliegue:

### 1. Conectar Repositorio
1. Ve a [render.com](https://render.com) y registra/inicia sesión
2. Click en "New +" → "Web Service"
3. Conecta tu cuenta de GitHub
4. Selecciona el repositorio `BackInovationMap`

### 2. Configurar el Servicio
```
Name: backinovationmap
Region: Oregon (US West)
Branch: main
Root Directory: . 
Runtime: Docker
```

### 3. Configurar Start Command
**En el campo "Start Command":**
```
dotnet BackInovationMap.dll
```

### 4. Agregar Variables de Entorno
Ir a "Environment" y agregar:

```
ASPNETCORE_ENVIRONMENT = Production
ASPNETCORE_URLS = http://0.0.0.0:$PORT
ConnectionStrings__DefaultConnection = Host=aws-0-us-east-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.jsddkeyspzigizepdvoy;Password=Ide0qDV5AJeb83wL
```

### 5. Configurar Health Check
```
Health Check Path: /api/companies
```

### 6. Deploy!
Click en "Create Web Service"

## 🔗 URLs después del despliegue:

- **API Base**: `https://tu-app-name.onrender.com`
- **Swagger UI**: `https://tu-app-name.onrender.com/swagger`
- **Test Endpoint**: `https://tu-app-name.onrender.com/api/companies`

## ⚠️ Importante:

1. **El primer despliegue toma 5-10 minutos**
2. **La app puede "dormirse" en el plan gratuito** (se reactiva en ~30 segundos)
3. **La base de datos Supabase ya está configurada** ✅
4. **Render automáticamente ejecutará las migraciones** si es necesario

## 🧪 Probar después del despliegue:

```bash
# Probar que la API responde
curl https://tu-app-name.onrender.com/api/companies

# Registrar un usuario
curl -X POST "https://tu-app-name.onrender.com/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "nombre": "Test",
    "apellido": "User",
    "email": "test@test.com",
    "password": "Test123!",
    "confirmPassword": "Test123!"
  }'
```

## 🔄 Actualizaciones automáticas:

Cada vez que hagas `git push` a la rama `main`, Render automáticamente:
1. Detecta los cambios
2. Construye la nueva imagen Docker
3. Despliega la nueva versión
4. ¡Tu API se actualiza automáticamente! 🎉
