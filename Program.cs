using GorevYoneticisi.Interfaces;
using GorevYoneticisi.Model;
using GorevYoneticisi.Services;
using GorevYoneticisi.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContextGY>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRaporService, RaporService>();

builder.Services.AddScoped<IRepository<Users>, Repository<Users>>();
builder.Services.AddScoped<IRepository<TokenInfo>, Repository<TokenInfo>>();
builder.Services.AddScoped<IRepository<RaporKayit>, Repository<RaporKayit>>();

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
