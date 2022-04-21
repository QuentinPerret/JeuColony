using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JeuColony.PNJFolder;

namespace JeuColony.PNJFolder
{
    class Enemy :PNJ
    {
        public string Profession { get; set; }
        public Enemy(string name, MapGame M) : base(name, M)
        {
            Spawn();
            GenerateAllStat();
        }
        protected virtual void GenerateHealthPointMax()
        {
            HealthPointMax = 20;
        }
        protected virtual void GenerateHealthPoint()
        {
            HealthPoint = 20;
        }
        protected virtual void GenerateAttackPower()
        {
            AttackPower = 2;
        }
        protected override void GenerateSpeed()
        {
            Speed = 2;
        }
        protected override void GenerateAllStat()
        {
            GenerateAttackPower();
            GenerateHealthPointMax();
            GenerateHealthPoint();
            GenerateSpeed();
        }
        protected override void ExecuteAction(object O)
        {
            Ally A = O as Ally;
            A.Immobilized = true;
            A.HealthPoint -= AttackPower;
            HealthPoint -= A.AttackPower;
        }
        protected List<Ally> CreateListPnj()
        {
            List<Ally> list = new List<Ally>();
            foreach (Ally P in MapGame.ListPNJAlly)
            {
                list.Add(P);
            }
            return list;
        }
        //check what the nearest object is
        protected Ally MostNearObject(List<Ally> list)
        {
            Ally Pres = null;
            double distMin = int.MaxValue;
            foreach(Ally P in list)
            {
                if (HowFarFrom(P.Coordinate) < distMin)
                {
                    distMin = HowFarFrom(P.Coordinate);
                    Pres = P;
                }
            }
            return Pres;
        }
        public override void PlayOneTurn()
         {
            Ally P = MostNearObject(CreateListPnj());
            if ((Coordinate[0], Coordinate[1]) == (P.Coordinate[0], P.Coordinate[1]))
            {
                ExecuteAction(P);
            }
            else
            {
                MoveTo(P.Coordinate);
            }
            TestDeath();
        }
        public override void TestDeath()
        {
            if(HealthPoint < 0)
            {
                MapGame.ListPNJEnemy.Remove(this);
            }

        }
        protected void Spawn()
        {
            Coordinate[0] = random.Next(MapGame.Nbl);
            Coordinate[1] = random.Next(MapGame.Nbc);
        }
    }
}
