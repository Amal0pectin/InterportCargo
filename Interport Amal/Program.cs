using Interport_Amal.Application.Interfaces;
using Interport_Amal.Application.Services;
using Interport_Amal.BusinessLogic.Interfaces;
using Interport_Amal.BusinessLogic.Services;
using Interport_Amal.DataAccess.Data;
using Interport_Amal.DataAccess.Interfaces;
using Interport_Amal.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CargoDBContext>(options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.


builder.Services.AddScoped<ICustomerRepository, EFCustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
builder.Services.AddScoped<IEmployeeAppService, EmployeeAppService>();
builder.Services.AddScoped<IQuotationRepository, EFQuotationRepository>();
builder.Services.AddScoped<IQuotationService, QuotationService>();
builder.Services.AddScoped<IQuotationAppService, QuotationAppService>();
builder.Services.AddScoped<IQuotationRequestRepository, EFQuotationRequestRepository>();
builder.Services.AddScoped<IQuotationRequestService, QuotationRequestService>();
builder.Services.AddScoped<IQuotationRequestAppService, QuotationRequestAppService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Customers/CLogin"; 
        options.LogoutPath = "/Index"; 
    });

builder.Services.AddAuthorization();




builder.Services.AddRazorPages();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
