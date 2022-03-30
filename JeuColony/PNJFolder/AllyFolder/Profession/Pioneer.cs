using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Pioneer : Ally
    {
        public Pioneer(string name, Dormitory D) : base(name,D) { }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 1;
        }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 1;
        }
        protected override void GenerateBuildingPower()
        {
            BuildingPower = 1;
        }

    }
}
