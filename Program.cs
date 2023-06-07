
using EventOAPI.Data;
using EventOAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<AuthService, AuthService>();
builder.Services.AddTransient<AdminServices, AdminServices>();
builder.Services.AddTransient<SpaceService, SpaceService>();
builder.Services.AddTransient<EventService, EventService>();

//builder.Services.AddTransient<ChatServices, ChatServices>();
builder.Services.AddTransient<CommunitiesServices, CommunitiesServices>();
//builder.Services.AddTransient<CommunityMemberServices, CommunityMemberServices>();
//builder.Services.AddTransient<EventAttendeesServices, EventAttendeesServices>();
//builder.Services.AddTransient<EventsServices, EventsServices>();

//builder.Services.AddTransient<LikeServices, LikeServices>();
//builder.Services.AddTransient<PostServices, PostServices>();

//builder.Services.AddTransient<UserServices, UserServices>();

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
}
app.MapControllers();



app.Run();

