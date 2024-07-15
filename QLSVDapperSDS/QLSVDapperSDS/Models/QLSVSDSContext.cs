using System.Data;
using System.Data.SqlClient;

namespace QLSVDapperSDS.Models
{
    public class QLSVSDSContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public QLSVSDSContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()=> new SqlConnection(connectionString);
    }
}
