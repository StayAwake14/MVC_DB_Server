using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPA_JIPP // Facade
{
    class playerName
    {
        public string setPlayerName(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[0];
        }
    }

    class playerLevel
    {
        public string setPlayerLevel(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[1];
        }
    }


    class playerDamage
    {
        public string setPlayerDamage(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[2];
        }
    }

    class playerProfession
    {
        public string setPlayerProfession(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[3];
        }
    }

    class playerExp
    {
        public string setPlayerExp(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[4];
        }
    }

    class playerGuild
    {
        public string setPlayerGuild(string name)
        {
            var list = DB.Instance.getPlayer(name);
            return list[5];
        }
    }

    public interface IPlayer
    {
        string getInfo();
    }


    public class humanDecorator : IPlayer
    {
        private string fightType;
        private string raceType;
        public humanDecorator() 
        {
            this.fightType = "Melee";
            this.raceType = "Human";
        }

        public string getInfo() 
        {
            return "Your attack type: " + this.fightType + ". You're from " + this.raceType + " race";
        }
    }

    public class elfDecorator : IPlayer
    {
        private string fightType;
        private string raceType;
        public elfDecorator()
        {
            this.fightType = "Distance";
            this.raceType = "Elf";
        }

        public string getInfo()
        {
            return "Your attack type: " +this.fightType+". You're from "+this.raceType+" race";
        }
    }

    abstract class Decorator : IPlayer
    {
        protected IPlayer p;

        public Decorator(IPlayer player)
        {
            p = player;
        }

        public string getInfo()
        {
           return p.getInfo();
        }
    }


    class PlayerFacade : Decorator
    {
        private readonly playerName pname;
        private readonly playerLevel plevel;
        private readonly playerDamage pdamage;
        private readonly playerProfession pclass;
        private readonly playerExp pexp;
        private readonly playerGuild pguild;


        public PlayerFacade(IPlayer p):base(p) 
        {
            pname = new playerName();
            plevel = new playerLevel();
            pdamage = new playerDamage();
            pclass = new playerProfession();
            pexp = new playerExp();
            pguild = new playerGuild();
        }

        public List<string> loadPlayer(string name)
        {
            List<string> playerData = new List<string>();
            playerData.Add(pname.setPlayerName(name));
            playerData.Add(plevel.setPlayerLevel(name));
            playerData.Add(pdamage.setPlayerDamage(name));
            playerData.Add(pclass.setPlayerProfession(name));
            playerData.Add(pexp.setPlayerExp(name));
            playerData.Add(pguild.setPlayerGuild(name));
            return playerData;
        }

    }
}
