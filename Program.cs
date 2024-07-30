var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/current-time", () => Results.Ok(DateTime.UtcNow));
app.MapGet("/current-time2", () => Results.Ok(DateTime.Now));
app.MapGet("/current-time3", () => Results.Ok(DateTime.Now));

app.Run();
