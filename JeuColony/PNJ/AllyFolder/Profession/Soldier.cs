using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Soldier : Ally ,IAllyCalculus
    {
        public Soldier(string name,int level) : base(name, level) { }
        protected virtual void GenerateHealthPointMax()
        {
            HealthPointMax = 30 * Level;
        }
        protected virtual void GenerateAttackPower()
        {
            AttackPower = 3 * Level;
        }
    }
}
