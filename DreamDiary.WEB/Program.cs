using DreamDiary.BLL.Interfaces;
using DreamDiary.BLL.Services;
using DreamDiary.DAL.EF;
using DreamDiary.DAL.Interfaces;
using DreamDiary.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IDreamService, DreamService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<IGoalRepository, GoalRepository>();
builder.Services.AddTransient<IDreamRepository, DreamRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DreamContext>();
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
