using JeuColony.Batiments;
using JeuColony.PNJFolder;
using System;
using System.Collections.Generic;

namespace JeuColony
{
    internal class MapGame
    {
        public GameSimulation Simulation { get; set; }
        public int Nbl { get; }
        public int Nbc { get; }
        public Object[,] Map { get; private set; }
        public List<Batiment> ListBatiments { get; set; }
        public List<Ally> ListPNJAlly { get; set; }
        public List<Enemy> ListPNJEnemy { get; set; }
        protected Random random = new Random();
        public MapGame(GameSimulation G)
        {
            Simulation = G;
            Nbc = 30;
            Nbl = 30;
            ListBatiments = new List<Batiment>();
            ListPNJAlly = new List<Ally>();
            ListPNJEnemy = new List<Enemy>();
            Map = new Object[Nbl, Nbc];
            GenerateInitialBatiments();
            GenerateFirstColon();
        }
        public void GenerateInitialBatiments()
        {
            AddBatiment(new Dormitory(new int[] { 2, 2 }, this));
            int nbNaturalElement = 32;
            for (int i = 0; i < nbNaturalElement; i++)
            {
                int alea = random.Next(3);
                switch (alea)
                {
                    case 0:
                        AddBatiment(new Forest(this));
                        break;
                    case 1:
                        AddBatiment(new Quarry(this));
                        break;
                    case 2:
                        AddBatiment(new Water(this));
                        break;
                }
            }
        }
        public void GenerateFirstColon()
        {
            int i = 0;
            while (!(ListBatiments[i] is Dormitory))
            {
                i++;
            }
            AddPNJAlly(new Pioneer((Dormitory)ListBatiments[i], this));
            /*Random R = new Random();
            _listPNJ[0].MoveTo(new int[] { R.Next(Nbl), R.Next(Nbl) }, this);*/
        }
        public void AddBatiment(Batiment B)
        {
            ListBatiments.Add(B);
        }
        public void AddPNJAlly(Ally A)
        {
            ListPNJAlly.Add(A);
        }
        public void AddPNJEnemy(Enemy E)
        {
            ListPNJEnemy.Add(E);
        }
        public void AfficheMap()
        {
            string strRes = "  ";
            for (int i = 0; i < Nbl; i++)
            {
                strRes += " " + i;
                if (i < 10)
                {
                    strRes += " ";
                }
            }

            Console.Write(strRes);
            Console.WriteLine();
            for (int i = 0; i < Nbl; i++)
            {
                if (i < 10)
                {
                    Console.Write(" " + i);
                }
                else
                {
                    Console.Write(i);
                }
                for (int j = 0; j < Nbc; j++)
                {
                    int[] position = new int[] { i, j };
                    if (Map[i, j] != null)
                    {
                        Console.Write(Map[i, j].ToString());
                    }
                    else
                    {
                        if (AllyOnCoord(position))
                        {
                            Console.Write(" . ");
                        }
                        else if (EnemyOnCoord(position))
                        {
                            Console.Write(" * ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void AfficheMapBat(Batiment B)
        {
            string strRes = "  ";
            for (int i = 0; i < Nbl; i++)
            {
                strRes += " " + i;
                if (i < 10)
                {
                    strRes += " ";

                }
            }

            Console.Write(strRes);
            Console.WriteLine();
            for (int i = 0; i < Nbl; i++)
            {
                if (i < 10)
                {
                    Console.Write(" " + i);
                }
                else
                {
                    Console.Write(i);
                }
                for (int j = 0; j < Nbc; j++)
                {
                    int[] position = new int[] { i, j };
                    if (Map[i, j] != null)
                    {
                        if (Map[i, j] == B)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Map[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(Map[i, j]);
                        }
                    }
                    else
                    {
                        if (AllyOnCoord(position))
                        {
                            Console.Write(" . ");
                        }
                        else if (EnemyOnCoord(position))
                        {
                            Console.WriteLine(" * ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void AfficheMapPnj(PNJ P) //ajout l'affichage de tous les pnj de la liste 
        {
            string strRes = "  ";
            for (int i = 0; i < Nbl; i++)
            {
                strRes += " " + i;
                if (i < 10)
                {
                    strRes += " ";

                }
            }
            Console.Write(strRes);
            Console.WriteLine();
            for (int i = 0; i < Nbl; i++)
            {
                if (i < 10)
                {
                    Console.Write(" " + i);
                }
                else
                {
                    Console.Write(i);
                }
                for (int j = 0; j < Nbc; j++)
                {
                    int[] position = new int[] { i, j };
                    if (i == P.Coordinate[0] && j == P.Coordinate[1])
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    if (Map[i, j] != null)
                    {
                        Console.Write(Map[i, j]);
                    }
                    else if (AllyOnCoord(position))
                    {
                        Console.WriteLine(" . ");
                    }
                    else if (EnemyOnCoord(position))
                    {
                        Console.WriteLine(" * ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        private bool AllyOnCoord(int[] coord)
        {
            foreach (Ally A in ListPNJAlly)
            {
                if (A.Coordinate[0] == coord[0] && A.Coordinate[1] == coord[1])
                {
                    return true;
                }
            }
            return false;
        }
        private bool EnemyOnCoord(int[] coord)
        {
            foreach (Enemy E in ListPNJEnemy)
            {
                if (E.Coordinate[0] == coord[0] && E.Coordinate[1] == coord[1])
                {
                    return true;
                }
            }
            return false;
        }
        public void RemoveBat(Batiment B)
        {
            ListBatiments.Remove(B);
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] == B)
                    {
                        Map[i, j] = null;
                    }
                }
            }
        }
        public void TestNaturalElement()
        {
            int nbNaturalElement = 0;
            foreach(Batiment B in ListBatiments)
            {
                if(B is NaturalElement && !(B is Water))
                {
                    nbNaturalElement++;
                }
            }
            if (nbNaturalElement < 6)
            {
                CreateNaturalElement();
            }
        }
        void CreateNaturalElement()
        {
            if (random.Next(2) == 0)
            {
                AddBatiment(new Forest(this));
            }
            else
            {
                AddBatiment(new Quarry(this));
            }
        }
    }
}
