using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorldNews.Core.Services;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#region DB CONTEXT
builder.Services.AddDbContext<WNewsContext>(options =>
{
    options.UseSqlServer("Data Source =.;Encrypt = false;Initial Catalog=WorldNews_DB;Integrated Security=true");
});

#endregion
#region IOC
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<INewsService, NewsService>();
#endregion
#region AUTHENTICATION
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Account/Login";
    option.LogoutPath = "/Account/Logout";
    option.ExpireTimeSpan = TimeSpan.FromHours(30);
});

#endregion

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

#region AUTHORIZATION FOR ADMIN PANEL
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/NewsPanel"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Login");
        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {
            context.Response.Redirect("/Login");
        }
    }
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/UserPanel"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Login");
        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {
            context.Response.Redirect("/Login");
        }
    }
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/SectionPanel"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Login");
        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {
            context.Response.Redirect("/Login");
        }
    }
    await next.Invoke();
});
#endregion

app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
