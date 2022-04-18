using JeuColony.Batiments;
using JeuColony.PNJFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JeuColony
{
    class GameSimulation
    {
        public InterfaceUser InterfaceUser { get; set; }
        public MapGame MapGame { get; set; }
        public PlayerInventory PlayerInventory { get; set; }
        public bool PLAY_TURN = true;
        public GameSimulation()
        {
            Console.SetWindowSize(150, 40);
            PlayerInventory = new PlayerInventory();
            MapGame = new MapGame(this);
            InterfaceUser = new InterfaceUser(this,MapGame);
            
        }
        public void PlayOneTurn()
        {
            while (PLAY_TURN)
            {
                InterfaceUser.StartPrinting();
                foreach (PNJ P in MapGame.ListPNJ)
                {
                    P.PlayOneTurn();
                }
            }
            PLAY_TURN = true ;
        }
        public void Start()
        {
            for(int i  =0; i < 5; i++)
            {
                PlayOneTurn();
            }
        }
        public void EndTurn() { PLAY_TURN = false; }
    }
}
