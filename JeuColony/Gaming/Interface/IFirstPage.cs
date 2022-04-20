using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony;
using JeuColony.Batiments;
using JeuColony.PNJFolder;

namespace JeuColony
{
    internal class IFirstPage : InterfaceUser
    {
        readonly IPnj _pnjPage;
        readonly IBatiment _batPage;
        public IFirstPage(GameSimulation G, MapGame M) : base(G, M)
        {
            _pnjPage = new IPnj(Simulation, MapGame, this);
            _batPage = new IBatiment(Simulation, MapGame, this);
        }
        public void PrintFirstPage()
        {
            while (Simulation.PLAY_TURN)
            {
                Console.Clear();
                MapGame.AfficheMap();
                ProposeList(POSITION_CURSOR);
                NavigateInterface(0);
            }
            //PrintFirstPage();
        }
        private void NavigateInterface(int nbPageMax)
        {
            Key = Console.ReadKey().Key;
            if (Key == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (Key == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (Key == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (Key == ConsoleKey.DownArrow && POSITION_CURSOR < 1)
            {
                POSITION_CURSOR++;
            }
            if (Key == ConsoleKey.Enter)
            {
                if (POSITION_CURSOR == 0)
                {
                    _pnjPage.PrintListPNJ();
                }
                else
                {
                    POSITION_CURSOR = 0;
                    _batPage.PrintListBat();
                }
            }
            if (Key == ConsoleKey.Spacebar)
            {
                Simulation.EndTurn();
            }
        }
        private void ProposeList(int place)
        {
            Console.WriteLine("LIST OBJECT, Round Played : " + Simulation.NbRoundPlay);
            string[] list = new string[] { " - LIST PNJ", " - LIST BATIMENT" };
            for (int i = 0; i < list.Length; i++)
            {
                if (i == place)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Console.WriteLine((i + "- " + O)) ;
                    Console.WriteLine(list[i]);
                    Console.ResetColor();
                }
                else
                {
                    //Console.WriteLine(i + "- " + O);
                    Console.WriteLine(list[i]);
                }
            }
        }
    }
}
