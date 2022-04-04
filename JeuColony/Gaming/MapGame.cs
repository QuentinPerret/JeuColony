using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony;
using JeuColony.PNJFolder;
using JeuColony.Batiments;

namespace JeuColony
{
    internal class MapGame
    {
        public GameSimulation Simulation { get; set; }
        public int Nbl { get; }
        public int Nbc { get; }
        public Object[,] Map { get; private set; }
        public List<Batiment> ListBatiments { get; set; }
        public List<PNJ> ListPNJ { get; set; }
        protected Random random = new Random();
        public MapGame(GameSimulation G)
        {
            Simulation = G;
            Nbc = 30;
            Nbl = 30;
            ListBatiments = new List<Batiment>();
            ListPNJ = new List<PNJ>();
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
                        AddBatiment(new Forest(new int[] { 2, 2 }, this));
                        break;
                    case 1:
                        AddBatiment(new Mountain(new int[] { 2, 4 }, this));
                        break;
                    case 2:
                        AddBatiment(new Water(new int[] { 1, 1 }, this));
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
            AddPNJ(new Pioneer("Damien", (Dormitory)ListBatiments[i]));
            /*Random R = new Random();
            _listPNJ[0].MoveTo(new int[] { R.Next(Nbl), R.Next(Nbl) }, this);*/
        }
        public void AddBatiment(Batiment B)
        {
            ListBatiments.Add(B);
        }
        public void AddPNJ(PNJ P)
        {
            ListPNJ.Add(P);
        }
        public void AfficheMap()
        {
            string chRes = "";
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Map[i, j] != null)
                    {
                        chRes += Map[i, j].ToString();
                    }
                    else
                    {
                        chRes += " . ";
                    }
                }
                chRes += "\n";
            }
            Console.WriteLine(chRes);
        }
        public void AfficheMap(Object O)
        {
            if (O is PNJ P)
            {
                O = Map[P.Coordinate[0], P.Coordinate[1]];
            }
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Map[i, j] != null)
                    {
                        if (Map[i, j] == O)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
