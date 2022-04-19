using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony;
using JeuColony.Batiments;
using JeuColony.PNJFolder;

namespace JeuColony
{
    internal class IPnj : InterfaceUser
    {
        private static readonly string[] LIST_PROFESSION = new string[] { " - PIONEER", " - BUILDER", " - DIGGER", " - FORESTER", " - SOLDIER" };
        private ConsoleKey KeyPnj { get; set; }
        private ConsoleKey KeyCreationPnj { get; set; }
        readonly IFirstPage _firstPage;
        public IPnj(GameSimulation G, MapGame M, IFirstPage firstPage) : base(G, M) { _firstPage = firstPage; }
        public void PrintListPNJ()
        {
            Console.Clear();
            PNJ P = MapGame.ListPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (P == null)
            {
                MapGame.AfficheMap();
            }
            else
            {
                MapGame.AfficheMapPnj(P);
            }
            AfficheListePNJ(POSITION_CURSOR);
            int nbPageMax = MapGame.ListPNJ.Count / NB_PAGE_OBJECT;
            NavigateInterface(nbPageMax);
        }

        private void NavigateInterface(int nbPageMax)
        {
            KeyPnj = Console.ReadKey().Key;
            if (KeyPnj == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (KeyPnj == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (KeyPnj == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (KeyPnj == ConsoleKey.P)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListProfession();
            }
            if (KeyPnj == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListPNJ.Count - 1)
            {
                POSITION_CURSOR++;
            }
            if(KeyPnj == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                _firstPage.PrintFirstPage();
            }
            if (KeyPnj == ConsoleKey.Enter)
            {
                FocusPNJInterface();
            }
            if (KeyPnj == ConsoleKey.Spacebar)
            {
                Simulation.EndTurn();
            }
            else if (Simulation.PLAY_TURN)
            {
                PrintListPNJ();
            }
        }
        private void NavigateInterfaceCreationPnj(int nbPageMax)
        {
            KeyCreationPnj = Console.ReadKey().Key;
            if (KeyCreationPnj == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (KeyCreationPnj == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (KeyCreationPnj == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (KeyCreationPnj == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < LIST_PROFESSION.Length - 1)
            {
                POSITION_CURSOR++;
            }
            if (KeyCreationPnj == ConsoleKey.Enter)
            {
                CreatePnj(POSITION_CURSOR);
                POSITION_CURSOR = 0;
                PrintListPNJ();
            }
            if(KeyCreationPnj == ConsoleKey.Escape)
            {
                POSITION_CURSOR = 0;
                PrintListPNJ();
            }
            if (KeyCreationPnj == ConsoleKey.Spacebar)
            {
                KeyPnj = ConsoleKey.Spacebar;
                Simulation.EndTurn();
            }
            else if(Simulation.PLAY_TURN)
            {
                PrintListProfession();
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
                            Console.WriteLine(" - " + P.Name + ", ");
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
        public void PrintListProfession()
        {
            Console.Clear();
            MapGame.AfficheMap();
            ProposeListProfession(POSITION_CURSOR);
            int nbPageMax = LIST_PROFESSION.Length / NB_PAGE_OBJECT;
            NavigateInterfaceCreationPnj(nbPageMax);
            PAGE_OBJECT = 0;
            POSITION_CURSOR = 0;
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
                    Pnj = new Builder(D, MapGame);
                    break;
                case 2:
                    Pnj = new Digger(D, MapGame);
                    break;
                case 3:
                    Pnj = new Forester(D, MapGame);
                    break;
                case 4:
                    Pnj = new Soldier(D, MapGame);
                    break;
                default:
                    Pnj = new Pioneer(D, MapGame);
                    break;
            }
            MapGame.AddPNJ(Pnj);
        }
        protected void ProposeListProfession(int place)
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
        protected void FocusPNJInterface()
        {
            PNJ P = MapGame.ListPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            MapGame.AfficheMapPnj(P);
            Console.WriteLine(P.PagePNJ());
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListPNJ();
            }
            if (key == ConsoleKey.Spacebar)
            {
                Simulation.EndTurn();
            }
            else if (Simulation.PLAY_TURN)
            {
                FocusPNJInterface();
            }

        }
    }
}
