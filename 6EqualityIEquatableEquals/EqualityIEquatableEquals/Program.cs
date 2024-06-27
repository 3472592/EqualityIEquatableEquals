namespace EqualityIEquatableEquals
{
    public class Program
    {
        public static void Main(string[]? args)
        {
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            Guy joe1 = new("Joe", 37, 100);
            Guy joe2 = joe1;
            /* Guy.Equals() will only return true if the
            actual values of the objects are the same. */
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2));//t
            Console.WriteLine(joe1.Equals(joe2));//t
            Console.WriteLine(Object.ReferenceEquals(null, null));//t

            joe2 = new Guy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2));//f
            Console.WriteLine(joe1.Equals(joe2));//f

            joe1 = new EquatableGuy("Joe", 37, 100);
            joe2 = new EquatableGuy("Joe", 37, 100);
            Console.WriteLine(Object.ReferenceEquals(joe1, joe2));//f
            Console.WriteLine(joe1.Equals(joe2));//t

            List<Guy> guys = new()
            {
                new Guy("Bob", 42, 125),
                new EquatableGuy(joe1.Name, joe1.Age, joe1.Cash),
                new Guy("Ed", 39, 95)
            };

            /* List.Contains() will go through its
            contents and call each object’s
            Equals() method to compare it with
            the reference you pass to it. */
            Console.WriteLine(guys.Contains(joe1));//t

            /* Even though joe1 and joe2 point to objects
            with the same values, == and != still compare
            the references, not the values themselves */
            Console.WriteLine(joe1 == joe2);//f

            joe1 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);
            joe2 = new EquatableGuyWithOverload(joe2.Name, joe2.Age, joe2.Cash);

            /* It’s calling Guy’s == and
            != operators. Cast to
            EquatableGuyWithOverload to
            call the correct == and != */
            Console.WriteLine(joe1 == joe2); //f
            Console.WriteLine(joe1 != joe2); //t

            Console.WriteLine((EquatableGuyWithOverload)joe1 ==
                              (EquatableGuyWithOverload)joe2); //t
            Console.WriteLine((EquatableGuyWithOverload)joe1 !=
                              (EquatableGuyWithOverload)joe2); //f

            joe2.ReceiveCash(25);
            Console.WriteLine((EquatableGuyWithOverload)joe1 ==
                  (EquatableGuyWithOverload)joe2); //f
            Console.WriteLine((EquatableGuyWithOverload)joe1 !=
                  (EquatableGuyWithOverload)joe2); //t

            Console.ReadKey();
        }
    }
}
