using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuColony.PNJFolder;
using JeuColony.Batiments;

namespace JeuColony
{
    internal class InterfaceUser
    {
        protected int POSITION_CURSOR = 0;
        protected int PAGE_OBJECT = 0;
        protected readonly int NB_PAGE_OBJECT = 8;
        public GameSimulation Simulation { get; set; }
        public MapGame MapGame { get; set; }
        public InterfaceUser(GameSimulation G, MapGame M)
        {
            Simulation = G;
            MapGame = M;
        }
        public void StartPrinting()
        {
            IFirstPage FirstPage = new IFirstPage(Simulation, MapGame);
            FirstPage.PrintFirstPage();
        }
    }
}
