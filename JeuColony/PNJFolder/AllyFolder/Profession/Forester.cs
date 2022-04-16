using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Forester : Ally
    {
        public Forester (Dormitory D) : base(D) { Profession = "Forester"; }
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
