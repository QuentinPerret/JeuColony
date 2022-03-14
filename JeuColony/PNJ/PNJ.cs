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
        protected int HealthPointMax { get; }
        protected int HealthPoint { get; set; }
        protected int AttackPower { get; set; }
        protected int VisionRange { get; set; }
        protected int Speed { get; set; }
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
        protected abstract void GenerateAllStat();
        protected abstract void GenerateSpeed();
        protected abstract void MoveTo();

    }
}
