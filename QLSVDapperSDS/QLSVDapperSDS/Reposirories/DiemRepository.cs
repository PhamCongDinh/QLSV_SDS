using Dapper;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;

namespace QLSVDapperSDS.Reposirories
{
    public class DiemRepository : IDiemRepository
    {
        private readonly QLSVSDSContext db;
        public DiemRepository(QLSVSDSContext db)
        {
            this.db = db;
        }
        public async Task<Diem> addDiem(DangKyMonHoc dky)
        {
            var query = @"INSERT INTO Diem (id_sinhvien, id_monhoc) VALUES (@IdSinhVien, @IdMonHoc);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parameters = new DynamicParameters();
            parameters.Add("IdSinhVien", dky.Id_SinhVien);
            parameters.Add("IdMonHoc", dky.Id_MonHoc);

            using (var context = db.CreateConnection())
            {
                var id = await context.QuerySingleAsync<int>(query, parameters);

                var diem = new Diem
                {
                    Id = id,
                    Id_SinhVien = dky.Id_SinhVien,
                    Id_MonHoc = dky.Id_MonHoc
                };

                return diem;
            }
        }



        public async Task<Diem> Check(int id_sv, int id_monhoc)
        {
            var query = @"SELECT * FROM Diem WHERE id_sinhvien = @IdSinhVien AND id_monhoc = @IdMonHoc";

            var parameters = new DynamicParameters();
            parameters.Add("IdSinhVien", id_sv);
            parameters.Add("IdMonHoc", id_monhoc);

            using (var context = db.CreateConnection())
            {
                var diem = await context.QueryFirstOrDefaultAsync<Diem>(query, parameters);
                return diem;
            }
        }


        public async Task<List<Diem>> getDiemList()
        {
            var query = "select * from diem";
            using(var  context = db.CreateConnection())
            {
                var lstDiem = await context.QueryAsync<Diem>(query);
                return lstDiem.ToList();
            }
        }

        public async Task<Diem> UpdateDiem(int id, DiemReq diemReq)
        {
            var query = @"UPDATE Diem
                    SET DiemQuaTrinh = @DiemQuaTrinh, DiemThanhPhan = @DiemThanhPhan
                    WHERE Id = @Id;
                    SELECT * FROM Diem WHERE Id = @Id;
                ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("DiemQuaTrinh", diemReq.DiemQuaTrinh);
            parameters.Add("DiemThanhPhan", diemReq.DiemThanhPhan);

            using (var context = db.CreateConnection())
            {
                await context.ExecuteAsync(query, parameters);
                var updatedDiem = await context.QuerySingleAsync<Diem>(query, parameters);
                return updatedDiem;
            }
        }

    }
}
