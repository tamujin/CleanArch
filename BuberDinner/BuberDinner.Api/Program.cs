using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddApplication();
    builder.Services.AddInfrstructure(builder.Configuration);
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}