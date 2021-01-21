
namespace RankMoviesAPI.Services
{
    public interface IRankMoviesAPIDataBaseSettings
    {
        string MoviesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}
