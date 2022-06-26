using ContosoUniversity.Data;
using ContosoUniversity.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
var serverName = configuration["serverName"];
var databaseName = configuration["databaseName"];
var userName = configuration["userName"];
var password = configuration["password"];
var connectionString = string.Empty;
Console.WriteLine(connectionString);
if(string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
{
    connectionString = configuration.GetConnectionString("DefaultConnection");
}
else
{
    connectionString = ConfigHelper.GetConnectionString(serverName, databaseName, userName, password);
}
builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.Logger.LogInformation(connectionString);

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var context = services.GetRequiredService<SchoolContext>();
//        DbInitializer.Initialize(context);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
