using FluentValidation;
using Microsoft.OpenApi.Models;
using Primeira_Tarefa.Controllers;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.Middleware;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Payloads.GroupPayloads;
using Primeira_Tarefa.Validators.GroupValidators;
using Serilog.Events;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//services.AddSwaggerExamplesFromAssemblyOf(typeof(MyExample));
//services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste de Documentacao" });


    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    x.IncludeXmlComments(xmlPath);
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<BrandInsertPayload>();

Assembly? assembly = AppDomain.CurrentDomain.Load("Primeira-Tarefa");
builder.Services.AddAutoMapper(assembly);

//Vai adicionar na injeção de dependência todos os validaors, igual no exemplo abaixo
builder.Services.AddValidatorsFromAssemblyContaining<BrandsController>();
//builder.Services.AddScoped<IValidator<GroupUpdatePayload>, GroupUpdatePayloadValidator>();

builder.Services.AddSingleton<BrandDataBase>();
builder.Services.AddSingleton<GroupDatabase>();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorsHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();