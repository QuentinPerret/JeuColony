using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Forester : Ally
    {
        public Forester(string name , Dormitory D) : base(name,D) { }
        protected override void GenerateLoggingPower()
        {
            LoggingPower = 2;
        }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 25 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 2 * Level + 1;
        }
    }
}
