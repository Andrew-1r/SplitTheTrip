using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SplitTheTrip.Data;
var builder = WebApplication.CreateBuilder(args);
// run sqlite for dev and prod db for prod
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<SplitTheTripContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SplitTheTripContext") ?? throw new InvalidOperationException("Connection string 'SplitTheTripContext' not found.")));
}
else
{
    builder.Services.AddDbContext<SplitTheTripContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionSplitTheTripContext") ?? throw new InvalidOperationException("Connection string 'SplitTheTripContext' not found.")));
}
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
