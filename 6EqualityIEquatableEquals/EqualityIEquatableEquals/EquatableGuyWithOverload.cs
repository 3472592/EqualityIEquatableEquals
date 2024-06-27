namespace EqualityIEquatableEquals
{
    public class EquatableGuyWithOverload : EquatableGuy
    {
        public EquatableGuyWithOverload(string name, int age, int cash) : base(name, age, cash){}

        public static bool operator ==(EquatableGuyWithOverload left, EquatableGuyWithOverload? right)
        {
            /* If we used == to check for null
            instead of Object.ReferenceEquals(),
            we’d get a StackOverflowException. */
            if (Object.ReferenceEquals(left, right)) 
                return true;
            else 
                return left.Equals(right);
        }

        public static bool operator !=(EquatableGuyWithOverload left, EquatableGuyWithOverload? right)
        {
            /* Since we’ve already defined ==,
             we can just invert it for !=. */
            return !(left == right);
        }

        /*  If we don’t override Equals() and
        GetHashCode(), the IDE will give this warning:
        ‘EquatableGuyWithOverload’ defines operator ==
        or operator != but does not override Object.
        GetHashCode(). Since EquatableGuyWithOverload acts
        just like EquatableGuy and Guy, we
        can just call the base methods.*/
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
