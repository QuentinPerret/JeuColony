using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.Batiments;


namespace JeuColony
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseMap M = new BaseMap();
            M.Print();
            Console.ReadLine();
        }
    }
}
