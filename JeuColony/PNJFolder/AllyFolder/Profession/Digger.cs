using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Digger : Ally
    {
        public Digger(Dormitory D) : base(D) { Profession = "Digger"; }
        protected override void GenerateDiggingPower()
        {
            DiggingPower = 2;
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
