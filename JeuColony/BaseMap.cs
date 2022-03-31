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
        private static int x;
        private static int y;
        public object[,] Mat { get; private set; }
        public object[,] Preview { get; private set; }
        public Object[,] Mat2 { get; private set; }
        private readonly List<Batiments.Batiment> _listBatiments;
        private readonly List<Batiment> _basicBatiments;
        protected Random random = new Random();
        public BaseMap()
        {
            Console.SetWindowSize(150, 40);
            Nbc = 30;
            Nbl = 30;
            x = Nbl / 2;
            y = Nbc / 2;
            _listBatiments = new List<Batiment>();
            _basicBatiments = new List<Batiment>();
            Mat = new Object[Nbl,Nbc];
            this.GenerateBatiments();
            GenerateBatimentsBasic();
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
        /*public void GenerateBatiments(Batiment B,int[] coord)
        {
            Type T= typeof(Batiment);
            AddABatiment(new T(coord, true, this));
        }*/
        public void AddABatiment(Batiments.Batiment B)
        {
            _listBatiments.Add(B);
        }
       
        public void GenerateBatimentsBasic()
        {
            _basicBatiments.Add(new Cantina(new int[] { 0, 0 }, true, this));
            
            _basicBatiments.Add(new TrainingCamp(new int[] { 0, 0 }, true, this));
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
        public void PreviewBatimentCreation(Batiment B,int x, int y)
        {
            
            Preview = new object[Nbl, Nbc];
            //AfficheMap(B);
            Preview[x,y] = B;
            for (int i = 0; i < Nbl-B.Size[0]; i++)
            {
                for (int j = 0; j < Nbc-B.Size[1]; j++)
                {
                    if (Preview[i, j] == Preview[x, y] || Preview[i + B.Size[0], j + B.Size[1]] == Preview[x, y]|| Preview[i , j + B.Size[1]] == Preview[x, y]|| Preview[i + B.Size[0], j] == Preview[x, y])
                    {
                        Console.BackgroundColor=ConsoleColor.Red;
                        Console.Write("   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.Write("\n");
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
        public void Print(Batiment B, int x, int y)
        {
            Console.Clear();
            PreviewBatimentCreation(B, x, y);
            AfficheTousBatiments(POSITION_CURSOR);
            NavigateMap(B);
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
        public void AfficheTousBatiments(int place)
        {
            Console.WriteLine("LIST OBJECT");
            for (int i = 0; i < _basicBatiments.Count ; i++)
            {
                try
                {
                    Object O = _basicBatiments[i];

                    Batiment B = (Batiment)O;
                    if (i == place)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //Console.WriteLine((i + "- " + O)) ;
                        Console.WriteLine("Voulez-vous installer : " + _basicBatiments[place]);
                        Console.ResetColor();
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter)
                        {
                            AddABatiment(_basicBatiments[place]);
                            
                        }
                    }
                    
                }
                catch (ArgumentOutOfRangeException) { Console.WriteLine("Erreur "); }
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
            if(key == ConsoleKey.B)
            {
                Batiment B = new Dormitory(GenerateTab(5,2), true, this);
                NavigateMap(B);
                
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
        private void NavigateMap(Batiment B)
        {
            
            ConsoleKey key = Console.ReadKey().Key;
            
            
            if (key == ConsoleKey.DownArrow && x<=Nbl - B.Size[1] - 2)
            {
                x++;
            }
            else if (key == ConsoleKey.UpArrow && x>= B.Size[0]+1)
            {
                x--;
            }
            if (key == ConsoleKey.RightArrow && y<=Nbc-B.Size[1]-2)
            {
                y++;
            }
            else if (key == ConsoleKey.LeftArrow && y>=B.Size[1]+1)
            {
                y--;
            }

            if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                Print();
            }

           
            Print(B, x, y);


        }
    }

}
