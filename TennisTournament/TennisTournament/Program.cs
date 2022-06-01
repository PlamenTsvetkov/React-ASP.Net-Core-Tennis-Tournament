using Microsoft.EntityFrameworkCore;
using TennisTournament.Data;
using TennisTournament.Infrastructure;
using TennisTournament.Services.Leagues;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TournamentDbContext>(options =>
                           options.UseSqlServer(Configuration.ConnectionString));

builder.Services.AddTransient<ILeaguesService, LeaguesService>();

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


app.Run();

