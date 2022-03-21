using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Pioneer : Ally , IAllyCalculus
    {
        public Pioneer(string name,int level) : base(name, level) { }
        protected virtual void GenerateLoggingPower()
        {
            LoggingPower = 1;
        }
        protected virtual void GenerateDiggingPower()
        {
            DiggingPower = 1;
        }
        protected virtual void GenerateBuildingPower()
        {
            BuildingPower = 1;
        }
        protected virtual void GenerateVisionRange()
        {
            VisionRange = 2;
        }
        
    }
}
