using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ
{
    abstract class PNJ
    {
        public string Name { get; }
        private int HealthPointMax { get; }
        private int HealthPoint { get; set; }
        private int AttackPower { get; set; }
        private int VisionRange { get; set; }
        private int Speed { get; set; }
        public int[] Coordinate { get; set; }
        public PNJ(string name, int healthpointmax, int healthpoint, int attackpower, int visionrange, int[] coordinate)
        {
            Name = name;
            HealthPointMax = healthpointmax;
            HealthPoint = healthpoint;
            AttackPower = attackpower;
            VisionRange = visionrange;
            Coordinate = coordinate;
        }
    }
}
