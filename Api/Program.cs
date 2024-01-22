using Microsoft.EntityFrameworkCore;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<RepositoryContext>(opt =>
    opt.UseInMemoryDatabase("GithubCLient"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injections
builder.Services.AddScoped<App.Features.Contracts.Repository.IRepositoryListFeature, Api.Features.RepositoryListFeature>();
builder.Services.AddScoped<Api.Repositories.GithubApi.Contracts.IRepository, Api.Repositories.GithubApi.V3.Repository>();
builder.Services.AddScoped<Api.Repositories.EntityFramework.InMemory.IRepository, Api.Repositories.EntityFramework.InMemory.Repository>();

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
