using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Services;
using HR_Management.WebMvc.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Authentication/Login";
        options.LogoutPath = "/Authentication/Logout";
    });

var apiAddress = builder.Configuration.GetSection("ApiAddress").Value;
builder.Services.AddHttpClient<IClient, Client>(c =>
{
    c.BaseAddress = new Uri(apiAddress);
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddTransient<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddTransient<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddTransient<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
