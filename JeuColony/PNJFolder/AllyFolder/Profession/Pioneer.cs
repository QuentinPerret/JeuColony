using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Pioneer : Ally
    {
        public Pioneer(Dormitory D) : base(D) { Profession = "Pioneer"; }
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
