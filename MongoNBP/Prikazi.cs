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
    public partial class Prikazi : Form
    {
        public Prikazi()
        {
            InitializeComponent();
        }

        Prenosni_Racunari pr;
        Racunari rr;
        Stampaci_i_Skeneri sis;
        Racunarska_Oprema ro;
        Monitori mm;
        Mobilni_Uredjaji mu;
        Audio_Oprema ao;
        Label[] labeleOz = new Label[11];
        Label[] labeleOb = new Label[11];
        string identf;
        object instanca;

        public Prikazi(object prom, string ident)
        {
            InitializeComponent();
            identf = ident;

            labeleOz[0] = label1;
            labeleOz[1] = label2;
            labeleOz[2] = label3;
            labeleOz[3] = label4;
            labeleOz[4] = label5;
            labeleOz[5] = label6;
            labeleOz[6] = label7;
            labeleOz[7] = label8;
            labeleOz[8] = label9;
            labeleOz[9] = label10;
            labeleOz[10] = label11;

            labeleOb[0] = label12;
            labeleOb[1] = label13;
            labeleOb[2] = label14;
            labeleOb[3] = label15;
            labeleOb[4] = label16;
            labeleOb[5] = label17;
            labeleOb[6] = label18;
            labeleOb[7] = label19;
            labeleOb[8] = label20;
            labeleOb[9] = label21;
            labeleOb[10] = label22;

            if (ident == "PR")
            {
                pr = (Prenosni_Racunari)prom;
                instanca = pr;
            }
            else if (ident == "RR")
            {
                rr = (Racunari)prom;
                instanca = rr;
            }
            else if (ident == "SIS")
            {
                sis = (Stampaci_i_Skeneri)prom;
                instanca = sis;
            }
            else if (ident == "RO")
            {
                ro = (Racunarska_Oprema)prom;
                instanca = ro;
            }
            else if (ident == "MM")
            {
                mm = (Monitori)prom;
                instanca = mm;
            }
            else if (ident == "MU")
            {
                mu = (Mobilni_Uredjaji)prom;
                instanca = mu;
            }
            else if (ident == "AO")
            {
                ao = (Audio_Oprema)prom;
                instanca = ao;
            }
            
        }

        private void Prikazi_Load(object sender, EventArgs e)
        {
            
                System.Reflection.PropertyInfo[] properti = instanca.GetType().GetProperties();
                for (int i = 0; i < properti.Length - 2; i++)
                {
                    List<string> ss = new List<string>();
                    string pomocni = "";
                    object pom = new object();
                    labeleOz[i].Text = properti[i + 1].Name;
                    string s = properti[i + 1].Name;
                    if(properti[i + 1].Name == "Karakteristike")
                    {
                        ss = (List<string>)instanca.GetType().GetProperty("Karakteristike").GetValue(instanca);
                        int newl = 0;
                        foreach(string sss in ss)
                        {
                            if (newl == 0)
                            {
                                pomocni = sss;
                            }
                            else {
                            pomocni = pomocni + System.Environment.NewLine + sss;
                            
                            }
                            newl++;
                        }
                        labeleOb[i].Text = pomocni;
                    }
                    else
                    {
                        labeleOb[i].Text = instanca.GetType().GetProperty(properti[i + 1].Name).GetValue(instanca).ToString();
                    }
                    //labeleOb[i].Text = instanca.GetType().GetProperty(properti[i + 1].Name).GetValue(instanca).ToString();
                    
                    //labeleOz[i + 10].Text = pom.ToString();
                }
            
            /*else if (identf == "RR")
            {
                rr = (Racunari)prom;
            }
            else if (identf == "SIS")
            {
                sis = (Stampaci_i_Skeneri)prom;
            }
            else if (identf == "RO")
            {
                ro = (Racunarska_Oprema)prom;
            }
            else if (identf == "MM")
            {
                mm = (Monitori)prom;
            }
            else if (identf == "MU")
            {
                mu = (Mobilni_Uredjaji)prom;
            }
            else if (identf == "AO")
            {
                ao = (Audio_Oprema)prom;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategorije k1 = new Kategorije();
            k1.Show();
            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
