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
    public partial class Audio_Opremaa : Form
    {
        List<Audio_Oprema> prom = new List<Audio_Oprema>();

        public Audio_Opremaa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");


            if (comboBox1.Text == "Cena silazno")
            {
                var rez = collection.AsQueryable<Audio_Oprema>().OrderByDescending(p => p.Cena).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else if (comboBox1.Text == "Proizvodjac silazno")
            {
                var rez = collection.AsQueryable<Audio_Oprema>().OrderByDescending(p => p.Proizvodjac).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else
            {
                var rez = collection.AsQueryable<Audio_Oprema>().ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
        }

        private void Audio_Opremaa_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Audio_Oprema>("Audio_Oprema");

            var rez = collection.AsQueryable<Audio_Oprema>().ToList();

            var source = new BindingSource();

            source.DataSource = rez;
            prom = rez; //-------------------------------------------
            dataGridView1.DataSource = source;

            dataGridView1.DataSource = rez.Select(o => new
            { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Audio_Oprema nesto = prom.ElementAt(e.RowIndex);
            Prikazi d1 = new Prikazi(nesto, "AO");
            d1.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
