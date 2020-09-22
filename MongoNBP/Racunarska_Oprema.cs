using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoNBP
{
    class Racunarska_Oprema
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Proizvodjac")]
        public string Proizvodjac { get; set; }
        [BsonElement("Naziv")]
        public string Naziv { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Tip")]
        public string Tip { get; set; }
        [BsonElement("Povezanost")]
        public string Povezanost { get; set; }
        [BsonElement("Cena")]
        public string Cena { get; set; }
        [BsonElement("Krakteristike")]
        public List<string> Karakteristike { get; set; }
        //[BsonElement("Prodavnice")]
        public MongoDBRef Prodavnice { get; set; }

    }
}
