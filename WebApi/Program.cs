using System.Text;
using System.Text.Json;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using FileData;
using FileData.DAOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IStudentDao, UserFileDao>();
builder.Services.AddScoped<IStudentLogic, StudentLogic>();
builder.Services.AddScoped<ITeacherDao, UserFileDao>();
builder.Services.AddScoped<ITeacherLogic, TeacherLogic>();
builder.Services.AddScoped<ISupervisorDao, UserFileDao>();
builder.Services.AddScoped<ISupervisorLogic, SupervisorLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IClassLogic, ClassLogic>();
builder.Services.AddScoped<IClassDao, ClassFileDao>();
builder.Services.AddScoped<IExamLogic, ExamLogic>();
builder.Services.AddScoped<IExamDao, ExamFileDao>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGradeLogic, GradeLogic>();
builder.Services.AddScoped<IGradeDao, GradeDao>();

AuthorizationPolicies.AddPolicies(builder.Services);


builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();
app.UseAuthorization();


app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();