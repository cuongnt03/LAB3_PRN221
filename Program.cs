using LAB3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var connectionStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SE1710_DB");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SE1710_DBContext>(otp => otp.UseSqlServer(builder.Configuration.GetConnectionString("SE1710_DB")));
builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(15));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "edit",
        pattern: "/edit/{action}/{id?}",
        defaults: new { controller = "edit", action = "Index" }); 
});

app.Run();
