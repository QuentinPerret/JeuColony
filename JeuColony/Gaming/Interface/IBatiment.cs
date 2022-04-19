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
    internal class IBatiment : InterfaceUser
    {
         readonly IFirstPage _firstPage;
        private ConsoleKey KeyCreationBat { get; set; }
        private static readonly string[] LIST_BATIMENT = new string[] { "- DORMITORY", "- TRAININGCAMP", "-CANTINA" };
        public IBatiment(GameSimulation G, MapGame M, IFirstPage firstPage) : base(G, M) { _firstPage = firstPage; }
        public void PrintListBat()
        {
            Console.Clear();
            Batiment B = MapGame.ListBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (B == null)
            {
                MapGame.AfficheMap();
            }
            else
            {
                MapGame.AfficheMapBat(B);
            }
            AfficheListeBatiment(POSITION_CURSOR);
            int nbPageMax = MapGame.ListBatiments.Count / NB_PAGE_OBJECT;
            if (MapGame.ListBatiments.Count % NB_PAGE_OBJECT != 0)
            {
                nbPageMax++;
            }
            NavigateInterface(nbPageMax);
        }
        public void AfficheListeBatiment(int place)
        {
            Console.WriteLine("LIST BATIMENT");
            for (int i = 0; i < MapGame.ListBatiments.Count && i < NB_PAGE_OBJECT; i++)
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
        public void PrintListTypeBat()
        {
            Console.Clear();
            MapGame.AfficheMap();
            ProposeListTypeBat(POSITION_CURSOR);
            int nbPageMax = LIST_BATIMENT.Length / NB_PAGE_OBJECT;
            NavigateInterfaceCreationBat(nbPageMax);
            PAGE_OBJECT = 0;
            POSITION_CURSOR = 0;
        }
        protected void ProposeListTypeBat(int place)
        {
            Console.WriteLine("LIST TYPE BATIMENT");
            for (int i = 0; i < LIST_BATIMENT.Length; i++)
            {
                if (i == place)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.WriteLine((i + "- " + O)) ;
                    Console.WriteLine(LIST_BATIMENT[i]);
                    Console.ResetColor();
                }
                else
                {
                    //Console.WriteLine(i + "- " + O);
                    Console.WriteLine(LIST_BATIMENT[i]);
                }
            }
        }
        public void CreateBat(int position)
        {
            Batiment Bat;
            switch (position)
            {
                case 1:
                    Bat = new TrainingCamp(D, MapGame);
                    break;
                case 2:
                    Bat = new Cantina(D, MapGame);
                    break;
                
                default:
                    Bat = new Dormitory(D, MapGame);
                    break;
            }
            MapGame.AddBatiment(Bat);
        }
        private void NavigateInterfaceCreationBat(int nbPageMax)
        {
            KeyCreationBat = Console.ReadKey().Key;
            if (KeyCreationBat == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (KeyCreationBat == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (KeyCreationBat == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (KeyCreationBat == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < LIST_BATIMENT.Length - 1)
            {
                POSITION_CURSOR++;
            }
            if (KeyCreationBat == ConsoleKey.Enter)
            {
                CreateBat(POSITION_CURSOR);
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            if (KeyCreationBat == ConsoleKey.Escape)
            {
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            if (KeyCreationBat == ConsoleKey.Spacebar)
            {
                KeyBat = ConsoleKey.Spacebar;
                Simulation.EndTurn();
            }
            else if (Simulation.PLAY_TURN)
            {
                PrintListTypeBat();
            }
        }
        protected void FocusBatInterface()
        {
            Batiment B = MapGame.ListBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            MapGame.AfficheMapBat(B);
            Console.WriteLine(B.PageBat());

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            if(key == ConsoleKey.Spacebar)
            {
                GameSimulation.EndTurn();
            }
            else 
            {
                FocusBatInterface();
            }
        }
        private void NavigateInterface(int nbPageMax)
        {
            KeyBat = Console.ReadKey().Key;
            if (KeyBat == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (KeyBat == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (KeyBat == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 7;
            }
            if (KeyBat == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < MapGame.ListBatiments.Count - 1)
            {
                POSITION_CURSOR++;
            }
            if (KeyBat == ConsoleKey.B)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListTypeBat();
            }
            if (KeyBat == ConsoleKey.Enter)
            {
                FocusBatInterface();
            }
            if (KeyBat == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                _firstPage.PrintFirstPage();
            }
            if (GameSimulation.PLAY_TURN)
            {
                if (KeyBat == ConsoleKey.Spacebar)
                {
                    GameSimulation.EndTurn();
                }
                else
                {
                    PrintListBat();
                }
            }
        }
    }
}
