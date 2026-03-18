using Microsoft.EntityFrameworkCore;
using MiIT.Models;

var builder = WebApplication.CreateBuilder(args);

// Import Config
IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("./config.json", optional: false, reloadOnChange: true)
    .Build();

// Register MVC Service
builder.Services.AddMvc();

// Add Database Context
builder.Services.AddDbContext<ApplicantDataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DBConnection");
    options.UseSqlServer(connectionString);
});

// Build Application
var app = builder.Build();


// == MIDDLEWARES ==

// Set default MVC entry to Applicant controller => Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Applicant}/{action=Index}");

// Serves the static "index.html" from folder "wwwroot"
app.UseFileServer();

// Start Application
app.Run();
