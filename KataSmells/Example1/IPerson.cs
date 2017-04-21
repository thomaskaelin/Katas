namespace KataSmells.Example1
{
    public interface IPerson
    {
        int Id { get; }

        string Lastname { get; }

        string Firstname { get; }

        int Gender { get; }

        int Age { get; }

        string Street { get; }

        string Zip { get; }

        string City { get; }

        string Country { get; }
    }
}
