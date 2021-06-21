using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IGameService
    {
        [OperationContract]
        void loadMonster(string name);

        [OperationContract]
        void loadPlayer(string name);

        [OperationContract]
        bool signIn(string name);

        string whoFight();

        // TODO: dodaj tutaj operacje usługi
    }

    public class Game
    {
        private string gameName;

        public void setGameName(string name)
        {
            this.gameName = name;
        }
    }
}
