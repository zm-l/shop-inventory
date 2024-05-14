// Entrypoint for the application.
//
// All configuration is done here. Normally each of Domain, Core
// and Infrastructure will have configuration in their own projects,
// but for simplicity, it is all done here.

using Microsoft.EntityFrameworkCore;

using KyberlifeInterviewCsharp.Core.Interfaces;
using KyberlifeInterviewCsharp.Core.UseCases;
using KyberlifeInterviewCsharp.Infrastructure;
using KyberlifeInterviewCsharp.Infrastructure.Repositories;
using KyberlifeInterviewCsharp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Service
builder.Services
    .AddScoped<ShopItemController>();

//UseCases
builder.Services
    .AddScoped<GetAllShopItemsUseCase>();

//Infrastructure
builder.Services
    .AddDbContext<KyberlifeInterviewDbContext>(opt => opt.UseInMemoryDatabase("ShopItemList"))
    .AddScoped<IShopItemRepository, ShopItemRepository>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();