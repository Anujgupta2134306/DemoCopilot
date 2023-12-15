using DemoCopilot.AutoMapper;
using DemoCopilot.Data;
using DemoCopilot.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//create builder service to add connection string as sqlserver.
builder.Services.AddDbContext<PlayerDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PlayerDb")));
builder.Services.AddScoped<IPlayerRepository ,SqlPlayerRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperPlayer));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
