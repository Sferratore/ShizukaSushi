
using Microsoft.EntityFrameworkCore;
using ShizukaSushi.DatabaseContext;

// Creating a builder for the web application. 
// Starting point for configuring services and creating the app pipeline.
var builder = WebApplication.CreateBuilder(args);
{
    // AddControllers method adds services required for controllers. 
    builder.Services.AddControllers();

    // Configuring the application to use an Entity Framework Core context (ShizukaDbContext).
    // UseMySql method configures the context to connect to a MySQL database.
    builder.Services.AddDbContext<ShizukaDbContext>(options =>
    options.UseMySql(
        // Retrieving the connection string named "ShizukaDb" from the application configuration,
        // stored in appsettings.json.
        builder.Configuration.GetConnectionString("ShizukaDb"),
        // Specifying the MySQL server version.
        new MySqlServerVersion(new Version(8, 0, 11))
    ));
}



// Building the web application instance using the configurations defined above.
var app = builder.Build();
{
    // Middleware to redirect HTTP requests to HTTPS.
    // This is important for security, ensuring that data is sent over an encrypted connection.
    app.UseHttpsRedirection();

    // Maps controllers to their respective routes. 
    // This is required for the routing system to direct incoming requests to controller actions.
    app.MapControllers();

    // Starts the web application. This call makes the app start listening for incoming HTTP requests.
    app.Run();
}



