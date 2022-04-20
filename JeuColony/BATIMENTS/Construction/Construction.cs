using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.Batiments
{
    internal class Construction : Batiment
    {
        public Construction(MapGame Map) : base(Map)
        {
        }
        public Construction(int[] coord , MapGame Map) : base(coord, Map) { }

    }
}
