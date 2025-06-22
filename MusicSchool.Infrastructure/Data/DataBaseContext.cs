using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MusicSchool.Infrastructure.Data
{
    public class DataBaseContext
    {
        private readonly IConfiguration _config;
        public DataBaseContext(IConfiguration config) => _config = config;
        public IDbConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
            catch (Exception ex)
            {
                // loguea ex.ToString() en consola o en un fichero para ver la causa real
                throw;
            }
        }
    }
}
