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
        private static readonly string[] LIST_PROFESSION = new string[] { " - PIONEER", " - BUILDER", " - DIGGER", " - FORESTER", " - SOLDIER" };
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
        void PrintListProfession()
        {
            Console.Clear();
            MapGame.AfficheMap();
            ProposeListProfession(POSITION_CURSOR);
            int nbPageMax = LIST_PROFESSION.Length / NB_PAGE_OBJECT;
            NavigateInterface(nbPageMax, "P");
            PrintListProfession();
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
                        Console.WriteLine(" - " + B.BatimentType);
                        Console.ResetColor();
                    }
                    else
                    {
                        //Console.WriteLine(i + "- " + O);
                        Console.WriteLine(" - " + B.BatimentType);
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
                            Console.WriteLine(" - " + A.Name + ", " + A.Profession);
                        }
                        else
                        {
                            Console.WriteLine(" - " + P.Name + " , ");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        if (P is Ally A)
                        {
                            Console.WriteLine(" - " + A.Name + " , " + A.Profession);
                        }
                        else
                        {
                            Console.WriteLine(" - " + P.Name + " , ");
                        }
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
            else if (ObjectList == (Object)"P")
            {
                if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListBatiments.Count - 1)
                {
                    POSITION_CURSOR++;
                }                                                                                                                                                                                                  
                if (key == ConsoleKey.Enter)
                {
                    CreatePnj(POSITION_CURSOR);
                    POSITION_CURSOR = 0;
                    PrintFirstPage();
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
            if (key == ConsoleKey.P)
            {

                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListProfession();
            }
        }
        public void CreatePnj(int position)
        {
            int i = 0;
            Batiment B = MapGame.ListBatiments[i];
            Dormitory D = (Dormitory)B;
            PNJ Pnj;
            while (!(B is Dormitory) && i < MapGame.ListBatiments.Count)
            {
                i++;
            }
            switch (position)
            {
                case 1:
                    Pnj = new Builder(D);
                    break;
                case 2:
                    Pnj = new Digger(D);
                    break;
                case 3:
                    Pnj = new Forester(D);
                    break;
                case 4:
                    Pnj = new Soldier(D);
                    break;
                default:
                    Pnj = new Pioneer(D);
                    break;
            }
            MapGame.AddPNJ(Pnj);
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
        private void ProposeListProfession(int place)
        {
            Console.WriteLine("LIST PROFFESSION");
            for (int i = 0; i < LIST_PROFESSION.Length; i++)
            {
                if (i == place)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.WriteLine((i + "- " + O)) ;
                    Console.WriteLine(LIST_PROFESSION[i]);
                    Console.ResetColor();
                }
                else
                {
                    //Console.WriteLine(i + "- " + O);
                    Console.WriteLine(LIST_PROFESSION[i]);
                }
            }
        }
        public void StartPrinting()
        {
            PrintFirstPage();
        }
    }
}
