using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Soldier : Ally
    {
        public Soldier(string name,TrainingCamp T) : base(name,T) { Profession = "Soldier"; }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 30 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3 * Level;
        }
    }
}
