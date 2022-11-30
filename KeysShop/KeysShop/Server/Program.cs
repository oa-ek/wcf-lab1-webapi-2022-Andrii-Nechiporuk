using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("KeysShopConnection");

builder.Services.AddDbContext<KeysShopContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

/*builder.Services.AddTransient<UsersRepository>();*/
builder.Services.AddScoped<KeysRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<OrdersRepository>();
builder.Services.AddScoped<SessionManager>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1.1",
        Title = "Keys Shop API",
        Description = "API for educational purposes",
    });
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
