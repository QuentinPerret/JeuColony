using JeuColony.Batiments;
using JeuColony.PNJFolder;
using System;
using System.Collections.Generic;


namespace JeuColony
{
    class GameSimulation
    {
        public InterfaceUser InterfaceUser { get; set; }
        public MapGame MapGame { get; set; }
        public PlayerInventory PlayerInventory { get; set; }
        public GameSimulation()
        {
            Console.SetWindowSize(150, 40);
            PlayerInventory = new PlayerInventory();
            MapGame = new MapGame(this);
            InterfaceUser = new InterfaceUser(this,MapGame);
            
        }
        public void PlayOneTurn()
        {
            InterfaceUser.StartPrinting();
        }
        public void Start() { }
    }
}
