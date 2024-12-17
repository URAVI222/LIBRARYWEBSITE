using Microsoft.EntityFrameworkCore;
using LibraryApplication.Models; // Ensure this namespace includes your LibraryContext definition

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register BookRepository

builder.Services.AddScoped<LibraryApplication.Repositories.BookRepository>();


// Configure the DbContext with SQL Server
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use error handling in production
}
else
{
    app.UseDeveloperExceptionPage(); // Show detailed errors in development
}

app.UseStaticFiles(); // Serve static files

app.UseRouting(); // Enable routing

app.UseAuthorization(); // Enable authorization

// Define the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Run the application
