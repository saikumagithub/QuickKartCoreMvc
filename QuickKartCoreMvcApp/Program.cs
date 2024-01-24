using QuickKartDataAccessLayer.Models;
using System.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using QuickKartCoreMvcApp.Repository;


var builder = WebApplication.CreateBuilder(args);

//adding auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new QuickKartMapper()));
// Add services to the container.
builder.Services.AddControllersWithViews();

//i written this statement for cookies managemenyt
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//i am writing this explicitly code
builder.Services.AddDbContext<QuickKartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("QuickKartCon")));


//adding a session
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//enabling session for the application
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");


app.Run();
