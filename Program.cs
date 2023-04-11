using Microsoft.EntityFrameworkCore;
using ms_filmes.Data;
using ms_filmes.Domain;
using ms_filmes.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFilmes, FilmeDomain>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext -> postgres  
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    );
});

// AddAutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyOrigin() // Permite todas as origens
    .AllowAnyMethod() // Permite todos os métodos
    .AllowAnyHeader()); // Permite todos os cabeçalhos

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
