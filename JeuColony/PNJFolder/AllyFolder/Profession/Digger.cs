using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Digger : Ally
    {
        public Digger(string name,Dormitory D) : base(name,D) { }
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
