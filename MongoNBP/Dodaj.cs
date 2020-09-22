using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Collections;


namespace MongoNBP
{
    public partial class Dodaj : Form
    {
        Label[] labele = new Label[10];

        public Dodaj()
        {
            
            InitializeComponent();

            labele[0] = lbl1;
            labele[1] = lbl2;
            labele[2] = lbl3;
            labele[3] = lbl4;
            labele[4] = lbl5;
            labele[5] = lbl6;
            labele[6] = lbl7;
            labele[7] = lbl8;
            labele[8] = lbl9;
            labele[9] = lbl10;
            
        }
        public string kat;
        public string update_da = "ne";
        public string modell;
        public MongoDB.Bson.BsonObjectId idd;
        public Dodaj(string kategorija)
        {

            InitializeComponent();
            kat = kategorija;

            labele[0] = lbl1;
            labele[1] = lbl2;
            labele[2] = lbl3;
            labele[3] = lbl4;
            labele[4] = lbl5;
            labele[5] = lbl6;
            labele[6] = lbl7;
            labele[7] = lbl8;
            labele[8] = lbl9;
            labele[9] = lbl10;

        }

        public Dodaj(string kategorija, string update, string model)
        {

            InitializeComponent();
            kat = kategorija;
            update_da = update;
            modell = model;

            labele[0] = lbl1;
            labele[1] = lbl2;
            labele[2] = lbl3;
            labele[3] = lbl4;
            labele[4] = lbl5;
            labele[5] = lbl6;
            labele[6] = lbl7;
            labele[7] = lbl8;
            labele[8] = lbl9;
            labele[9] = lbl10;



        }

        private void Dodaj_Load(object sender, EventArgs e)
        {

            if(kat == "Prenosni racunari")
            {
                Prenosni_Racunari p1 = new Prenosni_Racunari();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length-2; i++)
                {
                    labele[i].Text = properti[i+1].Name;
                }

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Prenosni_Racunari>("Prenosni_Racunari");
                    var rez = collectionPR.AsQueryable<Prenosni_Racunari>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.RAM;
                        txtbox5.Text = pp.Procesor;
                        txtbox6.Text = pp.Graficka_Kartica;
                        txtbox7.Text = pp.Hard_Disk;
                        txtbox8.Text = pp.Dijagona_Ekrana;
                        txtbox9.Text = pp.Kamera;
                        txtbox10.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }
            }
            if (kat == "Racunari")
            {
                Racunari p1 = new Racunari();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length-2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Racunari>("Racunari");
                    var rez = collectionPR.AsQueryable<Racunari>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.RAM;
                        txtbox4.Text = pp.Model;
                        txtbox5.Text = pp.Procesor;
                        txtbox6.Text = pp.Maticna_Ploca;
                        txtbox7.Text = pp.Napajanje;
                        txtbox8.Text = pp.Graficka_Kartica;
                        txtbox9.Text = pp.Hard_Disk;
                        txtbox10.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }
            }
            if (kat == "Mobilni uredjaji")
            {
                Mobilni_Uredjaji p1 = new Mobilni_Uredjaji();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");
                    var rez = collectionPR.AsQueryable<Mobilni_Uredjaji>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.RAM;
                        txtbox5.Text = pp.Procesor;
                        txtbox6.Text = pp.Dijagona_Ekrana;
                        txtbox7.Text = pp.Kamera;
                        txtbox8.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Misevi")
            {
                Racunarska_Oprema p1 = new Racunarska_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[6].Text = "DPI";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var rez = collectionPR.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Povezanost;
                        txtbox6.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Tastature")
            {
                Racunarska_Oprema p1 = new Racunarska_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[6].Text = "Odziv";
                labele[7].Text = "Vodootpornost";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var rez = collectionPR.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Povezanost;
                        txtbox6.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Web kamere")
            {
                Racunarska_Oprema p1 = new Racunarska_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[6].Text = "MPX";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var rez = collectionPR.AsQueryable<Racunarska_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Povezanost;
                        txtbox6.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Slusalice")
            {
                Audio_Oprema p1 = new Audio_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[5].Text = "Noice canceling";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var rez = collectionPR.AsQueryable<Audio_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Zvucnici")
            {
                Audio_Oprema p1 = new Audio_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[5].Text = "Izlazna snaga";
                labele[6].Text = "Materijal izrade";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var rez = collectionPR.AsQueryable<Audio_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Cena;
                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Mikrofoni")
            {
                Audio_Oprema p1 = new Audio_Oprema();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[5].Text = "Range";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var rez = collectionPR.AsQueryable<Audio_Oprema>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Tip;
                        txtbox5.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }
            }
            if (kat == "Monitori")
            {
                Monitori p1 = new Monitori();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Monitori>("Monitori");
                    var rez = collectionPR.AsQueryable<Monitori>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Dijagona_Ekrana;
                        txtbox5.Text = pp.Panel;
                        txtbox6.Text = pp.Odaziv;
                        txtbox7.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }
            if (kat == "Stampaci")
            {
                Stampaci_i_Skeneri p1 = new Stampaci_i_Skeneri();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }
                labele[6].Text = "U boji ?";

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_i_Skeneri");
                    var rez = collectionPR.AsQueryable<Stampaci_i_Skeneri>().Where(x => x.Model == modell).ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Format;
                        txtbox5.Text = pp.Tip;
                        txtbox6.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }


            }
            if (kat == "Skeneri")
            {
                Stampaci_i_Skeneri p1 = new Stampaci_i_Skeneri();
                System.Reflection.PropertyInfo[] properti = p1.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    labele[i].Text = properti[i + 1].Name;
                }

                if (update_da == "da")
                {
                    var client = new MongoClient("mongodb://localhost/?safe=true");
                    var db = client.GetDatabase("Katalog");

                    var collectionPR = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_i_Skeneri");
                    var rez = collectionPR.AsQueryable<Stampaci_i_Skeneri>().ToList();
                    foreach (var pp in rez)
                    {
                        txtbox1.Text = pp.Proizvodjac;
                        txtbox2.Text = pp.Naziv;
                        txtbox3.Text = pp.Model;
                        txtbox4.Text = pp.Format;
                        txtbox5.Text = pp.Tip;
                        txtbox6.Text = pp.Cena;

                        idd = pp.Id;
                    }

                }

            }





            if (lbl1.Text == "")
            {
                txtbox1.Visible = false;
            }
            if (lbl2.Text == "")
            {
                txtbox2.Visible = false;
            }
            if (lbl3.Text == "")
            {
                txtbox3.Visible = false;
            }
            if (lbl4.Text == "")
            {
                txtbox4.Visible = false;
            }
            if (lbl5.Text == "")
            {
                txtbox5.Visible = false;
            }
            if (lbl6.Text == "")
            {
                txtbox6.Visible = false;
            }
            if (lbl7.Text == "")
            {
                txtbox7.Visible = false;
            }
            if (lbl8.Text == "")
            {
                txtbox8.Visible = false;
            }
            if (lbl9.Text == "")
            {
                txtbox9.Visible = false;
            }
            if (lbl10.Text == "")
            {
                txtbox10.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Administrator a1 = new Administrator();
            a1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");

            if(update_da == "da")
            {
                if (kat == "Prenosni racunari")
                {
                    var collection = db.GetCollection<Prenosni_Racunari>("Prenosni_Racunari");
                    var result = collection.UpdateOne(Builders<Prenosni_Racunari>.Filter.Eq("_id", idd), 
                    Builders<Prenosni_Racunari>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Ram", txtbox4.Text).Set("Procesor", txtbox5.Text).Set("Graficka_Kartica", txtbox6.Text).Set("Hard_Disk", txtbox7.Text).Set("Dijagonala_Ekrana", txtbox8.Text).Set("Kamera", txtbox9.Text).Set("Cena", txtbox10.Text));
                    MessageBox.Show("Azurirano");
                }
                if (kat == "Racunari")
                {
                    var collection = db.GetCollection<Racunari>("Racunari");
                    var result = collection.UpdateOne(Builders<Racunari>.Filter.Eq("_id", idd),
                    Builders<Racunari>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Ram", txtbox4.Text).Set("Procesor", txtbox5.Text).Set("Maticna_Ploca", txtbox6.Text).Set("Napajanje", txtbox7.Text).Set("Graficka_Kartica", txtbox8.Text).Set("Hard_Disk", txtbox9.Text).Set("Cena", txtbox10.Text));
                    MessageBox.Show("Azurirano");
                }
                if (kat == "Mobilni uredjaji")
                {
                    var collection = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");
                    var result = collection.UpdateOne(Builders<Mobilni_Uredjaji>.Filter.Eq("_id", idd),
                    Builders<Mobilni_Uredjaji>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Ram", txtbox4.Text).Set("Procesor", txtbox5.Text).Set("Dijagona_Ekrana", txtbox6.Text).Set("Kamera", txtbox7.Text).Set("Cena", txtbox8.Text));
                    MessageBox.Show("Azurirano");


                }
                if (kat == "Misevi")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var result = collection.UpdateOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd),
                    Builders<Racunarska_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Povezanost", txtbox5.Text).Set("Cena", txtbox6.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Tastature")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var result = collection.UpdateOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd),
                    Builders<Racunarska_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Povezanost", txtbox5.Text).Set("Cena", txtbox6.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Web kamere")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    var result = collection.UpdateOne(Builders<Racunarska_Oprema>.Filter.Eq("_id", idd),
                    Builders<Racunarska_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Povezanost", txtbox5.Text).Set("Cena", txtbox6.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Slusalice")
                {
                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var result = collection.UpdateOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd),
                    Builders<Audio_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Cena", txtbox5.Text));
                    MessageBox.Show("Azurirano");


                }
                if (kat == "Zvucnici")
                {
                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var result = collection.UpdateOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd),
                    Builders<Audio_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Cena", txtbox5.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Mikrofoni")
                {
                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var result = collection.UpdateOne(Builders<Audio_Oprema>.Filter.Eq("_id", idd),
                    Builders<Audio_Oprema>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Tip", txtbox4.Text).Set("Cena", txtbox5.Text));
                    MessageBox.Show("Azurirano");

                }

                if (kat == "Monitori")
                {
                    var collection = db.GetCollection<Monitori>("Monitori");
                    var result = collection.UpdateOne(Builders<Monitori>.Filter.Eq("_id", idd),
                    Builders<Monitori>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Dijagona_Ekrana", txtbox4.Text).Set("Panel", txtbox5.Text).Set("Odaziv", txtbox6.Text).Set("Cena", txtbox7.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Stampaci")
                {
                    var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");
                    var result = collection.UpdateOne(Builders<Stampaci_i_Skeneri>.Filter.Eq("_id", idd),
                    Builders<Stampaci_i_Skeneri>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Format", txtbox4.Text).Set("Tip", txtbox5.Text).Set("Cena", txtbox6.Text));
                    MessageBox.Show("Azurirano");

                }
                if (kat == "Skeneri")
                {
                    var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");
                    var result = collection.UpdateOne(Builders<Stampaci_i_Skeneri>.Filter.Eq("_id", idd),
                    Builders<Stampaci_i_Skeneri>.Update.Set("Proizvodjac", txtbox1.Text).Set("Naziv", txtbox2.Text).Set("Model", txtbox3.Text).Set("Format", txtbox4.Text).Set("Tip", txtbox5.Text).Set("Cena", txtbox6.Text));
                    MessageBox.Show("Azurirano");

                }
            }
            else
            {
                if (kat == "Prenosni racunari")
                {
                    var collection = db.GetCollection<Prenosni_Racunari>("Prenosni_Racunari");
                    var collectionProd = db.GetCollection<Prodavnica>("Prodavnica");

                    Prodavnica prod = new Prodavnica();

                    if (comboBox1.Text == "WinWin")
                    {
                        prod = new Prodavnica() { Naziv = "WinWin", Adresa = "Aleksandra Medvedeva 1" };
                    }
                    else if (comboBox1.Text == "Gigatron")
                    {
                        prod = new Prodavnica() { Naziv = "Gibatron", Adresa = "Aleksandra Medvedeva 12" };
                    }
                    else if (comboBox1.Text == "Emmi")
                    {
                        prod = new Prodavnica() { Naziv = "Emmi", Adresa = "Aleksandra Medvedeva 8" };
                    }
                    else
                    {
                        MessageBox.Show("Izaberite Prodavnicu");
                    }


                    Prenosni_Racunari pr = new Prenosni_Racunari { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, RAM = txtbox4.Text, Procesor = txtbox5.Text, Graficka_Kartica = txtbox6.Text, Hard_Disk = txtbox7.Text, Dijagona_Ekrana = txtbox8.Text, Kamera = txtbox9.Text, Cena = txtbox10.Text };
                    prod.Prenosni_Racunari.Add(new MongoDBRef("prenosni_racunari", pr.Id));
                    pr.Prodavnice = new MongoDBRef("prodavnice", prod.Id);

                    //collectionProd.InsertOne(prod);
                    collection.InsertOne(pr);

                }
                if (kat == "Racunari")
                {
                    var collection = db.GetCollection<Racunari>("Racunari");
                    Racunari pr = new Racunari { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, RAM = txtbox4.Text, Procesor = txtbox5.Text, Maticna_Ploca = txtbox6.Text, Napajanje = txtbox7.Text, Graficka_Kartica = txtbox8.Text, Hard_Disk = txtbox9.Text, Cena = txtbox10.Text };
                    collection.InsertOne(pr);
                }
                if (kat == "Mobilni uredjaji")
                {
                    var collection = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");
                    Mobilni_Uredjaji pr = new Mobilni_Uredjaji { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, RAM = txtbox4.Text, Procesor = txtbox5.Text, Dijagona_Ekrana = txtbox6.Text, Kamera = txtbox7.Text, Cena = txtbox8.Text };
                    collection.InsertOne(pr);

                }
                if (kat == "Misevi")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    Racunarska_Oprema pr = new Racunarska_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Povezanost = txtbox5.Text, Cena = txtbox6.Text, Karakteristike = new List<string> { txtbox7.Text }    };
                    collection.InsertOne(pr);

                }
                if (kat == "Tastature")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    Racunarska_Oprema pr = new Racunarska_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Povezanost = txtbox5.Text, Cena = txtbox6.Text, Karakteristike = new List<string> { txtbox7.Text, txtbox8.Text } };
                    collection.InsertOne(pr);

                }
                if (kat == "Web kamere")
                {
                    var collection = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
                    Racunarska_Oprema pr = new Racunarska_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Povezanost = txtbox5.Text, Cena = txtbox6.Text, Karakteristike = new List<string> { txtbox7.Text } };
                    collection.InsertOne(pr);

                }
                if (kat == "Slusalice")
                {

                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var collectionProd = db.GetCollection<Prodavnica>("Prodavnica");

                    Prodavnica prod = new Prodavnica();

                    if (comboBox1.Text == "WinWin")
                    {
                        prod = new Prodavnica() { Naziv = "WinWin", Adresa = "Aleksandra Medvedeva 1" };
                    }
                    else if (comboBox1.Text == "Gibatron")
                    {
                        prod = new Prodavnica() { Naziv = "Gibatron", Adresa = "Aleksandra Medvedeva 12" };
                    }
                    else if (comboBox1.Text == "Emmi")
                    {
                        prod = new Prodavnica() { Naziv = "Emmi", Adresa = "Aleksandra Medvedeva 8" };
                    }
                    else
                    {
                        MessageBox.Show("Izaberite Prodavnicu");
                    }

                    Audio_Oprema pr = new Audio_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Cena = txtbox5.Text, Karakteristike = new List<string> { txtbox6.Text } };
                    prod.Audio.Add(new MongoDBRef("audio_oprema", pr.Id));
                    pr.Prodavnice = new MongoDBRef("prodavnice", prod.Id);
                    //collectionProd.InsertOne(prod);
                    collection.InsertOne(pr);
                    

                }
                if (kat == "Zvucnici")
                {
                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    Audio_Oprema pr = new Audio_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Cena = txtbox5.Text, Karakteristike = new List<string> { txtbox6.Text, txtbox7.Text } };
                    collection.InsertOne(pr);

                }
                if (kat == "Mikrofoni")
                {
                    var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    Audio_Oprema pr = new Audio_Oprema { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Tip = txtbox4.Text, Cena = txtbox5.Text, Karakteristike = new List<string> { txtbox6.Text, txtbox7.Text } };
                    collection.InsertOne(pr);

                }

                if (kat == "Monitori")
                {
                    var collection = db.GetCollection<Monitori>("Monitori");
                    Monitori pr = new Monitori { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Dijagona_Ekrana = txtbox4.Text, Panel = txtbox5.Text, Odaziv = txtbox6.Text, Cena = txtbox7.Text };
                    collection.InsertOne(pr);

                }
                if (kat == "Stampaci")
                {
                    var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");
                    Stampaci_i_Skeneri pr = new Stampaci_i_Skeneri { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Format = txtbox4.Text, Tip = txtbox5.Text, Cena = txtbox6.Text, Karakteristike = new List<string> { txtbox7.Text } };
                    collection.InsertOne(pr);

                }
                if (kat == "Skeneri")
                {
                    var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_i_Skeneri");
                    Stampaci_i_Skeneri pr = new Stampaci_i_Skeneri { Proizvodjac = txtbox1.Text, Naziv = txtbox2.Text, Model = txtbox3.Text, Format = txtbox4.Text, Tip = txtbox5.Text, Cena = txtbox6.Text, Karakteristike = new List<string> {  } };
                    collection.InsertOne(pr);

                }

                MessageBox.Show("Predmet je dodat");
                Administrator a2 = new Administrator();
                a2.Show();
                this.Close();
            }

            


        }
    }
}
