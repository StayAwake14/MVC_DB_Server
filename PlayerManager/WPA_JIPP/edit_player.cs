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
    public partial class edit_player : Form
    {
        public List<string> playerData;
        private string name;
        public Refresh loadlistBox;
        public edit_player()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void playerEditName(string name)
        {
            this.name = name;
        }

        private void loadData()
        {
            elfDecorator h1 = new elfDecorator();
            PlayerFacade player = new PlayerFacade(h1);
            playerData = player.loadPlayer(this.name);
            textBox1.Text = playerData[0];
            textBox2.Text = playerData[1];
            textBox3.Text = playerData[2];
            textBox4.Text = playerData[3];
            textBox5.Text = playerData[4];
            textBox6.Text = playerData[5];
            MessageBox.Show(player.getInfo(), "Notification");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string old_name = playerData[0];
            string new_name = textBox1.Text;
            int level = Convert.ToInt32(textBox2.Text);
            int damage = Convert.ToInt32(textBox3.Text);
            string profession = textBox4.Text;
            int exp = Convert.ToInt32(textBox5.Text);
            string guild = textBox6.Text;
            DB.Instance.updatePlayerData(old_name, new_name, level,damage,profession,exp,guild);
            this.name = new_name;
            loadData();
            this.loadlistBox();
        }

        private void edit_player_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
