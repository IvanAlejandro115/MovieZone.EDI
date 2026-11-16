# 🎬 MovieZone - Portal de Streaming Multimedia

¡Bienvenido al repositorio oficial de **MovieZone**! Este proyecto es una plataforma interactiva de simulación de streaming inspirada en las interfaces modernas de Plex y Netflix. Ha sido desarrollado como el **Proyecto Integrador Final**, cubriendo los requerimientos prácticos y teóricos de las cuatro unidades de la asignatura.

---

## Aspectos Técnicos Destacados por Unidad

### Unidad 1 – Componentes Blazor y Arquitectura
- **1. Componentes Encapsulados:** Arquitectura modular desacoplada en Razor   
   (`MainLayout`, `NavMenu`, `Home`, `MiColeccion`, `CartelError`, etc.). 
  - muestra 16 peliculas encapsuladas en targetas con su imagen, titulo, y mediante 
    direccion url, que se vuelven a usar en las demas page. utiliza bloques code y 
    estiquetas para mostrarlas en orden y encapsuladas. estas se guardan en la bd y se reutilizan en las demas page mediante SQLITE, que las almacena y guarda su  ruta. luego las paginas las llaman por medio de la bd, para mostarlas y volver a usarlas. 

    *CartelError.Razor* es una pagina aparte que se llama desde otras paginas para mostrar un error, por medio de el enrutamiento de blazor "navigationmanager" en las page Micoleccion y peliculas. 
   -

 **2. formularios editform y validaciones avanzadas:** Micoleccion usa editform para 
      conectarse bidireccionalmente con los modelos C#, y gestionar el envio y 
      Validacion de datos. asi asegura que solo se ejecute si el usuario completo los 
      campos. 
      Validaciones: usa atributos como required (obligatorio) y Stringletght(30) para limitar cantidad.
      Tambien incluye validaciones personalizadas como que verifique los datos ingresados y busquedas coincidan con el catalgo de peliculas. tambien usa 
   -

 **3. Routing con parametros y navegacion programatica:** 
   - * En C# de Home y Coleccion, usa Navigationmanger.NavigateTo(...) para hacer el 
       enrrutamiento y llamada con CartelError.Razor, para mostrar un error. 
     * Usa la configuracion directiva al inicio en CartelError.Razor: @page"/
       cartel-error/{mensageerror} para capturar el parametro url y mostrar el mensaje   
       personalizado segun la pagina. 
   - 

 **4. State Service con notificación reactiva:** Gestionamos el estado de la aplicación:     
  -  mediante un servicio inyectado (State Service) que notifica a los componentes 
     cuando los datos cambian, desencadenando la actualización automática y reactiva    
     de la interfaz sin necesidad de recargar la página. Mediante 
  -

### Unidad 2 – Interfaz Visual y UX
- **Bootstrap 5.3 Local:** Estilos integrados físicamente dentro de la carpeta 
   `wwwroot/
   css/bootstrap.min.css` para garantizar independencia de internet y funcionamiento *offline*.
-

- 1. **HTML5 Semántico y CSS Isolation:** La estructura principal (MainLayout.razor y 
   las páginas) utiliza etiquetas estructurales con significado semántico como "header" para la barra superior, <"nav"> para el menú lateral NavMenu.razor, "main" para el contenedor central de contenido y "article" o "section" para los bloques de películas y detalles.
-
- 2. **CSS Isolation en al menos 3 componentes:** aplica en componentes clave como:
    "MainLayout.razor.css" (estilos específicos del layout principal).
    "NavMenu.razor.css" (estilos aislados para la barra lateral y los enlaces).
    "Home.razor" o MiColeccion.razor (estilos para las grillas de películas o el 
     formulario)
     use css en Mainlayout, Navmenu, y MiColeccion, para que cada cada uno encapsule su diseño visual en los menus aislados en forma de cuadro.
-
-
 3. **JS Interop al menos una funcionalidad que requiera JavaScript:** use la interfaz 
   de Blazor "@inject IJSRuntime JSRuntime" al inicio en "CartelError.razor".
   Lo utilize para llamar funciones del navegador desde C#, por ejemplo disparando history.back() en el botón de la vista de error (CartelError.razor) para devolver al usuario a la pantalla anterior sin romper el flujo de navegación.
-


###  Unidad 3 – Persistencia de Datos
- **Entity Framework Core & SQLite:** Persistencia física real sobre la base de datos 
   `peliculas.db` utilizando el enfoque *Code-First*.
- **Operaciones CRUD:** Operaciones completas de creación, lectura, edición y borrado 
   de películas en la sección **Mi Colección**.
- **Búsqueda y Paginación:** Consultas optimizadas con sentencias LINQ (`.Where()`, `.
   Contains()`, `.Skip()`, `.Take()`).


   **1. Ef Core con SQLITE, DBContextFctory:** Cumplimos con el requisito de la Unidad 3 integrando una base de datos SQLite almacenada en el archivo físico peliculas.db. Para interactuar con ella, utilizamos Entity Framework Core, lo que nos permite gestionar las entidades y las operaciones CRUD de forma limpia mediante C#. De esa forma, implementamos DbContextFactory para asegurar que las consultas y modificaciones a la bd, se realicen de manera concurrente y segura en nuestra aplicación Blazor. 

   **3. Mostrar las Migraciones Versionadas y el Seed Data:** En (peliculas.db) podemos ver la tabla principal PelículasColeccion con sus respectivos campos (Id, Titulo, Etiqueta, Imagen), gestionada mediante Entity Framework Core. El esquema de la base de datos no se creó de forma manual, sino mediante migraciones versionadas de Entity Framework Core, cuyo historial queda registrado en la tabla __EFMigrationsHistory. Además, incorporamos datos iniciales (Seed Data) para que el catálogo tenga registros listos para usar desde el primer inicio de la aplicación.

   "Las migraciones son los planos versionados de nuestra base de datos creados por EF Core, lo que nos permite llevar un historial ordenado de los cambios. Y el Seed Data es la precarga automática de las 16 películas iniciales para que el catálogo tenga contenido desde el primer segundo en que se ejecuta la app."

   **4. CRUD completo con paginación y búsqueda:**
    CRUD Completo: Significa que puedes hacer las 4 acciones básicas de cualquier sistema profesional: 
    * Create (Crear): Agregar una nueva película con su título e imagen.
    * Read (Leer): Ver la lista de películas guardadas en SQLite.
    * Update (Actualizar): Editar los datos de una película si te equivoques.
    * Delete (Borrar): Eliminar una película que ya no quieras conservar.  
     Esto esta en "MiColeccion" al agregar peliculas con su titulo e imagen, poder poner su categoria y poder editarla si te equivocas, poder borrar la pelicula en la coleccion.


      Estas operaciones se ejecutan de forma asincrónica en nuestros servicios o componentes mediante Entity Framework Core. Utilizamos Add para las altas, ToListAsync para las consultas, y Remove para las bajas, cerrando siempre cada transacción con un SaveChangesAsync para garantizar que la persistencia se aplique de forma segura en el archivo SQLite."


###  Unidad 4 – Prácticas Profesionales
- **Control de Versiones:** Historial de cambios limpio en Git estructurado bajo el 
   estándar de *Conventional Commits* (`feat:`, `style:`, `fix:`).

---



La plataforma se abrirá de forma automática en su navegador en la dirección local estándar: `http://localhost:5032` este es el readme que tengo, es de antes de hacer todos los cambios que hicimos. podrias hacerlo de nuevo con todo lo que incluimos, redactalo de forma clara y simple