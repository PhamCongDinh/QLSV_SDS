using Dapper;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;

namespace QLSVDapperSDS.Reposirories
{
    public class MonHocRepository : IGenericRepository<MonHoc, MonHocReq>
    {
        private readonly QLSVSDSContext db;
        public MonHocRepository( QLSVSDSContext db )
        {
            this.db = db;
        }
        public async Task<MonHoc> AddAsync(MonHocReq item)
        {
            var query = @"
                INSERT INTO MonHoc (mamonhoc, tenmonhoc, sotiethoc)
                VALUES (@MaMonHoc, @TenMonHoc, @SoTietHoc);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";

            var parameters = new DynamicParameters();
            parameters.Add("MaMonHoc", item.MaMonHoc);
            parameters.Add("TenMonHoc", item.TenMonHoc);
            parameters.Add("SoTietHoc", item.SoTietHoc);

            using (var context = db.CreateConnection())
            {
                var id = await context.QuerySingleAsync<int>(query, parameters);

                var monHoc = new MonHoc
                {
                    Id = id,
                    MaMonHoc = item.MaMonHoc,
                    TenMonHoc = item.TenMonHoc,
                    SoTietHoc = item.SoTietHoc
                };

                return monHoc;
            }
        }


        public async Task<List<MonHoc>> GetAllAsync()
        {
            var quey = "select * from MonHoc";
            using (var context = db.CreateConnection())
            {
                var lstMonHoc = await context.QueryAsync<MonHoc>(quey);
                return lstMonHoc.ToList();
            }
        }

        public async Task<MonHoc> GetByIdAsync(int id)
        {
            var query = "select * from MonHoc where id = @id";
            using (var context = db.CreateConnection())
            {
                var monhoc = await context.QuerySingleOrDefaultAsync<MonHoc>(query, new { id });
                return monhoc;
            }
        }

        public async Task<MonHoc> GetByMaAsync(string ma)
        {
            var query = "select * from MonHoc where mamonhoc = @ma";
            using (var context = db.CreateConnection())
            {
                var monhoc = await context.QuerySingleOrDefaultAsync<MonHoc>(query, new { ma });
                return monhoc;
            }
        }

        public Task<MonHoc> UpdateAsync(int id, MonHocReq item)
        {
            throw new NotImplementedException();
        }
    }
}
