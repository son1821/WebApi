namespace WebApplication1.NewFolder
{
    public interface IDatabaseSettings
    {
        string ColectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set;}
    }
}
