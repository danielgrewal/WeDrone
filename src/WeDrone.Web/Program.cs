using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WeDrone.Web.Core.Infrastructure;
using WeDrone.Web.Core.Infrastructure.Google;
using WeDrone.Web.Core.Interfaces;
using WeDrone.Web.Core.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Configuration.AddIniFile("appsettings.ini");

builder.Services.AddDbContextPool<WeDroneContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeDroneContext"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddScoped<APIClient>(x => new APIClient(builder.Configuration.GetValue<string>("GoogleAPI:Key")));
builder.Services.AddScoped<IAddressLookup, AddressLookup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();
