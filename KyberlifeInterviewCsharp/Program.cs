using Microsoft.EntityFrameworkCore;

using KyberlifeInterviewCsharp.Core.Interfaces;
using KyberlifeInterviewCsharp.Infrastructure;
using KyberlifeInterviewCsharp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure services
builder.Services
    .AddDbContext<KyberlifeInterviewDbContext>(opt => opt.UseInMemoryDatabase("ToDoList"))
    .AddScoped<ITodoRepository, TodoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();