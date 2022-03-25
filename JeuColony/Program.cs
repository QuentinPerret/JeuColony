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
            BaseMap M = new GenMap.BaseMap();
            
            M.Print();
            Console.ReadLine();
        }
        
    }
}
