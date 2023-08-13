using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SchedulerApp.Data;
using MudBlazor;
using MudBlazor.Services;
using SchedulerApp.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<Constants>();
builder.Services.AddSingleton<ContentStorage>();
builder.Services.AddSingleton<Exporter>();
builder.Services.AddSingleton<Importer>();
builder.Services.AddSingleton<SchedulingAPIService>();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
