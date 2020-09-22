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
    public partial class TV : Form
    {
        public TV()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }

        private void TV_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");

            var rez = collection.AsQueryable<Stampaci_i_Skeneri>().ToList();

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
            var collection = db.GetCollection<Stampaci_i_Skeneri>("Stampaci_I_Skeneri");


            if (comboBox1.Text == "Cena silazno")
            {
                var rez = collection.AsQueryable<Stampaci_i_Skeneri>().OrderByDescending(p => p.Cena).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else if (comboBox1.Text == "Proizvodjac silazno")
            {
                var rez = collection.AsQueryable<Stampaci_i_Skeneri>().OrderByDescending(p => p.Proizvodjac).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else
            {
                var rez = collection.AsQueryable<Stampaci_i_Skeneri>().ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
        }
        List<Stampaci_i_Skeneri> prom = new List<Stampaci_i_Skeneri>();
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Stampaci_i_Skeneri nesto = prom.ElementAt(e.RowIndex);
            Prikazi d1 = new Prikazi(nesto, "SIS");
            d1.Show();
            this.Close();
        }
    }
}
