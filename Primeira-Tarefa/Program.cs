using FluentValidation;
using Microsoft.OpenApi.Models;
using Primeira_Tarefa.Controllers;
using Primeira_Tarefa.Middleware;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Dapper.FluentMap;
using Primeira_Tarefa.Database_Maps;
using Dapper.FluentMap.Dommel;
using Primeira_Tarefa.Database;
using Primeira_Tarefa.Repository;
using MediatR;
using Primeira_Tarefa.Interfaces.Connections;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Interfaces;

try 
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);

    //Mediatr Config
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    //services.AddSwaggerExamplesFromAssemblyOf(typeof(MyExample));
    //services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
    builder.Services.AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação de API" });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        x.IncludeXmlComments(xmlPath);
    });
    builder.Services.AddSwaggerExamplesFromAssemblyOf<BrandInsertPayload>();

    Assembly? assembly = AppDomain.CurrentDomain.Load("Primeira-Tarefa");
    builder.Services.AddAutoMapper(assembly);

    //Vai adicionar na injeção de dependência todos os validaors, igual no exemplo abaixo
    builder.Services.AddValidatorsFromAssemblyContaining<BrandController>();
    builder.Services.AddValidatorsFromAssemblyContaining<BrandController>();
    builder.Services.AddValidatorsFromAssemblyContaining<BrandController>();
    //builder.Services.AddScoped<IValidator<GroupUpdatePayload>, GroupUpdatePayloadValidator>();

    builder.Services.AddScoped<IPostgresConnection, PostgresDatabaseConnection>();
    builder.Services.AddScoped<IBrandRepository, BrandRepository>();
    builder.Services.AddScoped<IGroupRepository, GroupRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    const string PolicyName = "Access-Control-Allow-Origin";

    builder.Services.AddCors(options =>
    {

        options.AddPolicy(PolicyName, builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders(new string[] { "Location", "Upload-Offset", "Upload-Length", "Content-Disposition" })
        ); ;
    });
    
    FluentMapper.Initialize(config =>
    {
        config.AddMap(new BrandDbMap());
        config.AddMap(new GroupDbMap());
        config.ForDommel();
    });

    WebApplication app = builder.Build();

    Log.Information("Application built");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        Log.Information("Application configured with Swagger");
    }

    app.UseCors(PolicyName);
    app.UseMiddleware<ErrorsHandlerMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    Log.Information("Application started successfully");
}

catch
{
    Log.Fatal("The application has a fatal error");
    throw;
}

finally
{
    Log.Information("Application being finalized");
    Log.CloseAndFlush();
}