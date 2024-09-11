using DeathDartOfGlorySeasonOne.Context;
using DeathDartOfGlorySeasonOne.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();





builder.Services.AddDbContextFactory<DartContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));





//Services
builder.Services.AddScoped<PlayerService>();









var app = builder.Build();
   
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
