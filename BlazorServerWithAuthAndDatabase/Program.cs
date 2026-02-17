using BlazorServerWithAuthAndDatabase.Components;
using BlazorServerWithAuthAndDatabase.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAD"));

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Mongo
var mongoSettings = builder.Configuration.GetSection("MongoDB");

var client = new MongoClient(mongoSettings["ConnectionString"]);
builder.Services.AddSingleton<IMongoClient>(_ => client);

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase(mongoSettings["Database"]);
});

builder.Services.AddSingleton<IMongoCollection<WeatherEntity>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return db.GetCollection<WeatherEntity>(mongoSettings["Collection"]);
});

builder.Services.AddSingleton<IWeatherService, WeatherService>();

//MSSQL
builder.Services.AddDbContextFactory<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddSingleton<IUserService, UserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapStaticAssets();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
