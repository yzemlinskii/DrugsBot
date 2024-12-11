namespace Insfrastructure.Dal.Models;

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public int CommandTimeout { get; set; }
}