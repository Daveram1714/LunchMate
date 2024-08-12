using DataLayer;
using DataLayer.Repositories;
using Domain.Interface;
using Domain.UseCase;
using Domain.UseCase.Mel_usecase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<LunchMateDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();

builder.Services.AddScoped<CreatMeal>();
builder.Services.AddScoped<DeleteMeal>();
builder.Services.AddScoped<GetAllmeals>();
builder.Services.AddScoped<GetAllmeals>();
builder.Services.AddScoped<UpdateMeal>();


builder.Services.AddScoped<CreateUser>();
builder.Services.AddScoped<UpdateUser>();
builder.Services.AddScoped<DeletUser>();
builder.Services.AddScoped<GetAllUser>();
builder.Services.AddScoped<GetUser>();

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
