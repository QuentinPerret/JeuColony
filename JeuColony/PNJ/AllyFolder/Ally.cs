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
        protected bool TaskOccupied { get; set; }
        public Ally(string name, int level) : base(name, level)
        {
            GenerateAllStat();
            TaskOccupied = false;
        }
        protected override void GenerateAllStat()
        {
            GenerateAttackPower();
            GenerateDiggerPower();
            GenerateHealthPointMax();
            GenerateHealthPoint();
            GenerateLoggingPower();
            GenerateSpeed();
            GenerateVisionRange();
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
        protected virtual void GenerateDiggerPower()
        {
            LoggingPower = 0;
        }
        protected virtual void GenerateVisionRange()
        {
            VisionRange = 1;
        }
        protected override void Spawn(Batiment B)
        {
            
        }
    }
}
