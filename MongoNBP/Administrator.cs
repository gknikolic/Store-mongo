using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoNBP
{
    public partial class Administrator : Form
    {
        //List<Label> labele;
        public Administrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
           // labele.Add(label1);
          //  labele.Add(label2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="")
            {
                MessageBox.Show("Morate odabrati kategoriju");
                return;
            }
            Dodaj d1 = new Dodaj(comboBox1.Text);
            d1.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Morate odabrati kategoriju");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Morate uneti model !!!");
                return;
            }
            Dodaj d1 = new Dodaj(comboBox1.Text, "da", textBox1.Text);
            d1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Morate odabrati kategoriju");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Morate uneti model !!!");
                return;
            }

            string kat = comboBox1.Text;
            string mod = textBox1.Text;
            MongoDB.Bson.BsonObjectId idd = null;

            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");

            if (kat == "Prenosni racunari")
            {
                var collection = db.GetCollection<Prenosni_Racunari>("Prenosni_Racunari");

                var rez = collection.AsQueryable<Prenosni_Racunari>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Prenosni_Racunari>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");
            }
            if (kat == "Racunari")
            {
                var collection = db.GetCollection<Racunari>("Racunari");

                var rez = collection.AsQueryable<Racunari>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Racunari>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");
            }
            if (kat == "Mobilni uredjaji")
            {
                var collection = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");

                var rez = collection.AsQueryable<Mobilni_Uredjaji>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Mobilni_Uredjaji>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Misevi")
            {
                var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");

                var rez = collection.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Tastature")
            {
                var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");

                var rez = collection.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Web kamere")
            {
                var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");

                var rez = collection.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Slusalice")
            {
                var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");

                var rez = collection.AsQueryable<Audio_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Zvucnici")
            {
                var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");

                var rez = collection.AsQueryable<Audio_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Mikrofoni")
            {
                var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");

                var rez = collection.AsQueryable<Audio_Oprema>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }

            if (kat == "Monitori")
            {
                var collection = db.GetCollection<Monitori>("Monitori");

                var rez = collection.AsQueryable<Monitori>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Monitori>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Stampaci")
            {
                var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");

                var rez = collection.AsQueryable<Stampaci_i_Skeneri>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Stampaci_i_Skeneri>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
            if (kat == "Skeneri")
            {
                var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");

                var rez = collection.AsQueryable<Stampaci_i_Skeneri>().Where(x => x.Model == mod).ToList();
                foreach (var pp in rez)
                {
                    idd = pp.Id;
                }

                var result = collection.DeleteOne(Builders<Stampaci_i_Skeneri>.Filter.Eq("_id", idd));
                MessageBox.Show("Obrisano");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Kategorije k1 = new Kategorije();
            k1.Show();
         
        }
    }
}
