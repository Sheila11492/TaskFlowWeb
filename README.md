# TaskFlowWeb 🗂️✅

TaskFlowWeb es una aplicación web desarrollada con **ASP.NET Core MVC en C#**, creada para la **gestión y control de proyectos y tareas personales**.

El objetivo del proyecto es disponer de una herramienta sencilla y clara para organizar proyectos, asignar tareas y hacer seguimiento de su estado desde un único dashboard.

Este proyecto forma parte de mi **portfolio personal** como desarrolladora junior y ha sido desarrollado de principio a fin aplicando buenas prácticas de arquitectura MVC.

---

## 🚀 Funcionalidades principales

- Gestión de **Proyectos** (CRUD completo)
- Gestión de **Tareas** asociadas a proyectos (CRUD completo)
- Dashboard principal con:
  - Número total de proyectos
  - Número total de tareas
  - Tareas pendientes y en progreso
- Arquitectura MVC clara y estructurada
- Interfaz sencilla y enfocada a la usabilidad
- Relación proyectos–tareas
- Dashboard con estadísticas
- Base de datos SQLite con Entity Framework Core


---

## 🛠️ Tecnologías utilizadas

- **C#**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQLite**
- **Razor Views**
- **HTML / CSS**
- **Bootstrap**
- **Git & GitHub**

---

## 🧱 Arquitectura del proyecto

El proyecto sigue el patrón **Model–View–Controller (MVC)**, separando claramente responsabilidades entre capas:
- Presentación (Views)
- Controladores
- Modelos / ViewModels
- Acceso a datos

### 📂 Estructura del proyecto

TaskFlowWeb/
│
├─ Controllers/                 <-- Controladores MVC
│   ├─ HomeController.cs        <-- Dashboard / Home
│   ├─ ProjectsController.cs    <-- CRUD de Proyectos
│   └─ TasksController.cs       <-- CRUD de Tareas
│
├─ Data/
│   └─ AppDbContext.cs          <-- Contexto de Entity Framework Core
│
├─ Models/                      <-- Modelos de datos
│   ├─ Project.cs               <-- Modelo Proyecto
│   ├─ TaskItem.cs              <-- Modelo Tarea
│   ├─ ErrorViewModel.cs        <-- Modelo de Error genérico
│   └─ ViewModels/
│       └─ DashboardViewModel.cs <-- Modelo para dashboard/home
│
├─ Views/                       <-- Vistas Razor
│   ├─ Shared/
│   │   ├─ _Layout.cshtml       <-- Layout principal
│   │   ├─ _ValidationScriptsPartial.cshtml
│   │   ├─ Error.cshtml
│   │   └─ _Layout.cshtml.css
│   │
│   ├─ Home/
│   │   ├─ Index.cshtml         <-- Dashboard
│   │   └─ Privacy.cshtml
│   │
│   ├─ Projects/                <-- Vistas CRUD Proyectos
│   │   ├─ Index.cshtml
│   │   ├─ Create.cshtml
│   │   ├─ Edit.cshtml
│   │   ├─ Details.cshtml
│   │   └─ Delete.cshtml
│   │
│   └─ Tasks/                   <-- Vistas CRUD Tareas
│       ├─ Index.cshtml
│       ├─ Create.cshtml
│       ├─ Edit.cshtml
│       ├─ Details.cshtml
│       └─ Delete.cshtml
│
├─ wwwroot/                     <-- Archivos estáticos
│   ├─ css/
│   │   ├─ site.css
│   │   └─ TaskFlowWeb.styles.css
│   ├─ js/
│   │   └─ site.js
│   ├─ images/
│   │   └─ logo.png
│   ├─ lib/                     <-- Bootstrap, jQuery, jQuery-validation
│   └─ favicon.ico
│
├─ appsettings.json
├─ appsettings.Development.json
├─ Program.cs                   <-- Configuración principal
├─ TaskFlowWeb.csproj
├─ TaskFlowWeb.sln
├─ taskflow.db                  <-- Base de datos SQLite
├─ taskflow.db-shm
├─ taskflow.db-wal
└─ TaskFlowWeb.db

---

## 🧪 Base de datos

- **SQLite**
- Gestión mediante **Entity Framework Core**
- Base de datos local incluida para pruebas y desarrollo

---

## 📌 Objetivo del proyecto

Este proyecto ha sido desarrollado para:

- Practicar el desarrollo web con **ASP.NET Core MVC**
- Aplicar arquitectura MVC de forma real
- Gestionar proyectos y tareas personales
- Formar parte de mi **portfolio profesional como desarrolladora junior**

---

## 👩‍💻 Autora

**Sheila**  
Desarrolladora Junior  

📌 Proyecto desarrollado como parte de mi aprendizaje y portfolio personal.

---

## 📄 Licencia

Este proyecto se distribuye con fines educativos y personales.
