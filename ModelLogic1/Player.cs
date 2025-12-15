namespace ModelLogic1
{
    public interface IDomainObject
    {
        int ID { get; set; }
    }
    public enum Position
    {
        PointGuard,
        SmallForward,
        PowerForward,
        Center
    }
    public class Player : IDomainObject
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public Position Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Player()
        {
            Number = 0;
            Name = string.Empty;
            Position = Position.PointGuard;
            Height = 0;
            Weight = 0;
        }
        public Player(int id, int number, string name, string nation, Position position, int height, int weight)
        {
            ID = id;
            Number = number;
            Name = name;
            Nation = nation;
            Position = position;
            Height = height;
            Weight = weight;
        }
        public Player(int number, string name, string nation, Position position, int height, int weight)
        {
            Number = number;
            Name = name;
            Nation = nation;
            Position = position;
            Height = height;
            Weight = weight;
        }
        public int GetID()
        {
            return ID;
        }



    }
}
