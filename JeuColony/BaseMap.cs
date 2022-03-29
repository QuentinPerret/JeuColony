using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JeuColony.Batiments;
using JeuColony.PNJ;


namespace JeuColony
{
    class BaseMap
    {
        private static int POSITION_CURSOR = 0;
        private static int PAGE_OBJECT = 0;
        private static int NB_PAGE_OBJECT = 8; 
        
        public int Nbl { get; }
        public int Nbc { get; }
        public Object[,] Mat { get; private set; }
        private readonly List<Batiments.Batiment> _listBatiments;
        protected Random random = new Random();
        public BaseMap()
        {
            Console.SetWindowSize(150, 40);
            Nbc = 30;
            Nbl = 30;
            _listBatiments = new List<Batiment>();
            Mat = new Object[Nbl,Nbc];
            this.GenerateBatiments();
            //r = new Random();
            //this.ShowBatiments();
        }
        public static int[] GenerateTab(int x1, int x2)
        {
            int[] res = { x1, x2 };
            return res;
        }
        public void GenerateBatiments()
        {
            AddABatiment(new Dormitory(new int[] { 2, 2 }, true, this));
            for (int i = 0; i < 32; i++)
            {
                int alea = random.Next(3);
                switch (alea)
                {
                    case 0:
                        AddABatiment(new Forest(new int[] { 2,2}, true, this)) ;
                        break;
                    case 1:
                        AddABatiment(new Mountain(new int[] { 2, 4 }, true, this));
                        break;
                    case 2:
                        AddABatiment(new Water(new int[] { 1, 1 }, true, this));
                        break;
                }
            }
        }
        public void AddABatiment(Batiments.Batiment B)
        {
            _listBatiments.Add(B);
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
                        if (Mat[i,j]== O)
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
        public void Print()
        {
            Console.Clear();
            Object O = _listBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if(O == null)
            {
                AfficheMap();
            }
            else
            {
                AfficheMap(O);
            }
            AfficheListe(POSITION_CURSOR);
            NavigateInterface();
        }
        public void AfficheListe(int place)
        {
            Console.WriteLine("LIST OBJECT");
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
        private void NavigateInterface()
        {
            int nbPageMax = _listBatiments.Count / NB_PAGE_OBJECT;
            ConsoleKey key = Console.ReadKey().Key;
            
            if(key == ConsoleKey.DownArrow && POSITION_CURSOR < NB_PAGE_OBJECT && POSITION_CURSOR+PAGE_OBJECT*NB_PAGE_OBJECT < _listBatiments.Count-1)
            {
                POSITION_CURSOR++;
            }
            else if(key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if(key == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (key == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if(key == ConsoleKey.Enter)
            {
                FocusObjectInterface();
                Console.ReadLine();
            }
            Print();
        }
        private void FocusObjectInterface()
        {
            
            Object O = _listBatiments[PAGE_OBJECT * NB_PAGE_OBJECT + POSITION_CURSOR];
            if (O is Batiment)
            {
                Batiment B = (Batiment)O;
                Console.Clear();
                AfficheMap(O);
                Console.WriteLine(B + "position :" + B.Coordinate[0] + " , " + B.Coordinate[1]);
            }
            else
            {
                PNJ.PNJ P = (PNJ.PNJ)O;
                Console.Clear();
                AfficheMap(O);
                Console.WriteLine(P.ToString());
                
            }
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                Print();
            }
            while (key != ConsoleKey.Escape)
            {
                FocusObjectInterface();
            }
        }
    }

}
