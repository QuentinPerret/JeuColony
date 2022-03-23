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
        private int _nbl, _nbc;
        private object[,] _mat;
        private readonly List<Batiments.Batiment> _listBatiments;
        //private readonly List<string> _basicBatiments;
        public BaseMap()
        {
            Console.SetWindowSize(85, 33);
            _nbc = 5;
            _nbl = 5;
            _listBatiments = new List<Batiment>();
            this.GenerateSquare();
            this.GenerateBatiments();
            //this.ShowBatiments();
        }
        public void GenerateSquare()
        {
            _mat = new object[_nbl, _nbc];
            

        }
        public void GenerateBasicBatiments()
        {
            

        }
        public void GenerateBatiments()
        {
            Random r = new Random();
            int nb;
            int posx = r.Next(0, _nbl - 1); // Génération aléatoire de la position en x
            int posy = r.Next(0, _nbc - 1); // Génération aléatoire de la position en y
            int[] tab = { posx, posy };
            int nbMaxBatiments = 20;
            nb = r.Next(0, nbMaxBatiments);
            AddABatiment(new Batiments.ListInteract.Dormitory(2, tab, true, 1));
            
        }
        public void ShowBatiments()
        {
            foreach (Batiment B in _listBatiments)
            {
                Console.WriteLine(B);
            }
        }
        public void AddABatiment(Batiments.Batiment B)
        {
            _listBatiments.Add(B);
            _mat[B.Coordinate[0], B.Coordinate[1]] = B;
            for(int i = 0; i < B.Size; i++)
            {
                if (B.Coordinate[1] != _nbc)
                {
                    _mat[B.Coordinate[0]+i, B.Coordinate[1]] = B;
                }
                else
                {
                    _mat[B.Coordinate[0], B.Coordinate[1]+1] = B;
                }
            }
        }
        public override string ToString()
        {
            String chRes = "";
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    if (_mat[i, j] != null)
                        chRes += _mat[i, j];
                    else
                        chRes += " . ";
                }
                chRes += "\n";
            }
            return chRes;
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}
