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
