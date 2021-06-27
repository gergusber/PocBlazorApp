namespace CRUDPOC.Domain.Config
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string ConnectionString) => this.ConnectionString = ConnectionString;

        public string ConnectionString { get; }
    }
}