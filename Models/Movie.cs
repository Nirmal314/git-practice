using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.JSInterop;

namespace Exploration.Models
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("plot")]
        public string Plot { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; }

        [BsonElement("runtime")]
        public Runtime Runtime { get; set; }

        [BsonElement("cast")]
        public List<string> Cast { get; set; }

        [BsonElement("poster")]
        public string Poster { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("fullplot")]
        public string FullPlot { get; set; }

        [BsonElement("languages")]
        public List<string> Languages { get; set; }

        [BsonElement("released")]
        public DateTime Released { get; set; }

        [BsonElement("directors")]
        public List<string> Directors { get; set; }

        [BsonElement("rated")]
        public string Rated { get; set; }

        [BsonElement("awards")]
        public Awards Awards { get; set; }

        [BsonElement("lastupdated")]
        public DateTime LastUpdated { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("imdb")]
        public Imdb Imdb { get; set; }

        [BsonElement("countries")]
        public List<string> Countries { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("tomatoes")]
        public Tomatoes Tomatoes { get; set; }

        [BsonElement("num_mflix_comments")]
        public int NumMflixComments { get; set; }

    }
    public class Runtime
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Awards
    {
        public Wins Wins { get; set; }

        public Nominations Nominations { get; set; }

        public string Text { get; set; }
    }

    public class Wins
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Nominations
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Imdb
    {
        public Rating Rating { get; set; }

        public Votes Votes { get; set; }

        public Id Id { get; set; }
    }

    public class Rating
    {
        [BsonElement("$numberDouble")]
        public double Value { get; set; }
    }

    public class Votes
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Id
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Tomatoes
    {
        public Viewer Viewer { get; set; }

        public Fresh Fresh { get; set; }

        public Critic Critic { get; set; }

        public Rotten Rotten { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    public class Viewer
    {
        public Rating Rating { get; set; }

        public NumReviews NumReviews { get; set; }

        public Meter Meter { get; set; }
    }

    public class Fresh
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Critic
    {
        public Rating Rating { get; set; }

        public NumReviews NumReviews { get; set; }

        public Meter Meter { get; set; }
    }

    public class Rotten
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class NumReviews
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }

    public class Meter
    {
        [BsonElement("$numberInt")]
        public int Value { get; set; }
    }
}
