using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumRecorder.DAL;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AwaitDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db_context") ?? throw new InvalidOperationException("Connection string 'db_context' not found.")));
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IWebDriver>(provider =>
{
    string webRootPath = provider.GetRequiredService<IWebHostEnvironment>().WebRootPath;
    string chromeDriverPath = Path.Combine(webRootPath, "chromeDriver");

    ChromeOptions chromeOptions = new ChromeOptions();
    return new ChromeDriver(chromeDriverPath, chromeOptions);
});

builder.Services.AddRazorPages();
var app = builder.Build();;

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
app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyHeader();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
