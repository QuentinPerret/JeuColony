namespace JeuColony.Batiments
{
    class Dormitory : Batiment
    {
        public Dormitory(int[] size, bool state, GameSimulation M) : base(size, M)
        {
            HealthPointMax = 100;
            BatimentType = "Dormitory";
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 5 * Level;
        }
        public override string ToString()
        {
            return " D ";
        }
    }
}
