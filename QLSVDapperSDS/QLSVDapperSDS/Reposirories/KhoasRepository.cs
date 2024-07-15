using QLSVDapperSDS.Models.DTOReq;
using QLSVDapperSDS.Models;
using Dapper;

namespace QLSVDapperSDS.Reposirories
{
    public class KhoasRepository : IGenericRepository<Khoas, KhoasReq>
    {
        private readonly QLSVSDSContext db;
        public KhoasRepository( QLSVSDSContext db )
        {
            this.db = db;
        }
        public async Task<Khoas> AddAsync(KhoasReq item)
        {
            var query = "Insert into Khoas(makhoas, tenkhoas) values(@makhoas,@tenkhoas) select cast(scope_identity() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("makhoas", item.MaKhoas);
            parameters.Add("tenkhoas", item.TenKhoas);
            using (var context = db.CreateConnection())
            {
                var id = await context.QuerySingleAsync<int>(query, parameters);
                var khoas = new Khoas
                {
                    Id = id,
                    MaKhoas = item.MaKhoas,
                    TenKhoas = item.TenKhoas
                };
                return khoas;
            }
        }

        public async Task<List<Khoas>> GetAllAsync()
        {
            var quey = "select * from khoas";
            using (var context = db.CreateConnection())
            {
                var lstkhoas = await context.QueryAsync<Khoas>(quey);
                return lstkhoas.ToList();
            }
        }

        public async Task<Khoas> GetByIdAsync(int id)
        {
            var query = "select * from khoas where id = @id";
            using (var context = db.CreateConnection())
            {
                var khoas = await context.QuerySingleOrDefaultAsync<Khoas>(query, new { id });
                return khoas;
            }
        }

        public async Task<Khoas> GetByMaAsync(string ma)
        {
            var query = "select * from khoas where makhoas = @ma";
            using (var context = db.CreateConnection())
            {
                var khoas = await context.QuerySingleOrDefaultAsync<Khoas>(query, new { ma });
                return khoas;
            }
        }

        public async Task<Khoas> UpdateAsync(int id, KhoasReq item)
        {
            var query = @"UPDATE khoas SET makhoas = @Makhoas, tenkhoas = @Tenkhoas
                        WHERE id = @Id;
                        SELECT * FROM khoas WHERE id = @Id;";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("Makhoas", item.MaKhoas);
            parameters.Add("Tenkhoas", item.TenKhoas);

            using (var context = db.CreateConnection())
            {
                var updatedLop = await context.QuerySingleOrDefaultAsync<Khoas>(query, parameters);
                return updatedLop;
            }
        }
    }
}
