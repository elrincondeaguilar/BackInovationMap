# Configuración de Supabase

## ✅ Configuración Actual

Tu aplicación está configurada para conectarse a Supabase con las siguientes credenciales:

- **Host**: aws-0-us-east-2.pooler.supabase.com
- **Puerto**: 5432
- **Base de datos**: postgres
- **Usuario**: postgres.jsddkeyspzigizepdvoy
- **Contraseña**: Ide0qDV5AJeb83wL

## 🚀 Para Ejecutar la Aplicación

```bash
# 1. Compilar
dotnet build

# 2. Aplicar migraciones (ya aplicadas)
dotnet ef database update

# 3. Ejecutar
dotnet run
```

## 📋 Migraciones Aplicadas

- ✅ InitialCreate - Tablas básicas
- ✅ AddEstadoManualToConvocatoria - Campo EstadoManual

## 🔒 Seguridad

- Las credenciales están en `appsettings.json` y `appsettings.Development.json`
- Para producción, considera usar variables de entorno
- El archivo `.gitignore` debe proteger archivos con credenciales sensibles

## 🧪 Probar la Conexión

Después de ejecutar `dotnet run`, puedes probar:

1. **GET** `http://localhost:5297/api/companies` - Listar empresas
2. **GET** `http://localhost:5297/api/convocatorias` - Listar convocatorias
3. **POST** `http://localhost:5297/api/auth/register` - Registrar usuario

## ⚠️ Notas Importantes

- Supabase usa PostgreSQL, toda la configuración EF Core es compatible
- El pooler de Supabase maneja las conexiones automáticamente
- Todas las funcionalidades del backend (autenticación, CRUD, estado manual) están funcionando
