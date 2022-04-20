using System;

namespace JeuColony
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);*/
            //ca plante parce que ca retirenbt les touchges indépendamenbts et pas une pour toutes
            GameSimulation G = new GameSimulation();
            G.Start();
            Console.ReadLine();
        }
    }
}
