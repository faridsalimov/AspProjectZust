using AspProjectZust.Business.Abstract;
using AspProjectZust.Business.Concrete;
using AspProjectZust.DataAccess.Abstract;
using AspProjectZust.DataAccess.Concrete.EFEntityFramework;
using AspProjectZust.Entities.Entity;
using AspProjectZust.WebUI.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPostDal, EFPostDal>();
builder.Services.AddScoped<IPostService, PostService>();

var connectionString = builder.Configuration.GetConnectionString("myconn");

builder.Services.AddDbContext<CustomIdentityDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSignalR();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=NewsFeed}/{id?}");
    endpoints.MapHub<UserHub>("/chathub");
});

app.Run();
