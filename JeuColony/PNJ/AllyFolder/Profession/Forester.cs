using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Forester : Ally 
    {
        public Forester(string name,int level) : base(name, level) { }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 2 * Level + 1;
        }
    }
}
