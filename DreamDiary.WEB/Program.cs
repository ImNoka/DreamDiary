using DreamDiary.BLL.Interfaces;
using DreamDiary.BLL.Services;
using DreamDiary.DAL.EF;
using DreamDiary.DAL.Interfaces;
using DreamDiary.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configBuilder = new ConfigurationBuilder();
configBuilder.SetBasePath(Directory.GetCurrentDirectory());
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteProfileService, NoteProfileService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IDreamService, DreamService>();
builder.Services.AddScoped<IImageProfileService, ImageProfileService>();
builder.Services.AddScoped<IDreamService, DreamService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddTransient<INoteProfileRepository, NoteProfileRepository>();
builder.Services.AddTransient<IGoalRepository, GoalRepository>();
builder.Services.AddTransient<IDreamRepository, DreamRepository>();
builder.Services.AddTransient<IImageProfileRepository, ImageProfileRepository>();
builder.Services.AddTransient<IDreamRepository, DreamRepository>();
builder.Services.AddTransient<IImageDreamRepository, ImageDreamRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DreamContext>(opt => 
                        opt.UseSqlServer(@config.GetConnectionString("DreamDiaryDatabase")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
