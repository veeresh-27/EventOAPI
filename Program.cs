//using EventOAPI.Data;

using EventOAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<EventDBConnect, EventDBConnect>();
builder.Services.AddTransient<EventContext, EventContext>();


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
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/allusers", (EventDBConnect comp) =>
{

    return comp.GetAllUsers();
});
app.Run();

