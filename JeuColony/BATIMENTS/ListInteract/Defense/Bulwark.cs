using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments.ListInteract.Defense
{
    class Bulwark:MainClass.DefenseBatiment
    {
        protected int Protection { get; set; }
        public Bulwark(int size, int[] coordinate, bool state, int level) : base(size, coordinate, state, level)
        {

        }
        protected override int GenerateProtection(int level)
        {
            return level * 5;
        }
    }
}
