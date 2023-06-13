using Bemerkto.Contexts;
using Bemerkto.Helpers.Repositories;
using Bemerkto.Helpers.Services;
using Bemerkto.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

//Authentication
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.AccessDeniedPath = "/denied";
});

//Repositories
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<UserAddressRepository>();

//Services
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserAdminService>();





var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
