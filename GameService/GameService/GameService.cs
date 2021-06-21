using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : Game
    {
        List<string> players = new List<string>();
        List<string> monsters = new List<string>();
        public GameService()
        {
            Console.WriteLine("Sever has been started.");
            Sunny w = new Sunny();
            w.Environment("Sunny");
            w.Rain();
            w.Temperature(22);
        }

        public void whoFight()
        {
            Console.WriteLine(this.players[0] + " Vs. " + this.monsters[0]);
        }

        public void loadPlayer(string player)
        {
            players.Add(player);
        }
        public void loadMonster(string monster)
        {
            monsters.Add(monster);
        }

        public bool signIn(string name)
        {
            Console.WriteLine("Uzytkownik:" + name + " dołączył do sesji.");
            return true;
        }

    }

    //Template Method
    abstract class Weather
    {
        int c;
        string env;

        public abstract void Rain();

        public virtual void Environment(string e)
        {
            this.env = e;
            Console.WriteLine("The weather is: " + this.env + "");
        }

        public virtual void Temperature(int t)
        {
            this.c = t;
            Console.WriteLine("On a server games is:" + this.c + " C");
        }

        public void showWeather()
        {
            Temperature(this.c);
        }
    }

    class Sunny : Weather
    {
        public override void Rain()
        {
            Console.WriteLine("There is no rain because it's SUNNY!");
        }
    }

    class Rainy : Weather
    {
        public override void Rain()
        {
            Console.WriteLine("What a rainy day!");
        }
    }
}
