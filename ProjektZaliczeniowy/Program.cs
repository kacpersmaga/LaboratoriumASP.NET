using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowy.Models.Movies;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MoviesContextConnection") ?? throw new InvalidOperationException("Connection string 'MoviesContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlite(connectionString);
});

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