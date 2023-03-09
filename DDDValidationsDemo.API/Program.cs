using DDDValidationsDemo.App.UseCases.Workouts;
using DDDValidationsDemo.App.UseCases.Workouts.Add;
using DDDValidationsDemo.Db;
using FluentValidation;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWorkOutRepository, WorkoutRepository>();
builder.Services.AddSingleton<DbStore>();

builder.Services.AddValidatorsFromAssembly(typeof(AddWorkoutCommandValidator).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddWorkoutCommand).Assembly));


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
