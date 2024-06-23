using MagicShopAlbum.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Inyeccion de dependencias
// Agrega el contexto de base de datos AppDBContext a los servicios de la aplicaci�n
builder.Services.AddDbContext<AppDBContext>(options =>
{
    // Obtiene la cadena de conexi�n "DefaultConnection" del archivo de configuraci�n
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

    // Configura el contexto para usar SQL Server con la cadena de conexi�n especificada
    options.UseSqlServer(connectionString);  // Inyecci�n de dependencias: se proporciona el contexto de base de datos configurado a trav�s de la inyecci�n de dependencias
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
