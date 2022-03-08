using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    abstract class Ally : PNJ
    {
        private int DiggerPower { get; set; }
        private int BuildingPower { get; set; }
        private int LoggingPower { get; set; }
        public Ally(string name, int healthpointmax, int healthpoint, int attackpower,int visionrange, int[] coordinate,int diggerpower, int buildingpower, int loggingpower) : base(name,healthpointmax, healthpoint, attackpower,visionrange, coordinate)
        {
            DiggerPower = diggerpower;
            BuildingPower = buildingpower;
            LoggingPower = loggingpower;
        }
    }
}
