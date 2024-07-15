using Dapper;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;

namespace QLSVDapperSDS.Reposirories
{
    public class SinhVienRepository : IGenericRepository<SinhVien, SinhVienReq>
    {
        private readonly QLSVSDSContext db;
        public SinhVienRepository(QLSVSDSContext db)
        {
            this.db = db;
        }
        public async Task<SinhVien> AddAsync(SinhVienReq item)
        {
            var query = @"
        INSERT INTO SinhVien(masinhvien, tensinhvien, gioitinh, ngaythangnamsinh, id_lop, id_khoas)
        VALUES (@MaSinhVien, @TenSinhVien, @GioiTinh, @NgayThangNamSinh, @IdLop, @IdKhoa);
        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ";

            var parameters = new DynamicParameters();
            parameters.Add("MaSinhVien", item.MaSinhVien);
            parameters.Add("TenSinhVien", item.TenSinhVien);
            parameters.Add("GioiTinh", item.GioiTinh);
            parameters.Add("NgayThangNamSinh", item.NgayThangNamSinh);
            parameters.Add("IdLop", item.Id_Lop);
            parameters.Add("IdKhoa", item.Id_Khoas);

            using (var context = db.CreateConnection())
            {
                var id = await context.QuerySingleAsync<int>(query, parameters);

                var sinhVien = new SinhVien
                {
                    Id = id,
                    MaSinhVien = item.MaSinhVien,
                    TenSinhVien = item.TenSinhVien,
                    GioiTinh = item.GioiTinh,
                    NgayThangNamSinh = item.NgayThangNamSinh,
                    Id_Lop = item.Id_Lop,
                    Id_Khoas = item.Id_Khoas
                };

                return sinhVien;
            }
        }

        public async Task<List<SinhVien>> GetAllAsync()
        {
            var quey = "select * from sinhvien";
            using (var context = db.CreateConnection())
            {
                var lstsv = await context.QueryAsync<SinhVien>(quey);
                return lstsv.ToList();
            }
        }

        public async Task<SinhVien> GetByIdAsync(int id)
        {
            var query = "select * from SinhVien where id = @id";
            using (var context = db.CreateConnection())
            {
                var sv = await context.QuerySingleOrDefaultAsync<SinhVien>(query, new { id });
                return sv;
            }
        }

        public async Task<SinhVien> GetByMaAsync(string ma)
        {
            var query = "select * from SinhVien where masinhvien = @ma";
            using (var context = db.CreateConnection())
            {
                var sv = await context.QuerySingleOrDefaultAsync<SinhVien>(query, new { ma });
                return sv;
            }
        }

        public async Task<SinhVien> UpdateAsync(int id, SinhVienReq item)
        {
            var query = @"UPDATE SinhVien
                SET masinhvien = @MaSinhVien,
                tensinhvien = @TenSinhVien,
                gioitinh = @GioiTinh,
                ngaythangnamsinh = @NgayThangNamSinh,
                id_lop = @IdLop,
                id_khoas = @IdKhoa
                WHERE id = @Id;
        
                SELECT * FROM SinhVien WHERE id = @Id;";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("MaSinhVien", item.MaSinhVien);
            parameters.Add("TenSinhVien", item.TenSinhVien);
            parameters.Add("GioiTinh", item.GioiTinh);
            parameters.Add("NgayThangNamSinh", item.NgayThangNamSinh);
            parameters.Add("IdLop", item.Id_Lop);
            parameters.Add("IdKhoa", item.Id_Khoas);

            using (var connection = db.CreateConnection())
            {
                var updatedSinhVien = await connection.QuerySingleOrDefaultAsync<SinhVien>(query, parameters);
                return updatedSinhVien;
            }
        }
    }
}
