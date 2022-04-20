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
        public Enemy(string name,int level,MapGame M) : base(name,level, M) { Spawn(); }
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
        protected override void GenerateSpeed()
        {
            Speed = 1;
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
            A.HealthPoint -= AttackPower * 5;
            HealthPoint -= A.AttackPower * 5;
            if(A.HealthPoint < 0)
            {
                A.Die();
            }
            if(HealthPoint < 0)
            {
                A.Immobilized = false;
                Die();
            }
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
        }
        public override void Die()
        {
            MapGame.ListPNJEnemy.Remove(this);

        }
        protected void Spawn()
        {
            Coordinate[0] = random.Next(MapGame.Nbl);
            Coordinate[1] = random.Next(MapGame.Nbc);
        }
    }
}
