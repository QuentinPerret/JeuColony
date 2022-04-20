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
            PNJ P = MapGame.ListPNJAlly[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (P == null)
            {
                MapGame.AfficheMap();
            }
            else
            {
                MapGame.AfficheMapPnj(P);
            }
            AfficheListePNJ(POSITION_CURSOR);
            int nbPageMax = MapGame.ListPNJAlly.Count / NB_PAGE_OBJECT -1;
            if(MapGame.ListPNJAlly.Count % NB_PAGE_OBJECT != 0)
            {
                nbPageMax++;
            }
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
            if (KeyPnj == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListPNJAlly.Count - 1)
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
                GameSimulation.EndTurn();
            }
            else if (GameSimulation.PLAY_TURN)
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
                POSITION_CURSOR = 7;
            }
            if (KeyCreationPnj == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT-1 && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < LIST_PROFESSION.Length - 1)
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
                GameSimulation.EndTurn();
            }
            else if(GameSimulation.PLAY_TURN)
            {
                PrintListProfession();
            }
        }
        public void AfficheListePNJ(int place)
        {
            Console.WriteLine("LIST PNJ");
            for (int i = 0; i < MapGame.ListPNJAlly.Count && i < NB_PAGE_OBJECT; i++)
            {
                try
                {
                    Object O = MapGame.ListPNJAlly[i + PAGE_OBJECT * NB_PAGE_OBJECT];

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
            Ally ally = null;
            while (!(B is Dormitory) && i < MapGame.ListBatiments.Count)
            {
                i++;
            }
            if (CountCapacityAlly() <= MapGame.ListPNJAlly.Count)
            {
                Console.WriteLine("You don't have anymore place to accomodate a new Pnj, create a new Dormitory to do so!");
                Console.ReadLine();
            }
            else
            {
                switch (position)
                {
                    case 1:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 0 && MapGame.Simulation.PlayerInventory.NbWood > 0)
                        {
                            ally = new Builder(D, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 1 stone and 1 wood to spawn a new Builder");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 0 && MapGame.Simulation.PlayerInventory.NbWood > 1)
                        {
                            ally = new Digger(D, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 2 stone and 1 wood to spawn a new Digger");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 1 && MapGame.Simulation.PlayerInventory.NbWood > 0)
                        {
                            ally = new Builder(D, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 1 stone and 2 wood to spawn a new Forester");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        if (CountTrainingCamp() == 0)
                        {
                            Console.WriteLine("You need 1 more Training Camp to create a Soldier");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (MapGame.Simulation.PlayerInventory.NbWood > 1 && MapGame.Simulation.PlayerInventory.NbWood > 1)
                            {
                                ally = new Soldier(D, MapGame);
                            }
                            else
                            {
                                Console.WriteLine("You need 2 stone and 2 wood to spawn a new Soldier"); 
                                Console.ReadLine();

                            }
                        }
                        break;
                    default:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 0 && MapGame.Simulation.PlayerInventory.NbWood > 0)
                        {
                            ally = new Pioneer(D, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 1 stone and 1 wood to spawn a new Pioneer");
                            Console.ReadLine();

                        }
                        break;
                }
                MapGame.AddPNJAlly(ally);
            }
        }
        private int CountCapacityAlly()
        {
            int res = 0;
            foreach (Batiment B in MapGame.ListBatiments)
            {
                if (B is Dormitory D && D.TimeLeftToConstruct == 0)
                {
                    res+= D.Capacity;
                }
            }
            return res;
        }
        private int CountTrainingCamp()
        {
            int res = 0;
            foreach(Batiment B in MapGame.ListBatiments)
            {
                if(B is TrainingCamp && B.TimeLeftToConstruct == 0)
                {
                    res++;
                }
            }
            return res;
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
            PNJ P = MapGame.ListPNJAlly[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
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
                GameSimulation.EndTurn();
            }
            else if (GameSimulation.PLAY_TURN)
            {
                FocusPNJInterface();
            }

        }
    }
}
