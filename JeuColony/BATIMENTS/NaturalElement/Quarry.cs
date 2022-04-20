﻿using JeuColony.PNJFolder;

namespace JeuColony.Batiments
{
    class Quarry : NaturalElement
    {
        public Quarry( MapGame Map) : base(Map)
        {
            BatimentType = "Mountain";
        }
        public override string ToString()
        {
            string chRes = "";
            chRes += " Q " /*\n####"*/;
            return chRes;
        }
        public void GetHarvast(Ally P)
        {
            NbRessouces -= P.DiggingPower;
            MapGame.Simulation.PlayerInventory.NbStone += P.DiggingPower;
            TestExistence();
        }
    }
}