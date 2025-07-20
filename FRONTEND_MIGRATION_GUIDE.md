# 🔄 Cambios Necesarios en el Frontend (Next.js)

## 📋 Resumen de Cambios en el Backend

Se han agregado nuevas entidades y campos extendidos al backend .NET:

### 🆕 **Nuevas Entidades (Nuevos Endpoints)**
1. **Promotores** - `/api/promotores`
2. **Articuladores** - `/api/articuladores`

### 🔧 **Entidades Extendidas (Endpoints Existentes)**
1. **Companies** - `/api/companies` (campos adicionales)
2. **Convocatorias** - `/api/convocatorias` (campos adicionales)

---

## 🚀 **1. Nuevos Endpoints Disponibles**

### **Promotores**
```typescript
// GET /api/promotores
// GET /api/promotores/{id}
// POST /api/promotores
// PUT /api/promotores/{id}
// DELETE /api/promotores/{id}
// GET /api/promotores/health

interface Promotor {
  id: number;
  medio?: string;          // max 200 chars
  descripcion?: string;    // text
  enlace?: string;         // text
  createdAt: string;       // ISO date
  updatedAt: string;       // ISO date
}
```

### **Articuladores**
```typescript
// GET /api/articuladores
// GET /api/articuladores/{id}
// POST /api/articuladores
// PUT /api/articuladores/{id}
// DELETE /api/articuladores/{id}
// GET /api/articuladores/health

interface Articulador {
  id: number;
  nombre: string;          // required, max 200 chars
  tipo?: string;           // max 100 chars
  region?: string;         // max 100 chars
  contacto?: string;       // text
  createdAt: string;       // ISO date
  updatedAt: string;       // ISO date
}
```

---

## 🔧 **2. Endpoints Extendidos (Cambios en Interfaces)**

### **Companies** (✅ COMPATIBLE - Campos Opcionales)
```typescript
// Endpoints existentes: GET/POST/PUT/DELETE /api/companies
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

### **Convocatorias** (✅ COMPATIBLE - Campos Opcionales)
```typescript
// Endpoints existentes: GET/POST/PUT/DELETE /api/convocatorias
interface Convocatoria {
  id: number;
  title: string;           // existing
  description: string;     // existing
  estado: string;          // existing
  categoria: string;       // existing
  fechaInicio: string;     // existing
  fechaFin: string;        // existing
  presupuesto: number;     // existing
  requisitos: string[];    // existing
  companyId?: number;      // existing
  company?: Company;       // existing
  createdAt: string;       // existing
  updatedAt: string;       // existing
  
  // 🆕 NUEVOS CAMPOS (todos opcionales)
  enlace?: string;         // ⚠️ NUEVO - enlace/URL
  clasificacion?: string;  // ⚠️ NUEVO - clasificación
  lineaOportunidad?: string; // ⚠️ NUEVO - línea de oportunidad
  palabrasClave?: string;  // ⚠️ NUEVO - palabras clave
  fechaApertura?: string;  // ⚠️ NUEVO - fecha de apertura
  fechaCierre?: string;    // ⚠️ NUEVO - fecha de cierre
}
```

---

## ✅ **3. Compatibilidad y Migración**

### **🎯 Impacto Mínimo en el Frontend Existente**
- ✅ **Todos los endpoints existentes siguen funcionando igual**
- ✅ **Los nuevos campos son opcionales**
- ✅ **No hay cambios breaking en las APIs existentes**
- ✅ **Las interfaces existentes se pueden extender gradualmente**

### **📋 Acciones Requeridas en el Frontend:**

#### **Inmediatas (Críticas):**
1. **✅ NINGUNA** - El frontend actual seguirá funcionando sin cambios

#### **Opcionales (Mejoras):**
1. **Extender interfaces TypeScript** para incluir los nuevos campos
2. **Actualizar formularios** para incluir los nuevos campos si es necesario
3. **Crear páginas/componentes** para las nuevas entidades si se requieren

---

## 🔧 **4. Implementación Sugerida**

### **Paso 1: Extender Interfaces (Opcional)**
```typescript
// types/api.ts
interface Company {
  // ... campos existentes
  tipoActor?: string;
  ciudad?: string;
  direccion?: string;
  contacto?: string;
  latitud?: number;
  longitud?: number;
}

interface Convocatoria {
  // ... campos existentes
  enlace?: string;
  clasificacion?: string;
  lineaOportunidad?: string;
  palabrasClave?: string;
  fechaApertura?: string;
  fechaCierre?: string;
}
```

### **Paso 2: Crear Servicios para Nuevas Entidades (Opcional)**
```typescript
// services/promotoresService.ts
export const promotoresService = {
  getAll: () => fetch('/api/promotores').then(r => r.json()),
  getById: (id: number) => fetch(`/api/promotores/${id}`).then(r => r.json()),
  create: (data: Partial<Promotor>) => 
    fetch('/api/promotores', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(data)
    }).then(r => r.json()),
  // ... etc
};
```

### **Paso 3: Actualizar Formularios (Opcional)**
```typescript
// Solo si necesitas capturar los nuevos campos
<input name="tipoActor" placeholder="Tipo de Actor" />
<input name="ciudad" placeholder="Ciudad" />
<input name="direccion" placeholder="Dirección" />
// etc...
```

---

## 🎯 **5. Casos de Uso**

### **Si NO necesitas las nuevas entidades:**
- ✅ **No hagas nada** - tu frontend seguirá funcionando perfectamente

### **Si necesitas mostrar los nuevos campos:**
1. Actualiza las interfaces TypeScript
2. Modifica los componentes que muestran la información

### **Si necesitas CRUD para las nuevas entidades:**
1. Crea servicios API
2. Crea componentes/páginas
3. Agrega rutas en el router

---

## 📊 **6. Testing de Compatibilidad**

### **Verificar que el frontend actual funciona:**
```bash
# En el frontend Next.js
npm run dev
```

### **Verificar endpoints existentes:**
- ✅ `GET /api/companies` - debe seguir funcionando
- ✅ `GET /api/convocatorias` - debe seguir funcionando
- ✅ Los datos existentes aparecen normalmente
- ✅ Los nuevos campos aparecen como `null` o `undefined` (esperado)

### **Probar nuevos endpoints (opcional):**
- 🆕 `GET /api/promotores` - debe retornar array vacío
- 🆕 `GET /api/articuladores` - debe retornar array vacío

---

## 🚨 **7. Consideraciones Importantes**

### **Base de datos:**
- ✅ Las nuevas columnas se agregaron como `NULL` (no afecta datos existentes)
- ✅ Las nuevas tablas están vacías (no impactan rendimiento)

### **Performance:**
- ✅ Los endpoints existentes no cambiaron en rendimiento
- ✅ Los nuevos campos opcionales no afectan el tamaño de respuesta significativamente

### **Versionado:**
- ✅ No hay versionado de API necesario (backward compatible)
- ✅ Los clientes antiguos siguen funcionando

---

## 📋 **8. Checklist de Migración**

### **Verificación Inmediata:**
- [ ] ✅ El frontend actual compila sin errores
- [ ] ✅ Las páginas existentes cargan correctamente
- [ ] ✅ Los formularios existentes funcionan
- [ ] ✅ Los datos se muestran correctamente

### **Mejoras Opcionales:**
- [ ] Actualizar interfaces TypeScript
- [ ] Extender formularios para capturar nuevos campos
- [ ] Crear componentes para nuevas entidades
- [ ] Agregar validaciones para nuevos campos
- [ ] Actualizar documentación del frontend

---

## 🎯 **Conclusión**

**✅ Tu frontend de Next.js seguirá funcionando sin cambios.**

Los nuevos modelos y campos son completamente opcionales y backward-compatible. Puedes:

1. **Continuar trabajando normalmente** sin hacer cambios
2. **Agregar funcionalidad gradualmente** según necesites
3. **Aprovechar las nuevas entidades** cuando las requieras

**No hay urgencia ni cambios breaking que requieran atención inmediata.**
