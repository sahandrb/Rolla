using Rolla.Models;
using Rolla.Data;
using Microsoft.EntityFrameworkCore;
using Rolla.BackGroundServices;
using Rolla.Services;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//imlimenting DefaultConnection
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RollaContext"), sqlOptions => sqlOptions.UseNetTopologySuite()));

builder.Services.AddSession(); 
// AddSession
builder.Services.AddHostedService<RouteCleanerService>();  //سرویس غیر فعال کردن به صورت اتوماتیک

builder.Services.AddScoped<IDRouteServices, DRouteServices>();
builder.Services.AddScoped<IRRouteServices, RRouteServices>();
builder.Services.AddScoped<IGeoJsonService, GeoJsonService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // مسیر ریدایرکت در صورت عدم احراز هویت
        options.ExpireTimeSpan = TimeSpan.FromHours(7);
        options.SlidingExpiration = true;
    });



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseSession();
app.UseAuthentication(); // این خط اجباری است

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
