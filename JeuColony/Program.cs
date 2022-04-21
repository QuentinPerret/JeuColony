using System;

namespace JeuColony
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSimulation G = new GameSimulation();
            G.Start();
            Console.ReadLine();
        }
    }
}
