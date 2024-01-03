using Microsoft.EntityFrameworkCore;
using ShizukaSushi.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<ShizukaDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ShizukaDb"),
    new MySqlServerVersion(new Version(8, 0, 11))));
}



var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


