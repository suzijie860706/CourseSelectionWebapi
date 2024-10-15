using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;
using TRIDENT_Project.Repositories;
using TRIDENT_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//資料庫
builder.Services.AddDbContext<StudentEnrollmentSystemContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentEnrollmentSystem")));

//Business Layer
builder.Services.AddScoped<ICRUDRepository<Course>, CRUDRepository<Course, StudentEnrollmentSystemContext>>();
builder.Services.AddScoped<ICRUDRepository<Professor>, CRUDRepository<Professor, StudentEnrollmentSystemContext>>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IValidationService, ValidationService>();

//Controller Layer
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IProfessorsService, ProfessorsService>();

//Repo Layer


#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    //表頭描述
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TRIDENT_Project",
        Description = $@"
An ASP.NET Core 6 Web API for TRIDENT_Project.  
Some useful links:
- [The TRIDENT_Project repository](https://github.com/suzijie860706/TRIDENT_Project)",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    //xml文件增加註解
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    //啟動Filters
    options.ExampleFilters();
});
// 啟用 Filters 服務
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
#endregion

//AutoMapper DI Profile Class
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// 驗證 AutoMapper 配置
try
{
    var mapper = app.Services.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}
catch (Exception ex)
{
    throw new Exception("AutoMapper設定錯誤", ex);
}


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
