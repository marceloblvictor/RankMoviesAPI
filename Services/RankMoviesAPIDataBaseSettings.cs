
namespace RankMoviesAPI.Services
{
    public class RankMoviesAPIDataBaseSettings : IRankMoviesAPIDataBaseSettings
    {
        public string MoviesCollectionName { get; set; } 
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; } 
    }
}


