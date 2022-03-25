using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;

namespace JeuColony.GenMap
{
    class InterfaceMap
    {
        //protected Random r = new Random();
        public InterfaceMap(){  }
        public void ListeBat(BaseMap baseMap)
        {
            foreach(Batiment B in baseMap._listBatiments)
            {
                Console.WriteLine(B)
            }
        }

    }
}
