using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemm.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  = String.Empty;

        [BsonElement("ISBN")]
        public string ISBN { get; set; } = String.Empty;

        [BsonElement("NAME")]
        public string NAME { get; set; } = String.Empty;

        [BsonElement("PAGENUMBER")]
        public string PAGENUMBER { get; set; } = String.Empty;

        [BsonElement("LANGUAGE")]
        public string LANGUAGE { get; set; } = String.Empty;

        [BsonElement("CATEGORY")]
        public string CATEGORY { get; set; } = String.Empty;

        [BsonElement("Completed")]
        public bool Completed { get; set; }


    }
}
