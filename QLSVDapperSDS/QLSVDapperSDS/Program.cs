using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Reposirories;
using QLSVDapperSDS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<QLSVSDSContext>();


//lop
builder.Services.AddScoped<IGenericRepository<Lop,LopReq>, LopRepository>();
builder.Services.AddScoped<LopService>();
//khóa
builder.Services.AddScoped<IGenericRepository<Khoas, KhoasReq>, KhoasRepository>();
builder.Services.AddScoped<KhoasService>();
//sinhvien
builder.Services.AddScoped<IGenericRepository<SinhVien, SinhVienReq>, SinhVienRepository>();
builder.Services.AddScoped<SinhVienService>();
//monhoc
builder.Services.AddScoped<IGenericRepository<MonHoc, MonHocReq>, MonHocRepository>();
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
