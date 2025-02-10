using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ToDo_Shop.Gateway.IdentityServer.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddIdentityServer(builder.Configuration, "OAuth");

// Ocelot
builder.Services.AddOcelot();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseIdentityServer("OAuth");

// Ocelot
await app.UseOcelot();

app.Run();
