using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseMap M = new BaseMap();
            M.Mat[0,0] = 1;
            M.GenerateBatiments();
            //InterfaceMap Im = new InterfaceMap();
            M.Print();
            Console.ReadLine();
        }
    }
}
