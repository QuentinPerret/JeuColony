using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Pioneer : Ally 
    {
        public Pioneer(string name,int level) : base(name, level) { }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 1;
        }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 1;
        }
        protected override void GenerateBuildingPower()
        {
            BuildingPower = 1;
        }
        protected override void GenerateVisionRange()
        {
            VisionRange = 2;
        }
        
    }
}
