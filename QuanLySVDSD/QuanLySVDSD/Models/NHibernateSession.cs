using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace QuanLySVDSD.Models
{
    public class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                configuration.DataBaseIntegration(d =>
                {
                    // Connection string should be retrieved from environment variables or app settings
                    d.ConnectionString = GetConnectionString();
                    d.Dialect<MsSql2012Dialect>();
                    d.Driver<SqlClientDriver>();
                });
                configuration.AddAssembly(Assembly.GetExecutingAssembly());
                _sessionFactory = configuration.BuildSessionFactory();
            }

            return _sessionFactory;
        }

        private static string GetConnectionString()
        {
            // Implement logic to retrieve connection string from environment variables or app settings
            return "Data Source=LAPTOP-TGUQGH9P\\SQLEXPRESS;Initial Catalog=QLSVSDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
