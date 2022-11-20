using BarKavTavan.Domain;
using BarKavTavan.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddTransient<IUser, UserR>();
builder.Services.AddScoped<IBlog, BlogA>();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    
   
}).AddCookie(option =>
{
    option.LoginPath = "/Authentication/LogIn";
    option.LogoutPath = "/Authentication/SignOut";
    option.AccessDeniedPath = "/Authentication/Active";


});


//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("PolicyRequireRole", policy => policy.RequireRole("1"));
//}
//  );




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
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
