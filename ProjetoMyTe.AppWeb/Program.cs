using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.Startup;
using ProjetoMyTe.AppWeb.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

builder.Services.AddDbContext<MyTeContext>(options =>
    options.UseSqlServer(config.GetConnectionString("MyTeConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<RegistroHorasService>();
builder.Services.AddScoped<CargosService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<MyTeContext>();

// Sincronizando com o banco de dados
DbInitializer.Initialize(context);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
