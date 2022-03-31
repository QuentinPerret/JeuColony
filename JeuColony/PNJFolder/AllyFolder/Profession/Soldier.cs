using JeuColony.Batiments;
namespace JeuColony.PNJFolder
{
    class Soldier : Ally
    {
        public Soldier(string name,TrainingCamp T) : base(name,T) { }
        protected override void GenerateHealthPointMax()
        {
            HealthPointMax = 30 * Level;
        }
        protected override void GenerateAttackPower()
        {
            AttackPower = 3 * Level;
        }
        public override string PagePNJ()
        {
            return base.PagePNJ() + "Profession : Soldier";
        }
    }
}
