using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPA_JIPP
{
    public partial class add_player : Form
    {

        public Refresh loadlistBox;
        public add_player()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pname = textBox1.Text;
            int plevel = int.Parse(textBox2.Text);
            int pdamage = int.Parse(textBox3.Text);
            string pclass = textBox4.Text;
            int pexp = int.Parse(textBox5.Text);
            string pguild = textBox6.Text;
            DB.Instance.insertPlayerData(pname,plevel,pdamage,pclass,pexp,pguild);
            this.loadlistBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_player_Load(object sender, EventArgs e)
        {

        }
    }
}
