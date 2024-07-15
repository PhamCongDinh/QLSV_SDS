using Dapper;
using QLSVDapperSDS.Models;
using QLSVDapperSDS.Models.DTOReq;

namespace QLSVDapperSDS.Reposirories
{
    public class LopRepository : IGenericRepository<Lop,LopReq>
    {
        private readonly QLSVSDSContext db;
        public LopRepository(QLSVSDSContext db)
        {
            this.db = db;
        }

        public async Task<Lop> AddAsync(LopReq item)
        {
            var query = "Insert into Lop(malop, tenlop) values(@malop,@tenlop) select cast(scope_identity() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("malop", item.MaLop);
            parameters.Add("tenlop", item.TenLop);
            using (var context = db.CreateConnection())
            {
                var id = await context.QuerySingleAsync<int>(query, parameters);
                var lop = new Lop
                {
                    Id = id,
                    MaLop = item.MaLop,
                    TenLop = item.TenLop
                };
                return lop;
            }

        }

        public async Task<List<Lop>> GetAllAsync()
        {
            var quey = "select * from lop";
            using (var context = db.CreateConnection())
            {
                var lstlop = await context.QueryAsync<Lop>(quey);
                return lstlop.ToList();
            }
        }

        public async Task<Lop> GetByIdAsync(int id)
        {
            var query = "select * from lop where id = @id";
            using (var context = db.CreateConnection())
            {
                var lop = await context.QuerySingleOrDefaultAsync<Lop>(query, new { id });
                return lop;
            }
        }

        public async Task<Lop> GetByMaAsync(string ma)
        {
            var query = "select * from lop where malop = @ma";
            using(var context = db.CreateConnection())
            {
                var lop = await context.QuerySingleOrDefaultAsync<Lop>(query, new { ma });
                return lop;
            }
        }

        public async Task<Lop> UpdateAsync(int id, LopReq item)
        {
            var query = @"UPDATE lop SET malop = @MaLop, tenlop = @TenLop
                        WHERE id = @Id;
                        SELECT * FROM lop WHERE id = @Id;";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("MaLop", item.MaLop);
            parameters.Add("TenLop", item.TenLop);

            using (var context = db.CreateConnection())
            {
                var updatedLop = await context.QuerySingleOrDefaultAsync<Lop>(query, parameters);
                return updatedLop;
            }
        }
    }
}
