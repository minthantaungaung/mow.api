using api.mov.Controller;
using api.mov.Controllers;
using api.mov.Extentions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.ConfigureAppSettings(configuration);
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.TokenProvider(configuration);
app.MemberEndpoints();
app.CustomerEndpoints();
app.OrderEndpoints();
app.UseAuthentication();
app.UseAuthorization();
app.Run();