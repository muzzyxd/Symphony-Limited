using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

async Task CreateRole(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roleNames = new string[] { "Admin", "Student", "Faculty" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // create an admin role
    var adminUser = new IdentityUser
    {
        UserName = "admin@gmail.com",
        Email = "admin@gmail.com"
    };

    string adminPassword = "Admin@1234";

    var user = await userManager.FindByEmailAsync(adminUser.Email);
    if (user == null)
    {
        var createUser = await userManager.CreateAsync(adminUser, adminPassword);
        if (createUser.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await CreateRole(serviceProvider);
}

app.Run();