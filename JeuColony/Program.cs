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
            /*Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);*/
            BaseMap M = new BaseMap();
            M.Print();
            Console.ReadLine();
        }
    }
}
