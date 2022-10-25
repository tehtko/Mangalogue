using Mangalogue.Data;
using Mangalogue.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mangalogue"));
}, ServiceLifetime.Transient);
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<MangaService>();

var app = builder.Build();
app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
