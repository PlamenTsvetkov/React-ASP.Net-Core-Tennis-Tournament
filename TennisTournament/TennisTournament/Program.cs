using Microsoft.EntityFrameworkCore;
using TennisTournament.Data;
using TennisTournament.Infrastructure;
using TennisTournament.Services.Leagues;
using Newtonsoft.Json.Serialization;
using TennisTournament.Services.Players;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:7158", "http://localhost:3000");
        });
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
              .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
              = new DefaultContractResolver());
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TournamentDbContext>(options =>
                           options.UseSqlServer(connectionString));

builder.Services.AddTransient<ILeagueService, LeagueService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.PrepareDatabase();



app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                  Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});

app.Run();

