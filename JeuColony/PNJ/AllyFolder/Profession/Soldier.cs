using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Soldier : Ally 
    {
        public Soldier(string name,int level) : base(name, level) { }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 30 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3 * Level;
        }
    }
}
