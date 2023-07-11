using BLL.Infrastructure;
using BLL.Services;
using DAL.Context;
using DAL.Repositories.UnitsOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigurationService(builder.Services);
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Resume}/{action=AllResumes}/{id?}");
app.MapControllerRoute(
    name: "emailConfirmation",
    pattern: "confirmation/",
    defaults: new { controller = "EmailConfirm", action = "Confirm" });
app.Run();

void ConfigurationService(IServiceCollection serviceCollection)
{
    serviceCollection.AddDbContext<ResumeContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connStr")));
    serviceCollection.AddIdentity<User, IdentityRole>(op => op.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ResumeContext>().AddDefaultTokenProviders().
       AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailConfirmationProvider");

    serviceCollection.Configure<EmailConfirmationProviderOption>(op => op.TokenLifespan = TimeSpan.FromDays(5));

    serviceCollection.Configure<SendGridSenderOptions>(op => builder.Configuration.GetSection("SendGridOptions").Bind(op));
    serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
    serviceCollection.AddTransient<IEmailSender, EmailSenderService>();
    serviceCollection.AddTransient<SkillService>();
    serviceCollection.AddTransient<ResumeService>();
    serviceCollection.AddTransient<EducationService>();
    serviceCollection.AddTransient<ExperienceService>();
    serviceCollection.AddTransient<SpecialityService>();

    BllConfiguration.ConfigurationService(serviceCollection);
}
