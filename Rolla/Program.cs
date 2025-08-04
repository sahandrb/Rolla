using Rolla.Models;
using Rolla.Data;
using Microsoft.EntityFrameworkCore;
using Rolla.BackGroundServices;
using Rolla.Services;



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




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseSession();

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
