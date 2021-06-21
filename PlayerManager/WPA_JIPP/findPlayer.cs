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
    public partial class findPlayer : Form
    {
        public findPlayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DB.Instance.searchPlayer(textBox1.Text))
            {
                MessageBox.Show("Player exists in database!", "Notification");
            }
            else
            {
                MessageBox.Show("Player does not exist in database!", "Notification");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
