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
    public partial class MobilniUredjaji : Form
    {

        List<Mobilni_Uredjaji> prom = new List<Mobilni_Uredjaji>();
        public MobilniUredjaji()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }

        private void MobilniUredjaji_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");
            var collection = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");

            var rez = collection.AsQueryable<Mobilni_Uredjaji>().ToList();
            if (rez == null)
            {
                MessageBox.Show(null);
            }
            foreach (Mobilni_Uredjaji mb in rez)
            {
                MessageBox.Show(mb.Naziv);
            }
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
            var collection = db.GetCollection<Mobilni_Uredjaji>("Mobilni_Uredjaji");


            if (comboBox1.Text == "Cena silazno")
            {
                var rez = collection.AsQueryable<Mobilni_Uredjaji>().OrderByDescending(p => p.Cena).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else if (comboBox1.Text == "Proizvodjac silazno")
            {
                var rez = collection.AsQueryable<Mobilni_Uredjaji>().OrderByDescending(p => p.Proizvodjac).ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
            else
            {
                var rez = collection.AsQueryable<Mobilni_Uredjaji>().ToList();

                var source = new BindingSource();
                source.DataSource = rez;
                dataGridView1.DataSource = source;

                dataGridView1.DataSource = rez.Select(o => new
                { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Mobilni_Uredjaji nesto = prom.ElementAt(e.RowIndex);
            Prikazi d1 = new Prikazi(nesto, "MU");
            d1.Show();
            this.Close();
        }
    }
}
