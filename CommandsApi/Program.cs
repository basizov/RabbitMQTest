using CommandApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMassTransitConnection(builder.Configuration);
var app = builder.Build();

app.MapControllers();
await app.RunAsync();
