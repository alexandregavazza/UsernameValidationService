using UsernameValidationService.Data;
using UsernameValidationService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add EF Core - Use SQLite for simplicity
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=usernames.db"));

// Add custom service
builder.Services.AddScoped<IUsernameService, UsernameService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// Ensure DB created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
