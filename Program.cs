
using EventOAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<EventService, EventService>();
builder.Services.AddDbContext<EventContext>();
builder.Services.AddTransient(typeof(EventContext));

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddCors((options) =>
{
    options.AddPolicy("cors", options =>
    {
        options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors("cors");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

