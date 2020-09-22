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
    public partial class Monitorii : Form
    {

        List<Monitori> prom = new List<Monitori>();

        public Monitorii()
        {
            InitializeComponent();
        }

        private void Monitorii_Load(object sender, EventArgs e)
        {

            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Monitori>("Monitori");

            var rez = collection.AsQueryable<Monitori>().ToList();

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
            var collection = db.GetCollection<Monitori>("Monitori");


            if (comboBox1.Text == "Cena silazno")
            {
                var rez = collection.AsQueryable<Monitori>().OrderByDescending(p => p.Cena).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else if (comboBox1.Text == "Proizvodjac silazno")
            {
                var rez = collection.AsQueryable<Monitori>().OrderByDescending(p => p.Proizvodjac).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else
            {
                var rez = collection.AsQueryable<Monitori>().ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                prom = rez; //-------------------------------------------
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
                Monitori nesto = prom.ElementAt(e.RowIndex);
                Prikazi d1 = new Prikazi(nesto, "MM");
                d1.Show();
                this.Close();
            
        }
    }
}
