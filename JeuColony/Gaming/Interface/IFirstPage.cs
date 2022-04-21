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
            _pnjPage = new IPnj(GameSimulation, MapGame, this);
            _batPage = new IBatiment(GameSimulation, MapGame, this);
        }
        public void PrintFirstPage()
        {
            while (GameSimulation.PLAY_TURN)
            {
                Console.Clear();
                MapGame.AfficheMap();
                ProposeList(POSITION_CURSOR);
                PrintInventory();
                NavigateInterface(0);

            }
            //PrintFirstPage();
        }
        private void NavigateInterface(int nbPageMax)
        {
            ConsoleKey KeyBat = Console.ReadKey().Key;
            if (KeyBat == ConsoleKey.UpArrow && POSITION_CURSOR > 0)
            {
                POSITION_CURSOR--;
            }
            if (KeyBat == ConsoleKey.RightArrow && PAGE_OBJECT < nbPageMax)
            {
                PAGE_OBJECT++;
                POSITION_CURSOR = 0;
            }
            else if (KeyBat == ConsoleKey.LeftArrow && PAGE_OBJECT > 0)
            {
                PAGE_OBJECT--;
                POSITION_CURSOR = 0;
            }
            if (KeyBat == ConsoleKey.DownArrow && POSITION_CURSOR < 1)
            {
                POSITION_CURSOR++;
            }
            if (KeyBat == ConsoleKey.Enter)
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
            if (KeyBat == ConsoleKey.Spacebar)
            {
                GameSimulation.EndTurn();
            }
        }
        private void ProposeList(int place)
        {
            Console.WriteLine("LIST OBJECT, Round Played : " + GameSimulation.NbRoundPlay);
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
