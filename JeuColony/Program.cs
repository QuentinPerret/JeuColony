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
            GenMap.BaseMap M = new GenMap.BaseMap();
            M.Print();
            Console.ReadLine();
        }
        
    }
}
