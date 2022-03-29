using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;
using JeuColony.PNJ;

namespace JeuColony
{
    class BaseMap
    {
        private static int POSITION_CURSOR = 0;
        private static int PAGE_OBJECT = 0;
        private static int NB_PAGE_OBJECT = 9;
        
        public int Nbl { get; }
        public int Nbc { get; }
        private static int x;
        private static int y;
        public object[,] Mat { get; private set; }
        private readonly List<Batiments.Batiment> _listBatiments;
        protected Random r = new Random();
        public BaseMap()
        {
            Console.SetWindowSize(150, 40);
            Nbc = 30;
            Nbl = 30;
            x = Nbl / 2;
            y = Nbc / 2;
            _listBatiments = new List<Batiment>();
            this.GenerateMap();
            this.GenerateBatiments();
            //r = new Random();
            //this.ShowBatiments();
        }
        public static int[] GenerateTab(int x1, int x2)
        {
            int[] res = { x1, x2 };
            return res;
        }
        public void GenerateMap()
        {
            Mat = new object[Nbl, Nbc];
        }
        
        public void GenerateBasicBatiments()
        {
            int nb;
            int nbMaxBatiments = 40;
            nb = r.Next(4, nbMaxBatiments);
            AddABatiment(new Batiments.ListInteract.Dormitory(GenerateTab(2,2), true, this));
            AddABatiment(new Batiments.ListInteract.Cantina(GenerateTab(2,2), true, this));
            for(int i=0; i<nb/4; i++)
            {
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Forest(GenerateTab(1,1),true,this));
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Mountain(GenerateTab(3, 3), true, this));
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Water(GenerateTab(2, 2), true, this));
            }
        }
        public void GenerateBatiments()
        {
            GenerateBasicBatiments();
        }
        
        public void ShowBatiments()
        {
            foreach (Batiment B in _listBatiments)
            {
                B.ToString();
            }
        }
        
        public void AddABatiment(Batiments.Batiment B)
        {
            _listBatiments.Add(B);
        }
        public void AfficheMap()
        {
            String chRes = "";
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Mat[i, j] != null)
                    {
                        chRes += Mat[i, j];
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
            String chRes = "";
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if (Mat[i, j] != null)
                    {
                        chRes += Mat[i, j];
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
        public void PreviewBatimentCreation(Batiment B,int x, int y)
        {
            String chRes = "";
            Mat[x,y] = B;
            for (int i = 0; i < Nbl; i++)
            {
                for (int j = 0; j < Nbc; j++)
                {
                    if(Mat[i, j] == Mat[x, y])
                    {
                        chRes+="Red";
                        
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
        public void Print()
        {
            Console.Clear();
            AfficheMap();
            AfficheListe(POSITION_CURSOR);
            NavigateInterface();
        }
        public void Print(Batiment B,int x, int y)
        {
            Console.Clear();
            PreviewBatimentCreation(B,x,y);
            NavigateMap(B);
        }
        public void AfficheListe()
        {
            for (int i = 0; i < _listBatiments.Count && i < NB_PAGE_OBJECT+1; i++) 
            {
                Object O = _listBatiments[i];
                if(O == null)
                {
                    Console.WriteLine(i + "- ");
                }
                else
                {
                    Console.WriteLine(i + "- " + O.ToString());
                }
            }
        }
        public void AfficheListe(int place)
        {
            Console.WriteLine("LIST OBJECT");
            for (int i = 0; i < _listBatiments.Count && i < NB_PAGE_OBJECT + 1; i++)
            {
                try
                {
                    Object O = _listBatiments[i + PAGE_OBJECT * NB_PAGE_OBJECT];

                    if (i == place)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine((i + "- " + O.GetType())) ;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(i + "- " + O.GetType());
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
            if(key == ConsoleKey.B)
            {
                Batiment B = new Batiments.ListInteract.Dormitory(GenerateTab(2,2), true, this);
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
                AfficheMap();
                Console.WriteLine(B.ToString());
            }
            else
            {
                PNJ.PNJ P = (PNJ.PNJ)O;
                Console.Clear();
                AfficheMap();
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

            if (key == ConsoleKey.DownArrow)
            {
                x++;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                x--;
            }
            if (key == ConsoleKey.RightArrow)
            {
                y++;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                y--;
            }

            /*if (key == ConsoleKey.Escape)
            {
                PAGE_OBJECT = 0;
                POSITION_CURSOR = 0;
                Print();
            }*/

            Print(B, x, y);


        }
        }
}
