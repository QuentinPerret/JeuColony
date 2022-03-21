using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    class Scout : Ally 
    {
        public Scout(string name,int level) : base(name, level) { }
        protected override void GenerateVisionRange()
        {
            VisionRange = 3;
        }
        protected override void GenerateSpeed()
        {
            Speed = 2;
        }
    }
}
