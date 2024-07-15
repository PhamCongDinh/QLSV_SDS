using NHibernate;
using QuanLySVDSD.Models;
using QuanLySVDSD.Repositories;
using QuanLySVDSD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISessionFactory>(provider => NHibernateSession.GetSessionFactory());


//khoas
builder.Services.AddScoped<IKhoasRepository, KhoasRepository>();
builder.Services.AddScoped<KhoasService>();
//lop
builder.Services.AddScoped<ILopRepository, LopRepository>();
builder.Services.AddScoped<LopService>();
//sinhvien
builder.Services.AddScoped<ISinhVienRepository,SinhVienRepository>();
builder.Services.AddScoped<SinhVienService>();
//monhoc
builder.Services.AddScoped<IMonHocRepository, MonHocRepository>();
builder.Services.AddScoped<MonHocService>();

//diem
builder.Services.AddScoped<IDiemRepository,DiemRepository>();
builder.Services.AddScoped<DiemService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
