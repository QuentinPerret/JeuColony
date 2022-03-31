using JeuColony.Batiments;
using JeuColony.PNJFolder;
using System;
using System.Collections.Generic;


namespace JeuColony
{
    class GameSimulation
    {
        private static int POSITION_CURSOR = 0;
        private static int PAGE_OBJECT = 0;
        private static readonly int NB_PAGE_OBJECT = 8;

        public int Nbl { get; }
        public int Nbc { get; }
        public Object[,] Mat { get; private set; }
        private readonly List<Batiment> _listBatiments;
        private readonly List<PNJ> _listPNJ;
        protected Random random = new Random();
        public GameSimulation()
        {
            PlayerInventory PlayerInv = new PlayerInventory();
            Console.SetWindowSize(150, 40);
            Nbc = 30;
            Nbl = 30;
            _listBatiments = new List<Batiment>();
            _listPNJ = new List<PNJ>();
            Mat = new Object[Nbl, Nbc];
            GenerateInitialBatiments();
            GenerateFirstColon();
        }
        public void GenerateInitialBatiments()
        {
            AddBatiment(new Dormitory(new int[] { 2, 2 }, true, this));
            int nbNaturalElement = 32;
            for (int i = 0; i < nbNaturalElement; i++)
            {
                int alea = random.Next(3);
                switch (alea)
                {
                    case 0:
                        AddBatiment(new Forest(new int[] { 2, 2 }, true, this));
                        break;
                    case 1:
                        AddBatiment(new Mountain(new int[] { 2, 4 }, true, this));
                        break;
                    case 2:
                        AddBatiment(new Water(new int[] { 1, 1 }, true, this));
                        break;
                }
            }
        }
        public void GenerateFirstColon()
        {
            int i  = 0;
            while(!(_listBatiments[i] is Dormitory))
            {
                i++;
            }
            AddPNJ(new Pioneer("Damien", (Dormitory)_listBatiments[i]));
            Random R = new Random();
            _listPNJ[0].MoveTo(new int[] { R.Next(Nbl), R.Next(Nbl) }, this);
        }
        public void AddBatiment(Batiment B)
        {
            _listBatiments.Add(B);
        }
        public void AddPNJ(PNJ P)
        {
            _listPNJ.Add(P);
        }
        public void AfficheMap()
        {
            string chRes = "";
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Mat[i, j] != null)
                    {
                        chRes += Mat[i, j].ToString();
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
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Mat[i, j] != null)
                    {
                        if (Mat[i, j] == O)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Mat[i, j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(Mat[i, j]);
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
        public void PrintFirstPage()
        {
            Console.Clear();
            AfficheMap();
            ProposeList(POSITION_CURSOR);
            NavigateInterfaceList(1);
        }
        public void PrintListBat()
        {
            Console.Clear();
            Object O = _listBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (O == null)
            {
                AfficheMap();
            }
            else
            {
                AfficheMap(O);
            }
            AfficheListeBatiment(POSITION_CURSOR);
            int nbPageMax = _listBatiments.Count / NB_PAGE_OBJECT;
            NavigateInterfaceBat(nbPageMax);
            PrintListBat();
        }
        public void PrintListPNJ()
        {
            Console.Clear();
            Object O = _listPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (O == null)
            {
                AfficheMap();
            }
            else
            {
                AfficheMap(O);
            }
            AfficheListePNJ(POSITION_CURSOR); 
            int nbPageMax = _listPNJ.Count / NB_PAGE_OBJECT;
            NavigateInterfacePNJ(nbPageMax);
            PrintListPNJ();
        }
        public void AfficheListeBatiment(int place)
        {
            Console.WriteLine("LIST BATIMENT");
            for (int i = 0; i < _listBatiments.Count && i < NB_PAGE_OBJECT + 1; i++)
            {
                try
                {
                    Object O = _listBatiments[i + PAGE_OBJECT * NB_PAGE_OBJECT];

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
            for (int i = 0; i < _listPNJ.Count && i < NB_PAGE_OBJECT + 1; i++)
            {
                try
                {
                    Object O = _listPNJ[i + PAGE_OBJECT * NB_PAGE_OBJECT];

                    PNJ P = (PNJ)O;
                    if (i == place)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //Console.WriteLine((i + "- " + O)) ;
                        if(P is Ally A)
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
                        //Console.WriteLine(i + "- " + O);
                        Console.WriteLine(P + "position :" + P.Coordinate[0] + " , " + P.Coordinate[1]);
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }

        }
        private void NavigateInterfaceBat(int nbPageMax)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < _listBatiments.Count - 1)
            {
                POSITION_CURSOR++;
            }
            else if (key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
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
            if (key == ConsoleKey.Enter)
            {
                FocusBatInterface();
            }
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintFirstPage();
            }
        }
        private void NavigateInterfacePNJ(int nbPageMax)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < _listBatiments.Count - 1)
            {
                POSITION_CURSOR++;
            }
            else if (key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
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
            if (key == ConsoleKey.Enter)
            {
                FocusPNJInterface();
            }
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintFirstPage();
            }
            PrintListPNJ();
        }
        private void NavigateInterfaceList(int nbPageMax)
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR + PAGE_OBJECT * NB_PAGE_OBJECT < _listBatiments.Count - 1)
            {
                POSITION_CURSOR++;
            }
            else if (key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
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
            PrintFirstPage();
        }
        private void FocusBatInterface()
        {

            Batiment B = _listBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            AfficheMap(B);
            Console.WriteLine(B.PageBat());
            
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                PrintListBat();
            }
            while(key != ConsoleKey.Escape)
            {
                FocusBatInterface();
            }
        }
        private void FocusPNJInterface()
        {

            PNJ P = _listPNJ[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            Console.Clear();
            AfficheMap(P);
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
            for(int i = 0; i < list.Length; i++)  
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
    }

}
