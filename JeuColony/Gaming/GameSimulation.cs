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
        public int NbRoundPlay{get;set;}
        public InterfaceUser InterfaceUser { get; set; }
        public MapGame MapGame { get; set; }
        public PlayerInventory PlayerInventory { get; set; }
        public bool PLAY_TURN = true;
        protected static readonly Random random = new Random();
        public GameSimulation()
        {
            NbRoundPlay = 0;
            Console.SetWindowSize(150, 40);
            PlayerInventory = new PlayerInventory();
            MapGame = new MapGame(this);
            InterfaceUser = new InterfaceUser(this,MapGame);
        }
        public void PlayFirstTurn()
        {
            while (PLAY_TURN)
            {
                InterfaceUser.StartPrinting();
            }
        }
        public void PlayOneTurn()
        {
            for(int i = 0; i < MapGame.ListPNJEnemy.Count; i++)
            {   
                Enemy E= MapGame.ListPNJEnemy[i];
                E.PlayOneTurn();
            }
            for(int i = 0; i < MapGame.ListPNJAlly.Count; i++)
            {
                Ally A = MapGame.ListPNJAlly[i];
                A.PlayOneTurn();
            }
            if (NbRoundPlay < 50)
            {
                if (random.Next(10) == 0)
                {
                    MapGame.AddPNJEnemy(new Enemy("Enemy", MapGame));
                }
            }
            else
            {
                if (random.Next(3) == 0)
                {
                    MapGame.AddPNJEnemy(new Enemy("Enemy", MapGame));
                }
            }
            MapGame.TestNaturalElement();
            PLAY_TURN = true ;
            NbRoundPlay ++;
            while (PLAY_TURN)
            {
                InterfaceUser.StartPrinting();
            }
        }
        public void Start()
        {
            PlayFirstTurn();
            while(MapGame.ListPNJAlly.Count > 0)
            {
                PlayOneTurn();
            }
        }
        public void EndTurn() { PLAY_TURN = false; }
    }
}
