namespace receivePixel.Services
{
    public interface IStorageConfig
    {
        string ConnectionString();
        string DatabaseName();
    }
}