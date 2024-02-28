using Microsoft.EntityFrameworkCore;
using yorkshin;
using yorkshin.Repos;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<YorkshinDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UserRepository, UserRepository>();
builder.Services.AddTransient<BookRepository, BookRepository>();
builder.Services.AddTransient<CommentRepository, CommentRepository>();
builder.Services.AddTransient<OrderRepository, OrderRepository>();
builder.Services.AddTransient<ClassifyRepository, ClassifyRepository>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session逾時時間
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Landing/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LandingPage}");

app.Run();