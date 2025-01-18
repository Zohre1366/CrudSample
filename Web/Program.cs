using Application.Interfaces;
using Infrastructure.Implementations;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Entities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection"));
});
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
builder.Services.AddScoped<ITestDbContext, TestDbContext>();
builder.Services.AddSingleton(new MapperConfiguration(mc =>
{ mc.AddProfile(new MapperProfile()); }).CreateMapper());

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSwagger();
app.MapControllers();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api V.1.0.0.1");
    c.RoutePrefix = "_api/swagger";

});
app.MapRazorPages();

app.Run();
