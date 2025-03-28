using Microsoft.EntityFrameworkCore;
using Practice.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключаем MVC и Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Подключаем базу данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Настройки Middleware
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
