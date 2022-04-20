using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JeuColony.Batiments;

namespace JeuColony.PNJFolder
{
     abstract class Ally : PNJ
    {
        public int DiggingPower { get; set; }
        protected int BuildingPower { get; set; }
        public int LoggingPower { get; set; }
        protected Batiment BatimentOccupied { get; set; }
        public string Profession { get; set; }
        public bool Immobilized { get; set; }

        static protected Random random = new Random();
        public Ally(Batiment B, MapGame M) : base(GenerateName(), M)
        {
            Immobilized = false;
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
            (Coordinate[0],Coordinate[1]) = (B.Coordinate[0], B.Coordinate[1]);
            BatimentOccupied = B;
            B.AddPNJ(this);
        }
        public override string PagePNJ()
        {
            return base.PagePNJ() + "Profession : " + Profession;
        }
        protected List<Batiment> CreateListBatimentDormintory()
        {

            List<Batiment> list = new List<Batiment>();
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (B is Dormitory D)
                {
                    list.Add(D);
                }
            }
            return list;
        }
        protected Batiment MostNearObject(List<Batiment> list)
        {
            try
            {
                int iRes = 0;
                double distMin = int.MaxValue;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] is Batiment O)
                    {
                        if (HowFarFrom(O.Coordinate) < distMin)
                        {
                            distMin = HowFarFrom(O.Coordinate);
                            iRes = i;
                        }
                    }
                }
                return list[iRes];
            }
            catch (ArgumentOutOfRangeException)
            {
                return MostNearObject(CreateListBatimentDormintory());
            }
        }
        protected abstract List<Batiment> CreateListBatiment();
        public override void PlayOneTurn()
        {
            Batiment B = MostNearObject(CreateListBatiment());
            if (!Immobilized)
            {
                if ((Coordinate[0], Coordinate[1]) == (B.Coordinate[0], B.Coordinate[1]))
                {
                    ExecuteAction(B);
                }
                else
                {
                    MoveTo(B.Coordinate);
                }
            }
        }
        public override void Die()
        {
            MapGame.ListPNJAlly.Remove(this);
        }
    }
}
