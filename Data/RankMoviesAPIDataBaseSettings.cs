
namespace RankMoviesAPI.Data
{
    public class RankMoviesAPIDataBaseSettings : IRankMoviesAPIDataBaseSettings
    {
        public string MoviesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}


