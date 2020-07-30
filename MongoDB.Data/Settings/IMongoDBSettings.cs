namespace MongoDB.Data.Settings
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
