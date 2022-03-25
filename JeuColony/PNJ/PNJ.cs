using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ
{
    abstract class PNJ
    {
        public string Name { get; }
        protected int HealthPointMax { get; set; }
        protected int HealthPoint { get; set; }
        protected int AttackPower { get; set; }
        protected int VisionRange { get; set; }
        protected int Speed { get; set; }
        protected int Level { get; set; }
        public int[] Coordinate { get; set; }
        public PNJ(string name,int level)
        {
            Name = name;
            Level = level;
        }
        protected abstract void GenerateAllStat();
        protected abstract void GenerateSpeed();
        protected void DealDamage(PNJ Dealer,PNJ Target)
        {
            Target.HealthPoint -= Dealer.AttackPower;
        }
    }
}
