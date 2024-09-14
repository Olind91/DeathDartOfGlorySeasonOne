using DeathDartOfGlorySeasonOne.Context;
using DeathDartOfGlorySeasonOne.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure Entity Framework
builder.Services.AddDbContextFactory<DartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));

// Add custom services
builder.Services.AddScoped<PlayerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
