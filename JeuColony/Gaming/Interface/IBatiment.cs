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
        private static int x;
        private static int y;
        private static bool problem = false;
        public object[,] Preview { get; private set; }
        private ConsoleKey KeyCreationBat { get; set; }
        private static readonly string[] LIST_BATIMENT = new string[] { "- DORMITORY", "- TRAININGCAMP", "- CANTINA" };
        public IBatiment(GameSimulation G, MapGame M, IFirstPage firstPage) : base(G, M) { _firstPage = firstPage; y = MapGame.Nbc / 2; x = MapGame.Nbl / 2; }
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
            NavigateInterface(nbPageMax);
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
        public void PrintPreview(Batiment B)
        {
            Console.Clear();
            PreviewBatimentCreation(B);
            NavigateMap(B);
        }
        public void PreviewBatimentCreation(Batiment B)
        {

            Preview = new object[MapGame.Nbl, MapGame.Nbc];
            //AfficheMap(B);
            problem = false;
            Preview[x, y] = B;
            for (int i = 0; i < MapGame.Nbl - B.Size[0]; i++)
            {
                for (int j = 0; j < MapGame.Nbc - B.Size[1]; j++)
                {
                    if (Preview[i, j] == Preview[x, y] || Preview[i + B.Size[0], j + B.Size[1]] == Preview[x, y] || Preview[i, j + B.Size[1]] == Preview[x, y] || Preview[i + B.Size[0], j] == Preview[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (MapGame.Map[i, j] != null)
                    {
                        Console.Write(MapGame.Map[i, j].ToString());

                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    if (MapGame.Map[x, y] != null || MapGame.Map[x + B.Size[0], y + B.Size[1]] != null || MapGame.Map[x, y + B.Size[1]] != null || MapGame.Map[x + B.Size[0], y] != null)
                    {
                        problem = true;
                    }
                    else
                    {
                        problem = false;
                    }
                }
                Console.Write("\n");
            }
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
        public Batiment CreateBat(int position)
        {
            Batiment Bat;
            switch (position)
            {
                case 1:
                    Bat = new TrainingCamp(new int[] { 1, 1 }, new int[] { -1, -1 }, MapGame);
                    break;
                case 2:
                    Bat = new Cantina(new int[] { 1, 1 }, new int[] { -1, -1 }, MapGame);
                    break;

                default:
                    Bat = new Dormitory(new int[] { 1, 1 }, new int[] { -1, -1 }, MapGame);
                    break;
            }
            
            return Bat;
        }
        public void InstallBatiment(Batiment Bat)
        {

            Console.Clear();
            PreviewBatimentCreation(Bat);
            //NavigateInterfaceBatimentCreation();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Etes-vous sûr de vouloir placer ce batiment ici? (appuyer sur entrée si oui ou sur echap sinon)");
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter && !problem)
            {
                Bat.Coordinate[0] = x;
                Bat.Coordinate[1] = y;
                MapGame.AddBatiment(Bat);
                PrintListBat();
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

            }
            if (key != ConsoleKey.Escape)
            {
                InstallBatiment(Bat);
            }

        }
        private void NavigateMap(Batiment B)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Appuyez sur les flèches pour placer un batiment puis sur espace pour le placer");
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow && x <= MapGame.Nbl - B.Size[1] - 2)
            {
                x++;
            }
            else if (key == ConsoleKey.UpArrow && x >= B.Size[0] + 1)
            {
                x--;
            }
            if (key == ConsoleKey.RightArrow && y <= MapGame.Nbc - B.Size[1] - 2)
            {
                y++;
            }
            else if (key == ConsoleKey.LeftArrow && y >= B.Size[1] + 1)
            {
                y--;
            }

            if (key == ConsoleKey.Spacebar)
            {
                InstallBatiment(B);
            }
            if (key == ConsoleKey.Escape)
            {


            }
            Console.Clear();
            PreviewBatimentCreation(B);
            NavigateMap(B);
            //NavigateInterface(nbPageMax);
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
                Batiment Bat = CreateBat(POSITION_CURSOR);
                POSITION_CURSOR = 0;
                PrintPreview(Bat);
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
            if (key == ConsoleKey.Spacebar)
            {
                Simulation.EndTurn();
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
                POSITION_CURSOR = 0;
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
            if (Simulation.PLAY_TURN)
            {
                if (KeyBat == ConsoleKey.Spacebar)
                {
                    Simulation.EndTurn();
                }
                else
                {
                    PrintListBat();
                }
            }
        }
    }
}
