using Microsoft.EntityFrameworkCore;
using Scuola.Models.Entity;
using Scuola.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = string.Empty;

try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Stringa di connessione non trovata");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}
// collegamento database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registrare servizi
builder.Services.AddScoped<Studente>();

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
