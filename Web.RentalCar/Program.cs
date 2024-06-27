using Application.RentalCar;
using Application.RentalCar.Repositories;
using Infrastructure.RentalCar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfigurationSection configuration = builder.Configuration.GetSection("AppSettings");

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(cookieOptions =>
{
    cookieOptions.LoginPath = configuration.GetValue<string>("LoginPage");//"/Accoint/Login";
    cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("TimeoutMinutes"));
});
builder.Services.AddDbContext<SaleCarDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalCarConn"));
});
builder.Services.AddScoped <IQueryRentalCarUseCase, RentalcarRepository>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped < RentalCarServices>();
builder.Services.AddScoped<AccountServices>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
