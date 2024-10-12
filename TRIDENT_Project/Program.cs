using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//¸ê®Æ®w
builder.Services.AddDbContext<StudentEnrollmentSystemContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentEnrollmentSystem")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
