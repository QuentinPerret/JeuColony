namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        protected int NbRessouces;
        public NaturalElement(MapGame Map) : base(Map)
        {
            GenerateAleaSize();
            GenerateHNbRessources();
            GeneratePositionAlea();
        }

        protected void GenerateAleaSize()
        {
            Size[0] = random.Next(1,4);
            Size[1] = random.Next(1,4);
        }
        protected void GenerateHNbRessources()
        {
            NbRessouces = 2 * Size[0] * Size[1];
        }
        public void TestExistence()
        {
            if (NbRessouces <= 0)
            {
                MapGame.RemoveBat(this);
            }
        }
    }
}
