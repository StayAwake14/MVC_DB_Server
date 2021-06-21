using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WPA_JIPP
{
    public sealed class DB
    {
        //DB Instance using singleton method
        private static DB _instance = null;
        private SqlConnection connection = new SqlConnection(@"Data source=DESKTOP-B78D0R3\CODEASTER;database=Game;User id=sa;Password=12345;");

        private DB()
        {

        }

        public static DB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DB();
                }
                return _instance;
            }
        }

        public void openConnection()
        {
            this.connection.Open();
        }

        public void closeConnection()
        {
            this.connection.Close();
        }

        public List<string> getPlayer(string pname)
        {
            openConnection();
            SqlCommand SQL = this.connection.CreateCommand();
            SQL.Parameters.AddWithValue("@pname", pname);
            SQL.CommandText = "SELECT * FROM Players WHERE pname=@pname";
            SqlDataReader readData = SQL.ExecuteReader();
            List<string> playersList = new List<string>();
            while (readData.Read())
            {
                playersList.Add(readData["pname"].ToString());
                playersList.Add(readData["plevel"].ToString());
                playersList.Add(readData["p_damage"].ToString());
                playersList.Add(readData["p_class"].ToString());
                playersList.Add(readData["p_exp"].ToString());
                playersList.Add(readData["p_guild"].ToString());
            }

            readData.Close();
            closeConnection();
            return playersList;
        }

        public List<string> loadData()
        {
            openConnection();
            SqlCommand SQL = this.connection.CreateCommand();
            SQL.CommandText = "SELECT pname FROM Players";
            SqlDataReader readData = SQL.ExecuteReader();
            List<string> playersList = new List<string>();
            while (readData.Read())
            {
                playersList.Add(readData["pname"].ToString());
            }

            readData.Close();
            closeConnection();
            return playersList;
        }

        public bool login(string login, string password)
        {
            openConnection();
            SqlCommand SQL = this.connection.CreateCommand();
            SQL.Parameters.AddWithValue("@login", login);
            SQL.Parameters.AddWithValue("@password", password);
            SQL.CommandText = "SELECT * FROM Users WHERE login=@login AND password=@password";
            SqlDataReader readUser = SQL.ExecuteReader();

            if (readUser.HasRows)
            {
                readUser.Close();
                closeConnection();
                return true;
            }
            else
            {
                readUser.Close();
                closeConnection();
                return false;
            }
        }

        public bool searchPlayer(string name)
        {
            openConnection();
            SqlCommand SQL = this.connection.CreateCommand();
            SQL.Parameters.AddWithValue("@name", name);
            SQL.CommandText = "SELECT pname FROM Players WHERE pname=@name";
            SqlDataReader readUser = SQL.ExecuteReader();
            if (readUser.HasRows)
            {
                readUser.Close();
                closeConnection();
                return true;
            }
            else
            {
                readUser.Close();
                closeConnection();
                return false;
            }
        }

        public void deletePlayer(string pname)
        {
            openConnection();

            string query = "DELETE FROM Players WHERE pname='" + pname + "'";

            using (SqlCommand cmd = new SqlCommand(query, this.connection))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Player deleted successfully!", "Success");
            }

            closeConnection();
        }

        public void insertPlayerData(string name, int level, int damage, string profession, int exp, string guild)
        {
            if (name == "")
            {
                MessageBox.Show("Player name cannot be empty!", "Notification");
            }
            else if (profession == "")
            {
                MessageBox.Show("Player profession cannot be empty!", "Notification");
            }
            else if (profession == "")
            {
                MessageBox.Show("Player guild cannot be empty!", "Notification");
            }
            else
            {
                openConnection();
                string query = "INSERT INTO Players(pname,plevel,p_damage,p_class,p_exp,p_guild) VALUES('" + name + "','" + level + "','" + damage + "','" + profession + "','" + exp + "','" + guild + "')";

                using (SqlCommand cmd = new SqlCommand(query, this.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player added successfully!", "Success");
                }

                closeConnection();
            }
        }

        public void updatePlayerData(string old_name, string name, int level, int damage, string profession, int exp, string guild)
        {
            if (name == "")
            {
                MessageBox.Show("Player name cannot be empty!", "Notification");
            }
            else if (profession == "")
            {
                MessageBox.Show("Player profession cannot be empty!", "Notification");
            }
            else if (profession == "")
            {
                MessageBox.Show("Player guild cannot be empty!", "Notification");
            }
            else
            {
                openConnection();
                string query = "UPDATE Players SET pname='" + name + "', plevel='" + level + "', p_damage='" + damage + "', p_class='" + profession + "', p_exp='" + exp + "', p_guild='" + guild + "' WHERE pname='" + old_name + "'";

                using (SqlCommand cmd = new SqlCommand(query, this.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player updated successfully!", "Success");
                }

                closeConnection();
            }
        }
    }
}
