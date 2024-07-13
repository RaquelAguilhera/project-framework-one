using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_framework_one.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<project_framework_oneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("project_framework_oneContext") ?? throw new InvalidOperationException("Connection string 'project_framework_oneContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
