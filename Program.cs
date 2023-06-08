
using EventOAPI.Data;
using EventOAPI.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<AuthService, AuthService>();
builder.Services.AddTransient<AdminServices, AdminServices>();
builder.Services.AddTransient<SpaceService, SpaceService>();
builder.Services.AddTransient<EventService, EventService>();
builder.Services.AddTransient<CommunitiesServices, CommunitiesServices>();
builder.Services.AddTransient<UserService, UserService>();

builder.Services.AddDbContext<EventContext>();
builder.Services.AddTransient(typeof(EventContext));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async c =>
        {
            c.Response.StatusCode = StatusCodes.Status500InternalServerError;
            c.Response.ContentType = "application/json";
            var exceptionHandlerPathFeature = c.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error != null)
            {
                await c.Response.WriteAsJsonAsync(new
                {
                    Message = exceptionHandlerPathFeature.Error.Message,
                    Code = StatusCodes.Status500InternalServerError,
                    Exception = exceptionHandlerPathFeature.Error.GetType().Name,
                    Route=exceptionHandlerPathFeature.RouteValues,
                    Trace=exceptionHandlerPathFeature.Error.StackTrace
                });
            }
        });
    });
}
app.MapControllers();



app.Run();

