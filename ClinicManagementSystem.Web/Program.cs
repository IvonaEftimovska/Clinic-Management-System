using ClinicManagementSystem.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------
// 1️⃣ Configure Services
// -----------------------------------------------------

// Add MVC controllers and Razor views
builder.Services.AddControllersWithViews();

// Register DbContext and SQL Server connection
// var host = Environment.GetEnvironmentVariable("DB_HOST");
// var port = Environment.GetEnvironmentVariable("DB_PORT");
// var database = Environment.GetEnvironmentVariable("DB_NAME");
// var user = Environment.GetEnvironmentVariable("DB_USER");
// var password = Environment.GetEnvironmentVariable("DB_PASS");

var connectionString = $"Host=localhost;Port=5432;Database=clinic;Username=clinic_role;Password=admin";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register ASP.NET Identity (for login / register)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// -----------------------------------------------------
// 2️⃣ Configure HTTP Request Pipeline
// -----------------------------------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default route (HomeController → Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Optional route for Razor Pages (Identity UI)
app.MapRazorPages();

app.Run();