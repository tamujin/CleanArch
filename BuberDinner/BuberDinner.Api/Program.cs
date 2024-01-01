using BuberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());  // was part of second approach from video tutorial
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrstructure(builder.Configuration);

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}
var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}