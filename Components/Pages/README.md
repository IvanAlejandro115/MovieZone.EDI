# 🎬 MovieZone - Portal de Streaming Multimedia

¡Bienvenido al repositorio oficial de **MovieZone**! Este proyecto es una plataforma interactiva de simulación de streaming inspirada en las interfaces modernas de Plex y Netflix. Ha sido desarrollado como el **Proyecto Integrador Final**, cubriendo de forma estricta los requerimientos prácticos y teóricos de las cuatro unidades de la materia.

---

## 🏛️ 1. Arquitectura y Componentes Blazor (Unidad 1)
La aplicación está construida sobre **Blazor Server (.NET 9)**, implementando una arquitectura modular basada en componentes Razor totalmente desacoplados y reutilizables:
- **Estructura Fija (`MainLayout.razor`):** Mantiene una barra de navegación lateral responsive e interactiva.
- **Vistas Dinámicas (`Pages/`):** El sistema procesa y renderiza de forma independiente las pantallas de `Inicio`, `Películas`, `Estrenos`, `Noticias` y `Mi Colección`.
- **Enrutamiento Dinámico:** Se implementó el pasaje de parámetros complejos a través de la URL mediante la directiva `@page "/noticia/{urlNoticia}"`, permitiendo que una sola vista extendida consuma datos variables de C# de forma automatizada.

## 📝 2. Formularios y Validaciones Avanzadas (Unidad 1 y 3)
La sección **"Mi Colección"** (`MiColeccion.razor`) cuenta con un sistema robusto de gestión de datos:
- Implementación de la etiqueta inteligente `<EditForm>` vinculada bidireccionalmente a un modelo de C#.
- Validación avanzada del lado del servidor mediante **Data Annotations** (`[Required]`, `[StringLength]`).
- Renderizado inmediato de alertas técnicas en tiempo real en la interfaz del usuario utilizando componentes `<ValidationMessage>`.

## 🎨 3. Interfaz Visual Semántica y Responsive (Unidad 2)
El maquetado web se diseñó bajo los estándares de la experiencia de usuario (UX/UI) comercial:
- **HTML5 Semántico:** Uso estricto de bloques estructurales (`<header>`, `<main>`, `<article>`) evitando la redundancia de contenedores genéricos.
- **Maquetado Adaptativo:** Distribución fluida mediante **CSS Grid nativo** (`repeat(3, 1fr)`) y Flexbox para garantizar la compatibilidad multi-dispositivo (Mobile-First).
- **JS Interop:** Consumo asincrónico de la librería de JavaScript nativa del navegador mediante la inyección de `IJSRuntime` para disparar la función `history.back()` en los botones de retorno de prensa.

## 🗄️ 4. Persistencia de Datos con EF Core (Unidad 3)
La plataforma abandonó el almacenamiento en memoria volátil para implementar un motor persistente profesional:
- **Enfoque Code-First:** Creación de contextos de datos mediante una clase `AppDbContext` que hereda de `DbContext`.
- **Base de Datos SQLite:** Persistencia física real sobre el archivo local de base de datos `peliculas.db`.
- **Ciclo CRUD Avanzado:** Lógica integrada a través de operaciones asincrónicas con Entity Framework Core que permiten el **Alta** (Create), **Lectura** (Read con LINQ), **Modificación** (Update vía `.Update()`) y **Baja** (Delete vía `.Remove()`).
- **Búsqueda y Paginación:** Consultas inteligentes optimizadas con sentencias LINQ utilizando operadores `.Where()`, `.Contains()`, `.Skip()` y `.Take()` para paginar el catálogo de 3 en 3.

---

## 🛠️ Guía de Instalación y Despliegue Local (Para el Profesor)

Para ejecutar este proyecto en su entorno de desarrollo local, siga estos comandos ordenados dentro de la terminal de Visual Studio Code:

1. **Restaurar dependencias y paquetes NuGet:**
   ```bash
   dotnet restore
   ```
2. **Instalar la herramienta global de Entity Framework (Si no la posee):**
   ```bash
   dotnet tool install --global dotnet-ef --version 9.0.0
   ```
3. **Compilar y aplicar las migraciones de la Base de Datos SQLite:**
   ```bash
   dotnet ef database update
   ```
4. **Ejecutar la aplicación en modo de escucha activa (Hot Reload):**
   ```bash
   dotnet watch
   ```

La plataforma se abrirá de forma automática en su navegador en la dirección local estándar: `http://localhost:5032`
