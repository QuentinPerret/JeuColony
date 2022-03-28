using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;

namespace JeuColony.GenMap
{
    class BaseMap
    {
        private static int POSITION_CURSOR = 0;
        private static int PAGE_OBJECT = 0;
        private static int NB_PAGE_OBJECT = 9;
        private int _nbl, _nbc;
        private object[,] _mat;
        private readonly List<Batiments.Batiment> _listBatiments;
        protected Random r = new Random();
        public BaseMap()
        {
            Console.SetWindowSize(150, 40);
            _nbc = 30;
            _nbl = 30;
            _listBatiments = new List<Batiment>();
            this.GenerateSquare();
            this.GenerateBatiments();
            //r = new Random();
            //this.ShowBatiments();
        }
        public void GenerateSquare()
        {
            _mat = new object[_nbl, _nbc];
            

        }
        
        public void GenerateBasicBatiments()
        {
            int nb;
            int nbMaxBatiments = 40;
            nb = r.Next(4, nbMaxBatiments);
            AddABatiment(new Batiments.ListInteract.Dormitory(1, GeneratePosition(1), true, 1));
            AddABatiment(new Batiments.ListInteract.Cantina(2, GeneratePosition(2), true, 1));
            for(int i=0; i<nb/4; i++)
            {
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Forest(2, GeneratePosition(2), true));
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Mountain(2, GeneratePosition(2), true));
                AddABatiment(new Batiments.ListFixed.ListNaturalElement.Water(5, GeneratePosition(5), true));
            }
            

        }
        public void GenerateBatiments()
        {
            GenerateBasicBatiments();
        }
        public int[] GeneratePosition(int size)
        {
            int posx = r.Next(0, _nbl - 1 - size); // Génération aléatoire de la position en x
            int posy = r.Next(0, _nbc - 1-size); // Génération aléatoire de la position en y
            int[] tab = { posx, posy };
            return tab;
        }
        public void ShowBatiments()
        {
            foreach (Batiment B in _listBatiments)
            {
                B.AfficheBatiment();
            }
        }
        
        public void AddABatiment(Batiments.Batiment B)
        {
            _listBatiments.Add(B);
            _mat[B.Coordinate[0], B.Coordinate[1]] = B;
            int cpt = 0;

                if (cpt != B.Size -1&& B.Coordinate[0] +1< _nbl&& _mat[B.Coordinate[0] + 1, B.Coordinate[1]]==null)
                {
                    _mat[B.Coordinate[0] + 1, B.Coordinate[1]] = B;
                    cpt++;
                    if (cpt != B.Size -1&& B.Coordinate[1] -1> 0 && _mat[B.Coordinate[0] , B.Coordinate[1]-1] == null)
                    {
                        _mat[B.Coordinate[0], B.Coordinate[1] - 1] = B;
                        cpt++;
                        if (cpt != B.Size -1&& B.Coordinate[0] -1> 0 && _mat[B.Coordinate[0] - 1, B.Coordinate[1]] == null)
                        {
                            _mat[B.Coordinate[0] - 1, B.Coordinate[1]] = B;
                            cpt++;
                            if (cpt != B.Size -1&& B.Coordinate[1] +1< _nbc && _mat[B.Coordinate[0] , B.Coordinate[1]+1] == null)
                            {
                                _mat[B.Coordinate[0], B.Coordinate[1] + 1] = B;
                                cpt++;

                            }
                        }
                    }
                }
            
            

            
        }
        public void AfficheMap()
        {
            String chRes = "";
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    Batiment B = (Batiment)_mat[i, j];
                    if (B != null)
                    {
                        chRes += B.AfficheBatiment();
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
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    if (_mat[i, j] != null)
                    {
                        chRes += _mat[i, j];
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
                        Console.WriteLine((i + "- " + O.ToString()));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(i + "- " + O.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException) { }
        }
        }
        public void NavigateInterface()
        {
            int nbPageMax = _listBatiments.Count / NB_PAGE_OBJECT;
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine(key);
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
            Print();
        }
    }
}
