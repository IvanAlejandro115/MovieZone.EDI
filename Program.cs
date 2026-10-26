using Microsoft.EntityFrameworkCore;
using MovieZone.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 🗄️ CONEXIÓN SQLITE: Registra la base de datos real para tu proyecto
builder.Services.AddDbContext<MovieZone.AppDbContext>(options =>
    options.UseSqlite("Data Source=peliculas.db"));

// 🛡️ REQUERIDO EN .NET 9: Registra el servicio de seguridad para formularios interactivos
builder.Services.AddAntiforgery();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Habilita el uso de la seguridad Antiforgery en el flujo de la web
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
