namespace JeuColony.Batiments
{
    abstract class NaturalElement : Batiment
    {
        public NaturalElement(MapGame Map) : base(Map)
        {
            GenerateAleaSize();
            GenerateHP();
            GeneratePositionAlea();
        }

        protected void GenerateAleaSize()
        {
            Size[0] = random.Next(1,4);
            Size[1] = random.Next(1,4);
        }
        protected void GenerateHP()
        {
            int area = Size[0]*Size[1];
            int Hp = 10 * area;
            HealthPointMax = Hp;
            HealthPoint = Hp;
        }

    }
}
