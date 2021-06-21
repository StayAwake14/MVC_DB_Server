using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using GS = GameService;
//Singleton, Facade, Builder, Template method, Decorator
namespace WPA_JIPP
{
    public delegate void Refresh();
    public partial class Form1 : Form
    {

        public string selectedPlayer;
        public string selectedMonster;
        public bool connected = false;
        private GS.GameService1 game;
        public Form1()
        {
            InitializeComponent();
            GUI loginPanel = new GUI();
            loginPanel.ShowDialog();
            if(loginPanel.loginStatus() == false)
            {
                Environment.Exit(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_player addPanel = new add_player();
            addPanel.loadlistBox += loadlistBox;
            addPanel.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadlistBox();

            //AI and make it monster Builder method
            AI AIM = new AI();

            aiBuilder m1 = new Monster();
            aiBuilder m2 = new Monster();

            //Construct monster
            AIM.spawnMonster(m1);
            AIM.spawnMonster(m2);
            m1.setName("Skeleton");
            m2.setName("Ork");
            listBox2.Items.Add(m1.getName());
            listBox2.Items.Add(m2.getName());

            this.game = new GS.GameService1();

            ServiceHost host = new ServiceHost(game);

            host.Open();

        }
        private void loadlistBox()
        {
            listBox1.Items.Clear();
            var list = DB.Instance.loadData();
            foreach (string elem in list)
            {
                listBox1.Items.Add(elem);
            }
            listBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB.Instance.deletePlayer(this.selectedPlayer);
            loadlistBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("You need to select Player first!", "Notification");
            else
                this.selectedPlayer = listBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Using Facade method
            edit_player editPanel = new edit_player();
            editPanel.playerEditName(listBox1.SelectedItem.ToString());
            editPanel.loadlistBox += loadlistBox;
            editPanel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if((this.selectedMonster != null || this.selectedMonster != null) && this.connected == false)
            {                
                Task.Run(() =>
                {
                    if (game.signIn(this.selectedPlayer) == true)
                    {
                        game.loadPlayer(this.selectedPlayer);
                        game.loadMonster(this.selectedMonster);
                        game.whoFight();
                    }
                });
            }
            else
            {
                MessageBox.Show("You can connect to the server once!", "Notification");
            }

            this.connected = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedMonster = listBox2.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            findPlayer findForm = new findPlayer();
            findForm.ShowDialog();
        }
    }
}
