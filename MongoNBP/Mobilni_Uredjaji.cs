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
    class Mobilni_Uredjaji
    {
        public ObjectId Id { get; set; }
        [BsonElement("Proizvodjac")]
        public string Proizvodjac { get; set; }
        [BsonElement("Naziv")]
        public string Naziv { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Ram")]
        public string RAM { get; set; }
        [BsonElement("Procesor")]
        public string Procesor { get; set; }
        [BsonElement("Dijagonala_Ekrana")]
        public string Dijagona_Ekrana { get; set; }
        [BsonElement("Kamera")]
        public string Kamera { get; set; }
        [BsonElement("Cena")]
        public string Cena { get; set; }
        //[BsonElement("Prodavnica")]
        public MongoDBRef Prodavnice { get; set; }
    }
}
