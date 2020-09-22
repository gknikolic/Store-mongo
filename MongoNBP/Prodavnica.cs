using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoNBP
{
    class Prodavnica
    {
        public ObjectId Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public List<MongoDBRef> Mobilni_Uredjaji { get; set; }
        public List<MongoDBRef> Prenosni_Racunari { get; set; }
        public List<MongoDBRef> Racunari { get; set; }
        public List<MongoDBRef> Racunarske_Komponente { get; set; }
        public List<MongoDBRef> Racunarska_Oprema { get; set; }
        public List<MongoDBRef> Audio { get; set; }
        public List<MongoDBRef> TV { get; set; }
        public List<MongoDBRef> Bela_Tehnika { get; set; }
        public List<MongoDBRef> Kuhinjski_Aparati { get; set; }
        public List<MongoDBRef> Kucni_Aparati { get; set; }
        public List<MongoDBRef> Grejna_Tela { get; set; }

        public Prodavnica()
        {
            Mobilni_Uredjaji = new List<MongoDBRef>();
            Prenosni_Racunari = new List<MongoDBRef>();
            Racunari = new List<MongoDBRef>();
            Racunarske_Komponente = new List<MongoDBRef>();
            Racunarska_Oprema = new List<MongoDBRef>();
            Audio = new List<MongoDBRef>();
            TV = new List<MongoDBRef>();
            Bela_Tehnika = new List<MongoDBRef>();
            Kuhinjski_Aparati = new List<MongoDBRef>();
            Kucni_Aparati = new List<MongoDBRef>();
            Grejna_Tela = new List<MongoDBRef>();


        }
    }
}
