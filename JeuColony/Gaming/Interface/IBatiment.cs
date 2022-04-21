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
        private static bool problem = false;
        int[] coordinateCreation;
        public object[,] Preview { get; private set; }
        private ConsoleKey KeyCreationBat { get; set; }
        private ConsoleKey KeyBat { get; set; }
        private static readonly string[] LIST_BATIMENT = new string[] { "- DORMITORY", "- TRAININGCAMP" };
        public IBatiment(GameSimulation G, MapGame M, IFirstPage firstPage) : base(G, M)
        {
            _firstPage = firstPage;
            coordinateCreation = new int[] { MapGame.Nbc / 2, MapGame.Nbl / 2 };
        }
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
            int nbPageMax = MapGame.ListBatiments.Count / NB_PAGE_OBJECT-1;
            if (MapGame.ListBatiments.Count % NB_PAGE_OBJECT != 0)
            {
                nbPageMax++;
            }
            NavigateInterface(nbPageMax);
        }//Method that prints a list of batiments present on the map and start the navigation in it 
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

        }//Method that prints a list of batiments present on the map
        public void PrintListTypeBat()
        {
            Console.Clear();
            MapGame.AfficheMap();
            ProposeListTypeBat(POSITION_CURSOR);
            int nbPageMax = LIST_BATIMENT.Length / NB_PAGE_OBJECT;
            NavigateInterfaceCreationBat(nbPageMax);
            PAGE_OBJECT = 0;
            POSITION_CURSOR = 0;
        }//Method that prints all batiment type possible and start the navigation in it
        public void PrintPreview(int[]size)
        {
            Console.Clear();
            PreviewBatimentCreation(size);
        }//Method that prints the map with the preview of the batiment in creation and start the navigation in it
        private bool InPreview(int[]position,int[] size) 
        {
            if (position[0] >= coordinateCreation[0]  && position[0] < coordinateCreation[0] + size[0])
            {
                if(position[1] >= coordinateCreation[1] && position[1] < coordinateCreation[1] + size[1])
                {
                    return true;
                }
            }
            return false;
        }//Method that returns true if the position inspect correspond to a case where it's wanted to preview the batiment
        public void PreviewBatimentCreation(int[] size)
        {
            for (int i = 0; i < MapGame.Nbl - size[0]; i++)
            {
                for (int j = 0; j < MapGame.Nbc - size[1]; j++)
                {
                    if (InPreview(new int[] { i, j }, size))
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
                }
                Console.Write("\n");
            }
            NavigateMapPreview(size);
        } //Method that prints the map with the preview of the batiment in creation and start the navigation in it
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
        }//Method that prints all batiment type possible
        public void CreateBat(int position,int[]coordinate,int[]size)
        {
            if (PositionClear(coordinate, size))
            {
                Batiment B = null;
                switch (position)
                {
                    case 1:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 9 && MapGame.Simulation.PlayerInventory.NbWood > 9)
                        {
                            B = new TrainingCamp(coordinate, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 10 stones and 10 woods to spawn a new Training Camp");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 19 && MapGame.Simulation.PlayerInventory.NbWood > 19)
                        {
                            B = new Hospital(coordinate, size, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 20 stones and 20 woods to spawn a new Hospital");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        if (MapGame.Simulation.PlayerInventory.NbWood > 4 && MapGame.Simulation.PlayerInventory.NbWood > 4)
                        {
                            B = new Dormitory(coordinate, size, MapGame);
                        }
                        else
                        {
                            Console.WriteLine("You need 5 stones and 5 woods to spawn a new Dormitory");
                            Console.ReadLine();
                        }
                        break;
                }
                MapGame.AddBatiment(B);
            }
            else
            {
                Console.WriteLine("This position isn't avialable, please retry");
                Console.ReadKey();
            }
        }//Method that creates the batiment considering the type choose represent by its position in the list print with ProposeListtypeBat() and his position choose
        public int[] DefineSizeCreation(int position)
        {
            switch (position)
            {
                case 1:
                    return new int[] { 3 , 3 };
                case 2:
                    return new int[] { 4, 2 };
                default:
                    return new int[] { 2, 3 };
            }
        }//Method that return the size of the type of batiment that is wanted to be created
        private void NavigateMapPreview(int[] size)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Use arrows to position your batiment then press enter");
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow && coordinateCreation[0] + size[0] < MapGame.Nbl)
            {
                coordinateCreation[0]++;
            }
            else if (key == ConsoleKey.UpArrow  && coordinateCreation[0] > 0)
            {
                coordinateCreation[0]--;
            }
            if (key == ConsoleKey.RightArrow && coordinateCreation[1] + size[1] < MapGame.Nbc)
            {
                coordinateCreation[1]++;
            }
            else if (key == ConsoleKey.LeftArrow && coordinateCreation[1] > 0)
            {
                coordinateCreation[1]--;
            }
            if (key == ConsoleKey.Enter)
            {
                CreateBat(POSITION_CURSOR,coordinateCreation,size);
                PrintListBat();
            }
            if (key == ConsoleKey.V)
            {
                size = new int[] { size[1], size[0] };
            }
            if (key == ConsoleKey.Escape)
            {
                PrintListTypeBat();
            }
            if (key == ConsoleKey.Spacebar)
            {
                MapGame.Simulation.EndTurn();
            }
            if (MapGame.Simulation.PLAY_TURN)
            {
                Console.Clear();
                PreviewBatimentCreation(size);
            }
        }//Method that allows to move the position of the batiment we are creating
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
                PrintPreview(DefineSizeCreation(POSITION_CURSOR));
                POSITION_CURSOR = 0;
            }
            if (KeyCreationBat == ConsoleKey.Escape)
            {
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            if (KeyCreationBat == ConsoleKey.Spacebar)
            {
                KeyBat = ConsoleKey.Spacebar;
                MapGame.Simulation.EndTurn();
            }
            else if (MapGame.Simulation.PLAY_TURN)
            {
                PrintListTypeBat();
            }
        }//Method that allows to navigate in the list of batiment's type print and select one to create the batiment
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
                GameSimulation.EndTurn();
            }
            else
            {
                FocusBatInterface();
            }
        }//Method that prints stats of a precise batiment and allows to quit the page 
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
        }//Method that allows to navigate in the list of batiments present in the game
        private bool PositionClear(int[]coordinate, int[]size)
        {
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    try
                    {
                        if (MapGame.Map[coordinate[0] + i, coordinate[1] + j] is Batiment)
                        {
                            return false;
                        }
                    }
                    catch (IndexOutOfRangeException) { return false; }
                }
            }
            return true;
        }
    }
}
