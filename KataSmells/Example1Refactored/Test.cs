namespace KataSmells.Example1Refactored
{
    public class Test
    {
        public void Testee()
        {
            Id x = "Hallo";
            string y = x;
            Id z = "welt";
            Id xz = x + z;
        }
    }
}