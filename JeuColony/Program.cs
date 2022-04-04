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
            GameSimulation G = new GameSimulation();
            G.PlayOneTurn();
            Console.ReadLine();
        }
    }
}
