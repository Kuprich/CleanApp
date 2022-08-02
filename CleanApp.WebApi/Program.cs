using CleanApp.Api;
using CleanApp.Application;
using CleanApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{

    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}


