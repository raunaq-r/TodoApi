using Microsoft.AspNetCore.Mvc;
using NSwag.AspNetCore;
using TodoLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config => 
{
    config.DocumentName = "TodoAPI";
    config.Title = "TodoAPI v1";
    config.Version = "v1";
});
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ITodoData, TodoData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config => 
    {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/api/Todos", async (ITodoData data) => 
{
    var output = await data.GetAllTasks();
    return Results.Ok(output);
});

app.MapPost("/api/Todos", async (ITodoData data, [FromBody] string task) => 
{
    var output = await data.CreateTask(task);
    return Results.Ok(output);
});

app.Run();
