using CurrentTimeService.Context;
using CurrentTimeService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", (ApplicationDbContext context) => Results.Ok(context.Todos.ToList()));
app.MapGet("/create", (string work, ApplicationDbContext context) =>
{
    Todo todo = new()
    {
        Work = work,
    };

    context.Todos.Add(todo);
    context.SaveChanges();
    return Results.Ok(todo);
});

app.Run();
