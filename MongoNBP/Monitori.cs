using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;


using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoNBP
{
    class Monitori
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Proizvodjac")]
        public string Proizvodjac { get; set; }
        [BsonElement("Naziv")]
        public string Naziv { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Dijagonala_Ekrana")]
        public string Dijagona_Ekrana { get; set; }
        [BsonElement("Panel")]
        public string Panel { get; set; }
        [BsonElement("Odaziv")]
        public string Odaziv { get; set; }
        [BsonElement("Cena")]
        public string Cena { get; set; }
        //[BsonElement("Prodavnice")]
        public MongoDBRef Prodavnice { get; set; }
    }
}
