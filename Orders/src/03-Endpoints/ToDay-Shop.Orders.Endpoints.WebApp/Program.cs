using ToDay_Shop.Orders.Endpoints.WebApp.Infrastructor.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();
