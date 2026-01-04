using Microsoft.EntityFrameworkCore;
using TestExamenWeb.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IAdminRepository<Project>, AdminRepository<Project>>(httpclient =>
    httpclient.BaseAddress = new Uri(builder.Configuration["ServiceAddress"] + "projects/"));
builder.Services.AddHttpClient<IAdminRepository<Student>, AdminRepository<Student>>(httpclient =>
    httpclient.BaseAddress = new Uri(builder.Configuration["ServiceAddress"] + "students/"));

builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ProjectContext>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
