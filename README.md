# 🚚 Move Solutions – Sistema Integral de Gestión de Mudanzas

Bienvenido a **Move Solutions**, una aplicación de escritorio moderna que transforma radicalmente la gestión, coordinación y control del negocio de mudanzas. Digitaliza y automatiza todos los procesos operativos, administrativos y logísticos de una empresa de mudanzas, garantizando eficiencia, trazabilidad y seguridad.

---

## 📘 Descripción General

Move Solutions está desarrollada en **C# / Visual Basic .NET** usando **WinForms**, **Entity Framework Core** y **SQL Server**, bajo una robusta **arquitectura en capas (GUI – BLL – DAL – Entidades)**. Permite la gestión integral de clientes, empleados, vehículos, mudanzas, inventarios, pagos, facturación y reportes mediante una interfaz intuitiva y confiable.

---

## 🎯 Propósito del Sistema

¿Los procesos de tu empresa de mudanzas son manuales, dispersos o poco organizados? Move Solutions resuelve estos problemas centralizando toda la información y automatizando tareas críticas:

- Planificación de mudanzas y asignación de recursos
- Seguimiento en tiempo real del progreso por etapas (“checkpoints”)
- Control inteligente de inventario transportado
- Facturación automatizada y gestión de pagos
- Reportes gerenciales y estadísticos en segundos

---

## 🧩 Principales Problemas que Soluciona

- Mala coordinación de empleados y vehículos
- Seguimiento deficiente del progreso de cada mudanza
- Riesgo de errores y pérdida de información por inventarios manuales
- Procesos dispersos de pago y facturación
- Problemas de trazabilidad ante incidencias

---

## 🚀 Funciones Principales

### Gestión de Clientes
- Registrar, editar, consultar historial de mudanzas

### Gestión de Empleados
- Registro, edición, disponibilidad, y asignación

### Gestión de Vehículos
- Registro, estado (activo/mantenimiento), y asignación

### Gestión de Mudanzas
- Creación, asignación de recursos, origen/destino, seguimiento por estados

### Inventario Transportado
- Control por ítem, cantidad, descripción y valor

### Checkpoints
- Seguimiento detallado por etapas, horas previstas/real, coordenadas

### Facturación y Pagos
- Facturas automáticas, registro de pagos (efectivo, transferencia, tarjeta)

### Incidencias
- Registro, seguimiento y resolución de problemas por mudanza

### Reportes
- Exportación y gestión de reportes por fecha, estado y cliente

---

## 🏗 Arquitectura del Sistema

- **GUI:** Formularios WinForms
- **BLL (Business Logic Layer):** Lógica de negocio y servicios
- **DAL (Data Access Layer):** Acceso/gestión de datos con EF Core
- **Entidades:** Modelos/tablas del sistema
- **Migraciones:** Versionado y estructura de base de datos

---

## 🗄 Base de Datos

Incluye modelos para:
- Cliente
- Empleado
- Vehículo
- Mudanza
- Inventario
- Checkpoint
- Factura
- Pago
- Incidencia
- Usuario y Rol

Con relaciones, restricciones, contraseñas cifradas y control de roles.

---

## 📊 Ventajas del Sistema

- Disminuye errores humanos y mejora la coordinación
- Centraliza la información para máxima trazabilidad
- Automatiza tareas, reportes y procesos administrativos
- Facilita el mantenimiento y la escalabilidad
- Transforma procesos tradicionales en experiencias digitales

---

## 🖥 Tecnologías Utilizadas

- C# / Visual Basic .NET
- WinForms
- SQL Server
- Entity Framework Core
- Arquitectura N-Capas

---

## 🧪 Pruebas Funcionales

Incluye plan de pruebas con más de 20 casos:
- Login y seguridad
- Clientes, empleados y vehículos
- Mudanzas e inventarios
- Incidencias y resolución
- Facturación y reportes

---

## ⚡ Instalación

1. Clona este repositorio:  
   `git clone https://github.com/naiferrosado/ProyectoMoveSolutions.git`
2. Configura la base de datos SQL Server y actualiza la cadena de conexión en el proyecto.
3. Restaura los paquetes NuGet y ejecuta las migraciones (EF Core).
4. Compila y ejecuta la aplicación desde Visual Studio.

---

## 👩‍💻 Uso Básico

1. Inicia sesión como usuario autorizado.
2. Accede a los módulos desde el menú principal.
3. Gestiona clientes, empleados, vehículos y mudanzas.
4. Realiza seguimiento, genera reportes y controla facturación.

---

## 👥 Autores

- **Naifer Alberto Rosado Pérez**
- **Maifer Ariel Feliz Acosta**
- **Stiben Peña Méndez**
- **Marlin José Feliz Sena**

