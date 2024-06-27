namespace EqualityIEquatableEquals
{
    public class Guy
    {

        private readonly string _name;

        public string Name { get { return _name; } }

        private readonly int _age;

        public int Age { get { return _age; } }

        public int Cash { get; private set; }

        public Guy(string name, int age, int cash)
        {
            _name = name;
            _age = age;
            Cash = cash;
        }
        
        public int ReceiveCash(int amount)
        {
            if(amount>0)
            {
                Cash += amount;
                return amount;
            }
            Console.WriteLine("{0} says: {1} isn't an amount I'll take", Name, amount);
            return 0;
        }
    }
}
