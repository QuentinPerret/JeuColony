using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Builder : Ally
    {
        public Builder(string name, int healthpointmax, int healthpoint, int attackpower, int visionrange, int[] coordinate, int diggerpower, int buildingpower, int loggingpower) : base(name, healthpointmax, healthpoint, attackpower, visionrange, coordinate, diggerpower, buildingpower, loggingpower) { }
        
    }
}
