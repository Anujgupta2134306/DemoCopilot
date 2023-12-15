using Assan.DataDbcontext;
using Assan.Mappings;
using Assan.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AssanDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AssanDbconnectionstring")));
builder.Services.AddScoped<IPlayerRepositories , SqlRepositories>();
builder.Services.AddAutoMapper(typeof(AutoMappersProfiles));

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
