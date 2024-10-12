using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NutriSpace.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar servicios de sesión
builder.Services.AddDistributedMemoryCache(); // Necesario para almacenar las sesiones en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Asegura que la cookie de sesión solo sea accesible a través de HTTP
    options.Cookie.IsEssential = true; // Marca la cookie como esencial
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); // Agregar el middleware de sesión

app.MapRazorPages();

app.Run();
