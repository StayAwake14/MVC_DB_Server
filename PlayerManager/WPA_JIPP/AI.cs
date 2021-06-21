using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPA_JIPP
{
    class AI
    {
        public AI(){ }

        public void spawnNPC(aiBuilder NPCBuilder)
        {
            NPCBuilder.createNPCBody();
        }

        public void spawnMonster(aiBuilder MonsterBuilder)
        {
            MonsterBuilder.createMonsterBody();
        }
    }

    abstract class aiBuilder
    {

        public abstract void createNPCBody();
        public abstract void createMonsterBody();
        public abstract void setName(string name);
        public abstract void setLevel(int level);
        public abstract void setRace(string race);
        public abstract void setDamage(int damage);
        public abstract string getName();
        public abstract string getType();
        public abstract bool ifCanTalk();
    }


    class Monster : aiBuilder
    {
        private string type;
        private bool talk;
        private string name;
        private int level;
        private string race;
        private int damage;
        public override void createNPCBody() { }

        public override void createMonsterBody()
        {
            this.type = "Monster";
            this.talk = false;
            this.name = "";
            this.level = 1;
            this.race = "";
            this.damage = 0;
        }
        public void setType(string type)
        {
            this.type = type;
        }

        public void canTalk(bool cantalk)
        {
            this.talk = cantalk;
        }

        public override string getType()
        {
            return this.type;
        }

        public override string getName()
        {
            return this.name;
        }

        public override bool ifCanTalk()
        {
            return this.talk;
        }

        public override void setName(string name)
        {
            this.name = name;
        }

        public override void setLevel(int level)
        {
            this.level = level;   
        }

        public override void setRace(string race)
        {
            this.race = race;
        }

        public override void setDamage(int damage)
        {
            this.damage = damage;
        }
    }

    class NPC : aiBuilder
    {
        private string type;
        private bool talk;
        private string name;
        private string race;

        public override void createNPCBody() 
        {
            this.type = "NPC";
            this.talk = false;
            this.name = "";
            this.race = "";
        }

        public override void createMonsterBody(){ }
        public override void setName(string name) 
        {
            this.name = name;
        }

        public override void setLevel(int level) { }

        public override void setRace(string race) 
        {
            this.race = race;
        }

        public override void setDamage(int damage) { }
        public void setType(string type)
        {
            this.type = type;
        }

        public void canTalk(bool cantalk)
        {
            this.talk = cantalk;
        }
        public override string getType()
        {
            return this.type;
        }

        public override bool ifCanTalk()
        {
            return this.talk;
        }
        public override string getName()
        {
            return this.name;
        }
    }
}
