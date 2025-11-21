using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ResumeFixerAI.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ResumeFixerAI.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

// FIXED CONFIG SECTION NAME
builder.Services.Configure<OpenAiOptions>(
    builder.Configuration.GetSection("OpenAiOptions")
);

builder.Services.AddScoped<IAiService, AiService>();

var app = builder.Build();

app.UseRouting();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();
app.Run();
