namespace WebApplication1.NewFolder
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ColectionName { get; set; } = string.Empty;
    }
}
