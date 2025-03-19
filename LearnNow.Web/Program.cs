using LearnNow;
using LearnNow.Class;
using LearnNow.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<TrainingEventRepository>();
builder.Services.AddControllersWithViews();

//Configura DBContext para la base de datos
builder.Services.AddDbContext<LearnNowDB>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//Configuracion de identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<LearnNowDB>()
    .AddDefaultTokenProviders();

//Configuracion de cookies para autenticador 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccesDenied";
});

builder.Services.AddScoped<ICourseRepository, CourseRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.SeedRoleAsync(services);
}

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

app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
