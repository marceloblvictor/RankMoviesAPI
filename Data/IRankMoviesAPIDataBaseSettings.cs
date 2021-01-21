
namespace RankMoviesAPI.Data
{
    public interface IRankMoviesAPIDataBaseSettings
    {
        string MoviesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
