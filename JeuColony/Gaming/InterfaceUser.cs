using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.PNJFolder;
using JeuColony.Batiments;

namespace JeuColony
{
    internal class InterfaceUser
    {
        private static int POSITION_CURSOR = 0;
        private static int PAGE_OBJECT = 0;
        private static readonly int NB_PAGE_OBJECT = 8;
        public GameSimulation Simulation { get; set; }
        public MapGame MapGame { get; set; }
        public InterfaceUser(GameSimulation G, MapGame M)
        {
            Simulation = G;
            MapGame = M;
        }
        public void PrintFirstPage()
        {
            Console.Clear();
            MapGame.AfficheMap();
            ProposeList(POSITION_CURSOR);
            NavigateInterface(0,null);
            PrintFirstPage();
        }
        public void PrintListBat()
        {
            Console.Clear();
            Object O = MapGame.ListBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (O == null)
            {
                MapGame.AfficheMap();
            }
            else
            {
                MapGame.AfficheMap(O);
            }
            AfficheListeBatiment(POSITION_CURSOR);
            int nbPageMax = MapGame.ListBatiments.Count / NB_PAGE_OBJECT;
            NavigateInterface(nbPageMax, MapGame.ListBatiments[0]);
            PrintListBat();
        }
        public void PrintListPNJ()
        {
            Console.Clear();
            Object O = MapGame.ListPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (O == null)
            {
                MapGame.AfficheMap();
            }
            else
            {
                MapGame.AfficheMap(O);
            }
            AfficheListePNJ(POSITION_CURSOR);
            int nbPageMax = MapGame.ListPNJ.Count / NB_PAGE_OBJECT;
            NavigateInterface(nbPageMax, MapGame.ListPNJ[0]);
            PrintListPNJ();
        }
        public void AfficheListeBatiment(int place)
        {
            Console.WriteLine("LIST BATIMENT");
            for (int i = 0; i < MapGame.ListBatiments.Count && i < NB_PAGE_OBJECT + 1; i++)
            {
                try
                {
                    Object O = MapGame.ListBatiments[i + PAGE_OBJECT * NB_PAGE_OBJECT];

                    Batiment B = (Batiment)O;
                    if (i == place)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //Console.WriteLine((i + "- " + O)) ;
                        Console.WriteLine(B + "position :" + B.Coordinate[0] + " , " + B.Coordinate[1]);
                        Console.ResetColor();
                    }
                    else
                    {
                        //Console.WriteLine(i + "- " + O);
                        Console.WriteLine(B + "position :" + B.Coordinate[0] + " , " + B.Coordinate[1]);
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }

        }
        public void AfficheListePNJ(int place)
        {
            Console.WriteLine("LIST PNJ");
            for (int i = 0; i < MapGame.ListPNJ.Count && i < NB_PAGE_OBJECT + 1; i++)
            {
                try
                {
                    Object O = MapGame.ListPNJ[i + PAGE_OBJECT * NB_PAGE_OBJECT];

                    PNJ P = (PNJ)O;
                    if (i == place)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //Console.WriteLine((i + "- " + O)) ;
                        if (P is Ally A)
                        {
                            Console.WriteLine(" - " + A.Name + " , " + A.Profession);
                        }
                        else
                        {
                            Console.WriteLine(" - " + P.Name + " , ");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        //Console.WriteLine(i + "- " + O);
                        Console.WriteLine(P + "position :" + P.Coordinate[0] + " , " + P.Coordinate[1]);
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }

        }
        private void NavigateInterface(int nbPageMax,Object ObjectList)
        {
            
            ConsoleKey key = Console.ReadKey().Key;

            if (ObjectList is PNJ)
            {
                if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListPNJ.Count - 1)
                {
                    POSITION_CURSOR++;
                }

                if (key == ConsoleKey.Enter)
                {
                    FocusPNJInterface();
                }
            }
            else if (ObjectList is Batiment)
            {
                if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListBatiments.Count - 1)
                {
                    POSITION_CURSOR++;
                }

                if (key == ConsoleKey.Enter)
                {
                    FocusBatInterface();
                }
            }
            else if (ObjectList == null)
            {
                if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT)
                {
                    POSITION_CURSOR++;
                }
                if (key == ConsoleKey.Enter)
                {
                    if (POSITION_CURSOR == 0)
                    {
                        PrintListPNJ();
                    }
                    else
                    {
                        POSITION_CURSOR = 0;
                        PrintListBat();
                    }
                }
            }

            if (key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (key == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (key == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintFirstPage();
            }
        }
        private void FocusBatInterface()
        {
            Batiment B = MapGame.ListBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            MapGame.AfficheMap(B);
            Console.WriteLine(B.PageBat());

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            while (key != ConsoleKey.Escape)
            {
                FocusBatInterface();
            }
        }
        private void FocusPNJInterface()
        {
            PNJ P = MapGame.ListPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            MapGame.AfficheMap(P);
            Console.WriteLine(P.PagePNJ());
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListPNJ();
            }
            while (key != ConsoleKey.Escape)
            {
                FocusPNJInterface();
            }
        }
        private void ProposeList(int place)
        {
            string[] list = new string[] { " - LIST PNJ", " - LIST BATIMENT" };
            Console.WriteLine("LIST OBJECT");
            for (int i = 0; i < list.Length; i++)
            {
                if (i == place)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.WriteLine((i + "- " + O)) ;
                    Console.WriteLine(list[i]);
                    Console.ResetColor();
                }
                else
                {
                    //Console.WriteLine(i + "- " + O);
                    Console.WriteLine(list[i]);
                }
            }
        }
        public void StartPrinting()
        {
            PrintFirstPage();
        }
        public void InstallBatiment(int place, Batiment Bat)
        {

            Console.Clear();
            PreviewBatimentCreation(Bat, x, y);
            //NavigateInterfaceBatimentCreation();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Etes-vous sûr de vouloir placer ce batiment ici? (appuyer sur entrée si oui ou sur echap sinon)");
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter && !problem)
            {
                /*Object t = Bat.GetType().Name;
                Type type = Type.GetType(Bat.GetType().Name); //target type
                object o = Activator.CreateInstance(type); // an instance of target type
                Batiment your = (Batiment)o;*/
                MapGame.AddBatiment(new TrainingCamp(new int[] { 2, 2 }, new int[] { x - 1, y - 1 }, true, this));
                MapGame.AfficheMap();
            }
            else if (problem)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("Impossible de placer ce batiment à cet endroit veuillez réessayer (appuyez sur une touche)");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ReadKey();
                NavigateMap(Bat);
            }

            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                Print();
            }
            while (key != ConsoleKey.Escape)
            {
                InstallBatiment(POSITION_CURSOR, Bat);
            }

        }
    }
}
