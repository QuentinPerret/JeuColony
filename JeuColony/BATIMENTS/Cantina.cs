namespace JeuColony.Batiments
{
    class Cantina : Batiment
    {
        public Cantina(int[] size, bool state, GameSimulation M) : base(size, M)
        {
            HealthPointMax = 500;
            BatimentType = "Cantina";
            //GenerateBatiment(size, coordinate, state, 1);
        }
        protected int GenerateCapaMax(int level)
        {
            return level * 3;
        }
        protected override void GenerateStat()
        {
            HealthPoint = HealthPointMax * 9 * Level;
        }
        public override string ToString()
        {
            return " C ";
        }
    }
}
