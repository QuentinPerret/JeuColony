using JeuColony.Batiments;

namespace JeuColony.PNJFolder
{
    class Ally : PNJ
    {
        protected int DiggingPower { get; set; }
        protected int BuildingPower { get; set; }
        protected int LoggingPower { get; set; }
        protected bool TaskOccupied { get; set; }
        public Ally(string name , Batiment B) : base(name)
        {
            GenerateAllStat();
            TaskOccupied = false;
            Spawn(B);
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
        protected virtual void GenerateBuildingPower()
        {
            BuildingPower = 0;
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
