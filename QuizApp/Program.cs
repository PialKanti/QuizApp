using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Entities;
using QuizApp.Mappings;
using QuizApp.Respositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<QuizAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuizAppContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<QuizAppContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.Lockout.AllowedForNewUsers = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IUserRepository<ApplicationUser>, UserRepository>();
builder.Services.AddScoped<IRepository<Option>, OptionRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "api";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

app.Run();
