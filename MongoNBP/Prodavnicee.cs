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
    public partial class Prodavnicee : Form
    {
        public Prodavnicee()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorije k1 = new Kategorije();
            k1.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost/?safe=true");
            var db = client.GetDatabase("Katalog");

            if(comboBox1.Text == "WinWin")
            {
                if(comboBox2.Text == "Audio Oprema")
                {
                    var collectionAO = db.GetCollection<Audio_Oprema>("Audio_Oprema");
                    var collectionPROD = db.GetCollection<Prodavnica>("Prodavnica");

                    List<Audio_Oprema> audioO = new List<Audio_Oprema>();

                    //System.Collections.Generic.List<Prodavnica>

                    List<Prodavnica> rez = collectionPROD.AsQueryable<Prodavnica>().Where(x => x.Naziv == "WinWin").ToList();

                    
                        foreach (MongoDBRef audioRaf in rez.ElementAt(0).Audio)
                        {
                          Audio_Oprema audio_op = collectionAO.AsQueryable<Audio_Oprema>().Where(x => x.Id == audioRaf.Id).First();
                          audioO.Add(audio_op);
                        }

                        var source = new BindingSource();
                        source.DataSource = audioO;
                        dataGridView1.DataSource = source;

                        dataGridView1.DataSource = audioO.Select(o => new
                        { Proizvodjac = o.Proizvodjac, Naziv = o.Naziv, Model = o.Model, Cena = o.Cena }).ToList();
                }
                

            }


        }
            
    }
}
