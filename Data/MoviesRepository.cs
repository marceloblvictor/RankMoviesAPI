using MongoDB.Driver;
using RankMoviesAPI.Models;
using RankMoviesAPI.Services;
using System.Collections.Generic;
using System.Linq;


namespace RankMoviesAPI.Data
{
    public class MoviesRepository
    {
        private readonly IMongoCollection<Movie> _movies;

        public MoviesRepository(IRankMoviesAPIDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);

            _movies = database.GetCollection<Movie>(settings.MoviesCollectionName);
        }

        public List<Movie> Get() =>
            _movies.Find(movie => true).ToList();

        public Movie Get(string id) =>
            _movies.Find<Movie>(movie => movie.ID == id).FirstOrDefault();

        public Movie Create(Movie movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie movieIn) =>
            _movies.ReplaceOne(movie => movie.ID == id, movieIn);

        public void Remove(Movie movieIn) =>
            _movies.DeleteOne(movie => movie.ID == movieIn.ID);

        public void Remove(string id) =>
            _movies.DeleteOne(movie => movie.ID == id);
    }
}
