using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Scout : Ally ,IAllyCalculus
    {
        public Scout(string name,int level) : base(name, level) { }
        protected virtual void GenerateVisionRange()
        {
            VisionRange = 3;
        }
    }
}
