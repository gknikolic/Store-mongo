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

namespace MongoNBP
{
    public partial class Racunarii : Form
    {
        List<Racunari> prom = new List<Racunari>();
        public Racunarii()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Racunari nesto = prom.ElementAt(e.RowIndex);
            Prikazi d1 = new Prikazi(nesto, "RR");
            d1.Show();
            this.Close();
        }

        private void Racunarii_Load(object sender, EventArgs e)
        {

            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Racunari>("Racunari");

            var rez = collection.AsQueryable<Racunari>().ToList();

            var source = new BindingSource();
            source.DataSource = rez;
            prom = rez; //-------------------------------------------
            dataGridView1.DataSource = source;

            dataGridView1.DataSource = rez.Select(o => new
            { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Racunari>("Racunari");


            if (comboBox1.Text == "Cena silazno")
            {
                var rez = collection.AsQueryable<Racunari>().OrderByDescending(p => p.Cena).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else if (comboBox1.Text == "Proizvodjac silazno")
            {
                var rez = collection.AsQueryable<Racunari>().OrderByDescending(p => p.Proizvodjac).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else
            {
                var rez = collection.AsQueryable<Racunari>().ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
        }
    }
}
