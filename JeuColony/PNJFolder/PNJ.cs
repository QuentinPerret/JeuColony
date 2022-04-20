using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony;
using JeuColony.Batiments;

namespace JeuColony.PNJFolder
{
    abstract class PNJ
    {
        public string Name { get; }
        protected int HealthPointMax { get; set; }
        public int HealthPoint { get; set; }
        public int AttackPower { get; set; }
        protected int Speed { get; set; }
        protected int Level { get; set; }
        public int[] Coordinate { get; set; } = new int[] { -1, -1 };
        protected static readonly Random random = new Random();

        protected MapGame MapGame { get; }
        public PNJ(string name, MapGame M) : this(name, 1, M) { }
        public PNJ(string name, int level, MapGame M)
        {
            Name = name;
            Level = level;
            MapGame = M;
        }
        protected abstract void GenerateAllStat();
        protected abstract void GenerateSpeed();
        public override string ToString()
        {
            string chRes = "";
            chRes += " O " /*\n####"*/;
            return chRes;
        }
        public void DealDamage(PNJ Dealer, PNJ Target)
        {
            Target.HealthPoint -= Dealer.AttackPower;
        }
        public virtual string PagePNJ()
        {
            string chres = "";
            chres += "Name : " + Name + "\n";
            chres += "Level : " + Level + "\n";
            chres += "HP : " + HealthPoint + " / " + HealthPointMax + "\n";
            chres += "Position : " + Coordinate[0] + " , " + Coordinate[1] + "\n";
            return chres;
        }
        protected double HowFarFrom(int[] position)
        {
            return Math.Sqrt(Math.Pow((position[0] - Coordinate[0]), 2) + Math.Pow((position[1] - Coordinate[1]), 2));
        }
        public void MoveTo(int[] coordinate)
        {
            int moveLeft = Speed;
            for (int i = 0; i < moveLeft; i++)
            {
                if (Coordinate[0] < coordinate[0])
                {
                    Coordinate[0]++;
                }
                else if (Coordinate[0] > coordinate[0])
                {
                    Coordinate[0]--;
                }
                if (Coordinate[1] < coordinate[1])
                {
                    Coordinate[1]++;
                }
                else if (Coordinate[1] > coordinate[1])
                {
                    Coordinate[1]--;
                }
            }
        }
        protected abstract void ExecuteAction(object O);
        public abstract void PlayOneTurn();
        public abstract void Die();
    }
}
