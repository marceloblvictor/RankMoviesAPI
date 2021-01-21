using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RankMoviesAPI.Models
{
    public class Movie
    {
        [BsonId]
        // Allows passing the parameter as type string instead of an ObjectId structure. 
        // Mongo handles the conversion from string to ObjectId.
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; }

        public string Director { get; set; }

        public double Rating { get; set; }
    }

}
