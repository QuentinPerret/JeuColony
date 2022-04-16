using System;
using System.IO;
using System.Text;
using JeuColony.Batiments;

namespace JeuColony.PNJFolder
{
    class Ally : PNJ
    {
        protected int DiggingPower { get; set; }
        protected int BuildingPower { get; set; }
        protected int LoggingPower { get; set; }
        protected Batiment BatimentOccupied { get; set; }
        public string Profession { get; set; }

        static protected Random random = new Random();
        public Ally(Batiment B) : base(GenerateName())
        {
            GenerateAllStat();
            Spawn(B);
        }
        static protected string GenerateName()
        {
            var Fpath = @"..\..\Gaming\ListPrenom.txt";
            //C:\Users\Utilisateur\source\repos\JeuColony\JeuColony\Gaming\ListPrenom.txt
            //C:\Users\Utilisateur\source\repos\JeuColony\JeuColony\PNJFolder\AllyFolder\Ally.cs
            string[] content = File.ReadAllLines (Fpath, Encoding.UTF8);
            return content[random.Next(content.Length)];
        }
        protected override void GenerateAllStat()
        {
            GenerateAttackPower();
            GenerateDiggingPower();
            GenerateHealthPointMax();
            GenerateHealthPoint();
            GenerateLoggingPower();
            GenerateSpeed();
        }
        protected virtual void GenerateHealthPointMax()
        {
            HealthPointMax = 20 * Level;
        }
        protected virtual void GenerateHealthPoint()
        {
            HealthPoint = HealthPointMax;
        }
        protected virtual void GenerateAttackPower()
        {
            AttackPower = 2 * Level;
        }
        protected virtual void GenerateLoggingPower()
        {
            LoggingPower = 0;
        }
        protected virtual void GenerateDiggingPower()
        {
            DiggingPower = 0;
        }
        protected virtual void GenerateBuildingPower()
        {
            BuildingPower = 0;
        }
        protected override void GenerateSpeed()
        {
            Speed = 1;
        }
        protected void Spawn(Batiment B)
        {
            Coordinate = B.Coordinate;
            BatimentOccupied = B;
            B.AddPNJ(this);
        }
        public override string PagePNJ()
        {
            return base.PagePNJ() + "Profession : " + Profession;
        }
    }
}
