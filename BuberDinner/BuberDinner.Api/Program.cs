using System.Runtime.CompilerServices;
using BuberDinner;
using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());  // was part of second approach from video tutorial
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrstructure(builder.Configuration);
}
var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}