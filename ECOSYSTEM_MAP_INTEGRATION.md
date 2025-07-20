# 🗺️ Integración del Mapa del Ecosistema - Backend

## 🎯 **Objetivo**
Integrar todas las entidades del ecosistema de innovación (Companies, Promotores, Articuladores) en un mapa interactivo unificado con capacidades de filtrado avanzado.

---

## 🆕 **Nuevas Funcionalidades Implementadas**

### 1️⃣ **Campos Geográficos Agregados**

Todas las entidades ahora incluyen campos para visualización en mapa:

#### **Promotor**
```typescript
interface Promotor {
  // ... campos existentes
  ciudad?: string;        // 🆕 NUEVO - Ciudad
  departamento?: string;  // 🆕 NUEVO - Departamento  
  latitud?: number;       // 🆕 NUEVO - Coordenada latitud
  longitud?: number;      // 🆕 NUEVO - Coordenada longitud
}
```

#### **Articulador**
```typescript
interface Articulador {
  // ... campos existentes
  ciudad?: string;        // 🆕 NUEVO - Ciudad
  departamento?: string;  // 🆕 NUEVO - Departamento
  latitud?: number;       // 🆕 NUEVO - Coordenada latitud
  longitud?: number;      // 🆕 NUEVO - Coordenada longitud
}
```

### 2️⃣ **Modelo Unificado del Ecosistema**

```typescript
interface EcosystemMapItem {
  id: number;
  type: "Company" | "Promotor" | "Articulador";
  name: string;
  description?: string;
  category?: string;
  sector?: string;
  ciudad?: string;
  departamento?: string;
  latitud?: number;
  longitud?: number;
  contacto?: string;
  enlace?: string;
  logoUrl?: string;
  metadata: Record<string, any>;  // Datos específicos por tipo
  createdAt: string;
  updatedAt: string;
}
```

---

## 🚀 **Nuevos Endpoints del Mapa**

### **Endpoint Principal del Ecosistema**
```
GET /api/ecosystemmap
```
**Descripción:** Obtiene todos los elementos del ecosistema con coordenadas geográficas  
**Respuesta:** Array de `EcosystemMapItem`

### **Endpoint con Filtros Avanzados**
```
GET /api/ecosystemmap/filtered?types=Company,Promotor&departamento=Antioquia&ciudad=Medellin
```
**Parámetros de consulta:**
- `types`: Tipos a incluir (`Company`, `Promotor`, `Articulador`)
- `departamento`: Filtrar por departamento
- `ciudad`: Filtrar por ciudad
- `sector`: Filtrar por sector (solo Companies)
- `categoria`: Filtrar por categoría

### **Opciones de Filtros Disponibles**
```
GET /api/ecosystemmap/filter-options
```
**Respuesta:**
```json
{
  "types": ["Company", "Promotor", "Articulador"],
  "departamentos": ["Antioquia", "Cundinamarca", ...],
  "ciudades": ["Medellín", "Bogotá", "Cali", ...],
  "sectores": ["Tecnología", "Salud", ...],
  "categorias": ["Startup", "Universidad", ...]
}
```

### **Estadísticas del Ecosistema**
```
GET /api/ecosystemmap/stats
```
**Respuesta:**
```json
{
  "total": 135,
  "byType": {
    "Company": 80,
    "Promotor": 25,
    "Articulador": 30
  },
  "byDepartamento": {
    "Antioquia": 60,
    "Cundinamarca": 45,
    "Valle del Cauca": 25
  },
  "withCoordinates": 120,
  "withoutCoordinates": 30
}
```

### **Health Check**
```
GET /api/ecosystemmap/health
```

---

## 🔧 **Implementación Técnica**

### **Servicio de Mapa del Ecosistema**
```csharp
public interface IEcosystemMapService
{
    Task<List<EcosystemMapItem>> GetAllEcosystemItemsAsync();
    Task<List<EcosystemMapItem>> GetFilteredEcosystemItemsAsync(
        List<string>? types = null,
        string? departamento = null,
        string? ciudad = null,
        string? sector = null,
        string? categoria = null
    );
}
```

### **Controlador Unificado**
- `EcosystemMapController` maneja toda la lógica del mapa
- Integra datos de múltiples entidades
- Proporciona filtrado avanzado
- Incluye estadísticas y metadatos

---

## 🎨 **Casos de Uso para el Frontend**

### **1. Mapa Completo del Ecosistema**
```javascript
// Mostrar todos los elementos en el mapa
const ecosystemData = await fetch('/api/ecosystemmap').then(r => r.json());

// Cada item tiene:
// - Coordenadas (latitud, longitud)
// - Tipo diferenciado (Company, Promotor, etc.)
// - Información completa para popups
```

### **2. Filtrado Interactivo**
```javascript
// Filtrar solo empresas y promotores en Medellín
const filtered = await fetch('/api/ecosystemmap/filtered?types=Company,Promotor&ciudad=Medellín')
  .then(r => r.json());

// Cambiar filtros dinámicamente
const onFilterChange = async (filters) => {
  const params = new URLSearchParams(filters);
  const data = await fetch(`/api/ecosystemmap/filtered?${params}`).then(r => r.json());
  updateMap(data);
};
```

### **3. Opciones de Filtro Dinámicas**
```javascript
// Poblar selectores de filtro
const options = await fetch('/api/ecosystemmap/filter-options').then(r => r.json());

// Crear dropdowns dinámicamente
options.departamentos.forEach(dept => {
  // Agregar a selector de departamentos
});
```

### **4. Dashboard y Estadísticas**
```javascript
// Mostrar estadísticas del ecosistema
const stats = await fetch('/api/ecosystemmap/stats').then(r => r.json());

// Crear gráficos con:
// - Total por tipo
// - Distribución geográfica
// - Cobertura de coordenadas
```

---

## 🗺️ **Estructura de Datos por Tipo**

### **Companies en el Mapa**
```json
{
  "id": 1,
  "type": "Company",
  "name": "TechCorp",
  "description": "Empresa de tecnología",
  "category": "Tecnología",
  "sector": "Software",
  "ciudad": "Medellín",
  "departamento": "Antioquia",
  "latitud": 6.2442,
  "longitud": -75.5812,
  "logoUrl": "https://...",
  "metadata": {
    "tipoActor": "Empresa",
    "direccion": "Calle 123"
  }
}
```

### **Promotores en el Mapa**
```json
{
  "id": 2,
  "type": "Promotor",
  "name": "Radio Innovación",
  "description": "Medio radial de promoción",
  "category": "Medio de Promoción",
  "ciudad": "Bogotá",
  "departamento": "Cundinamarca",
  "latitud": 4.7110,
  "longitud": -74.0721,
  "metadata": {
    "medio": "Radio"
  }
}
```

---

## 📊 **Beneficios de la Integración**

### **Para el Usuario Final:**
✅ **Vista unificada** de todo el ecosistema  
✅ **Filtrado intuitivo** por múltiples criterios  
✅ **Información contextual** en cada punto del mapa  
✅ **Navegación fluida** entre diferentes tipos de actores  

### **Para el Desarrollo:**
✅ **API consistente** para todos los tipos de entidades  
✅ **Filtrado eficiente** a nivel de base de datos  
✅ **Escalabilidad** para agregar nuevos tipos  
✅ **Mantenimiento simplificado** con un solo endpoint  

---

## 🔄 **Migración de Base de Datos**

La migración `AddGeographicFieldsForMapIntegration` agrega los campos necesarios:

```sql
-- Promotores
ALTER TABLE "Promotores" ADD "Ciudad" character varying(100);
ALTER TABLE "Promotores" ADD "Departamento" character varying(100);
ALTER TABLE "Promotores" ADD "Latitud" numeric;
ALTER TABLE "Promotores" ADD "Longitud" numeric;

-- Articuladores  
ALTER TABLE "Articuladores" ADD "Ciudad" character varying(100);
ALTER TABLE "Articuladores" ADD "Departamento" character varying(100);
ALTER TABLE "Articuladores" ADD "Latitud" numeric;
ALTER TABLE "Articuladores" ADD "Longitud" numeric;

-- PortafoliosArco
ALTER TABLE "PortafoliosArco" ADD "Ciudad" character varying(100);
ALTER TABLE "PortafoliosArco" ADD "Latitud" numeric;
ALTER TABLE "PortafoliosArco" ADD "Longitud" numeric;
```

---

## ✅ **Estado de Implementación**

✅ Modelos actualizados con campos geográficos  
✅ Servicio de mapa del ecosistema implementado  
✅ Controlador unificado creado  
✅ Endpoints de filtrado configurados  
✅ Migración de base de datos aplicada  
✅ Servicio registrado en DI container  

**🎯 El backend está listo para la integración del mapa unificado en el frontend.**
