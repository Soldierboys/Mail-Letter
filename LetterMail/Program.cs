using DinkToPdf;
using DinkToPdf.Contracts;
using Lettermail;
using LetterMail;
using LetterMail.Components;
using LetterMail.Models;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure SMTP settings and email services
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

// Add DinkToPdf services
builder.Services.AddSingleton<IConverter, SynchronizedConverter>(provider =>
    new SynchronizedConverter(new PdfTools()));

// Add PdfService to the container
builder.Services.AddSingleton<PdfService>();

// Configure the DbContext to use Npgsql
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add logging services (optional, for better diagnostics)
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.Services.GetRequiredService<IOptions<CircuitOptions>>().Value.DetailedErrors = true;
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery(); // Ensures that anti-forgery tokens are used in forms

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Configure interactive server-side Blazor components

app.Run();
