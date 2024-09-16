using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NMK.Data;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NMKDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NMKDbContext")));


builder.Services.AddSingleton<IConverter, SynchronizedConverter>(sp =>
{
    var pdfTools = new PdfTools();
    var converter = new SynchronizedConverter(new PdfTools());
    return converter;
});

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
