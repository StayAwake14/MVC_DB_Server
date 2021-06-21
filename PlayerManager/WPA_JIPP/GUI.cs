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
    public partial class GUI : Form
    {
        bool login = false;
        public GUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public bool loginStatus()
        {
            if (this.login == false)
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var pass = textBox2.Text;
            if(DB.Instance.login(login,pass) == true)
            {
                this.login = true;
                MessageBox.Show("Connected to the system", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else
            {
                MessageBox.Show("User does not exist. Try again.", "Information",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }
    }
}
