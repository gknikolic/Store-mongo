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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

            txtboxpass.PasswordChar = '*';
        
            txtboxpass.CharacterCasing = CharacterCasing.Lower;
            
            txtboxpass.TextAlign = HorizontalAlignment.Center;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(txtboxpass.Text == "")
            {
                MessageBox.Show("Morate uneti password za administratora", "Error");
                return;
            }

            if(txtboxpass.Text == "0000")
            {
                Administrator f2 = new Administrator();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Morate uneti ispravan password");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategorije f3 = new Kategorije();
            f3.Show();
            this.Hide();
        }
    }
}
