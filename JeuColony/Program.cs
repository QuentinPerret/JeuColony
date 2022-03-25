using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.GenMap;

namespace JeuColony
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseMap M = new BaseMap();
            InterfaceMap Im = new InterfaceMap();
            M.Print();
            Console.ReadLine();
        }
        
    }
}
