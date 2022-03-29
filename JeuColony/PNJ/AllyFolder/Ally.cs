using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;

namespace JeuColony.PNJ.AllyFolder
{
    class Ally : PNJ 
    {
        protected int DiggingPower { get; set; }
        protected int BuildingPower { get; set; }
        protected int LoggingPower { get; set; }
        protected bool TaskOccupied { get; set; }
        public Ally(string name, int level) : base(name, level)
        {
            GenerateAllStat();
            TaskOccupied = false;
        }
        protected override void GenerateAllStat()
        {
            GenerateAttackPower();
            GenerateDiggingPower();
            GenerateHealthPointMax();
            GenerateHealthPoint();
            GenerateLoggingPower();
            GenerateSpeed();
        }
        protected virtual void GenerateHealthPointMax()
        {
            HealthPointMax = 20 * Level;
        }
        protected virtual void GenerateHealthPoint()
        {
            HealthPoint = HealthPointMax;
        }
        protected virtual void GenerateAttackPower()
        {
            AttackPower = 2 * Level;
        }
        protected virtual void GenerateLoggingPower()
        {
            LoggingPower = 0;
        }
        protected virtual void GenerateDiggingPower()
        {
            DiggingPower = 0;
        }
        protected virtual void GenerateBuildingPower(){
            BuildingPower =0;
        }
        protected override void GenerateSpeed()
        {
            Speed = 1;
        }
        protected void MoveTo(int[] Coord)
        {
            Coordinate = Coord;
        }
        protected void Spawn(Batiment B)
        {
            Coordinate = B.Coordinate;
        }
    }
}
