
using EventOAPI.Data;
using EventOAPI.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAdminServices, AdminServices>();
builder.Services.AddTransient<ISpaceService, SpaceService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<ICommunitiesServices, CommunitiesServices>();
builder.Services.AddTransient<IUserService, UserService>();

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
                    Route = exceptionHandlerPathFeature.RouteValues,
                    Trace = exceptionHandlerPathFeature.Error.StackTrace
                });
            }
        });
    });
}
app.MapControllers();

app.Run();

