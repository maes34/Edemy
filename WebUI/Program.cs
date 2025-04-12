using Core.Service;
using Model.Context;
using Service.DbService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddDbContext<EdemyDbContext>(options =>
{
    options.UseSqlServer("Server=MAES\\SQLEXPRESS;Database=EdemyDb;Integrated Security=true;TrustServerCertificate=True;");
});

builder.Services.AddScoped(typeof(ICoreService<>), typeof(DbCoreService<>));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(c => 
    {
        c.LoginPath = "/Admin/Account/Login";
        c.LogoutPath = "/Admin/Account/Logout";
    });
builder.Services.AddSession(option =>
{
    option.Cookie.Name = "Basket";
    option.IdleTimeout = TimeSpan.FromMinutes(30);
    option.Cookie.HttpOnly = true;
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
app.UseSession();
app.UseRouting();
app.UseAuthentication(); // Login - Logout Süreci
app.UseAuthorization();  // Yetkilendirme Ýþlemler.

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.Run();
