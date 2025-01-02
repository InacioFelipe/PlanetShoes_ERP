using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PlanetShoes_ADD.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=localhost\\SQLEXPRESS;Database=PlanetShoesDb;Trusted_Connection=True;";
        }
        
    }
}
