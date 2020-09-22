using MongoDB.Driver;
using System;
using System.Collections;
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
    public partial class Kategorije : Form
    {
        public Kategorije()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MobilniUredjaji f4 = new MobilniUredjaji();
            f4.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PrenosniRacunari f5 = new PrenosniRacunari();
            f5.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Racunarii f6 = new Racunarii();
            f6.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RacunarskaOprema f8 = new RacunarskaOprema();
            f8.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Audio_Opremaa f9 = new Audio_Opremaa();
            f9.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Monitorii f9 = new Monitorii();
            f9.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TV f10 = new TV();
            f10.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start s1 = new Start();
            s1.Show();
            this.Hide();
        }


        List<object> rezPret = new List<object>();
        List<Sve> rezSvePret = new List<Sve>();
        int pretragaKljuc = 0;
        int pretragaBrisanje = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(pretragaBrisanje == 2)
            {
                rezPret.Clear();
                rezSvePret.Clear();
            }
            //MyClass result = list.Find(x => x.GetId() == "xy");
            if(txtnazivpretrazi.Text != null && txtnazivpretrazi.Text != "") { 
            rezSvePret.Add(objekti.Find(x => x.Naziv == txtnazivpretrazi.Text));
            if (rezSvePret.ElementAt(0) != null) { rezPret.Add(lol[rezSvePret.ElementAt(0)]); }
            else { rezSvePret.Clear(); }

                

            if (!rezSvePret.Any())
            {
                rezSvePret.Add(objekti.Find(x => x.Model == txtnazivpretrazi.Text));
                if (rezSvePret.ElementAt(0) != null) { rezPret.Add(lol[rezSvePret.ElementAt(0)]); }
                else { rezSvePret.Clear(); }
            }
            if (rezSvePret.Any())
            {
                pretragaKljuc = 2;
                pretragaBrisanje = 2;
            }
            var source = new BindingSource();
            source.DataSource = rezSvePret;
            //prom = rez; //-------------------------------------------
            dataGridView1.DataSource = source;

            dataGridView1.DataSource = rezSvePret.Select(o => new
            { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena, Tip = o.Tip }).ToList();


            }
        }

        Hashtable lol = new Hashtable();
        List<Sve> objekti = new List<Sve>();
        private void Kategorije_Load(object sender, EventArgs e)
        {
            
       

            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("katalog");

            var collectionAU = db.GetCollection<Audio_Oprema>("Audio_Oprema");
            var collectionMU = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");
            var collectionM = db.GetCollection<Monitori>("Monitori");
            var collectionPR = db.GetCollection<Prenosni_Racunari>("Prenosni_Racunari");
            var collectionR = db.GetCollection<Racunari>("Racunari");
            var collectionRO = db.GetCollection<Racunarska_Oprema>("Racunarska_Oprema");
            var collectionSIS = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");

            var rezAU = collectionAU.AsQueryable<Audio_Oprema>().ToList();
            foreach(var rezz in rezAU)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Audio Oprema";
                objekti.Add(nesto);
                lol.Add(nesto, rezz); 

            }
         
             var rezMU = collectionMU.AsQueryable<Mobilni_Uredjaji>().ToList();
             foreach (var rezz in rezMU)
             {
                 Sve nesto = new Sve();
                 nesto.Proizvodjac = rezz.Proizvodjac;
                 nesto.Naziv = rezz.Naziv;
                 nesto.Model = rezz.Model;
                 nesto.Cena = rezz.Cena;
                 nesto.Tip = "Mobilni Uredjaji";
                 objekti.Add(nesto);
                 lol.Add(nesto, rezz);
             }
            var rezM = collectionM.AsQueryable<Monitori>().ToList();
            foreach (var rezz in rezM)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Monitori";
                objekti.Add(nesto);
                lol.Add(nesto, rezz);
            }
            var rezPR = collectionPR.AsQueryable<Prenosni_Racunari>().ToList();
            foreach (var rezz in rezPR)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Prenosni Racunari";
                objekti.Add(nesto);
                lol.Add(nesto, rezz);
            }
            var rezR = collectionR.AsQueryable<Racunari>().ToList();
            foreach (var rezz in rezR)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Racunari";
                objekti.Add(nesto);
                lol.Add(nesto, rezz);
            }
            var rezRO = collectionRO.AsQueryable<Racunarska_Oprema>().ToList();
            foreach (var rezz in rezRO)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Racunarska oprema";
                objekti.Add(nesto);
                lol.Add(nesto, rezz);
            }
            var rezSIS = collectionSIS.AsQueryable<Stampaci_i_Skeneri>().ToList();
            foreach (var rezz in rezSIS)
            {
                Sve nesto = new Sve();
                nesto.Proizvodjac = rezz.Proizvodjac;
                nesto.Naziv = rezz.Naziv;
                nesto.Model = rezz.Model;
                nesto.Cena = rezz.Cena;
                nesto.Tip = "Stampaci i Skeneri";
                objekti.Add(nesto);
                lol.Add(nesto, rezz);
            }


            var source = new BindingSource();
            source.DataSource = objekti;
            //prom = rez; //-------------------------------------------
            dataGridView1.DataSource = source;

            dataGridView1.DataSource = objekti.Select(o => new
            { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena, Tip = o.Tip }).ToList();
            //var query = db.GetCollection<Audio_Oprema>("Audio_Oprema").AsQueryable().Join(db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji"), audio_oprema => audio_oprema.Id, mobilni_uredjaji => mobilni_uredjaji.Id, (audio_oprema, mobilni_uredjaji) => audio_oprema);

        }

        //Hashtable ht3 = new Hashtable();

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pretragaKljuc == 2)
            {
                objekti = rezSvePret;
                Hashtable ht2 = new Hashtable();
                ht2.Add(rezSvePret.ElementAt(0), rezPret.ElementAt(0));
                lol = ht2;
            }

            object nesto = lol[objekti.ElementAt(e.RowIndex)];


            if (objekti.ElementAt(e.RowIndex).Tip == "Audio Oprema")
            {
                Prikazi d1 = new Prikazi(nesto, "AO");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Mobilni Uredjaji")
            {
                Prikazi d1 = new Prikazi(nesto, "MU");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Monitori")
            {
                Prikazi d1 = new Prikazi(nesto, "MM");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Prenosni Racunari")
            {
                Prikazi d1 = new Prikazi(nesto, "PR");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Stampaci i Skeneri")
            {
                Prikazi d1 = new Prikazi(nesto, "SIS");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Racunarska oprema")
            {
                Prikazi d1 = new Prikazi(nesto, "RO");
                d1.Show();
                this.Close();
            }
            if (objekti.ElementAt(e.RowIndex).Tip == "Racunari")
            {
                Prikazi d1 = new Prikazi(nesto, "RR");
                d1.Show();
                this.Close();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Prodavnicee p1 = new Prodavnicee();
            p1.Show();
            this.Close();
        }
    }
}
