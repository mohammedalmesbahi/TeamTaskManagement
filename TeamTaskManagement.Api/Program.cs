using TeamTaskManagement.Application;
using TeamTaskManagement.Infrastructure;
using TeamTaskManagement.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomControllers();
builder.Services.AddCustomApiVersioning();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddCustomIdentity();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomAuthorization();
builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);
builder.Services.AddCustomSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomMiddleware();
app.MapControllers();
app.Run();
