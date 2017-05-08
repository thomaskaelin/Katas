namespace KataSmells.Example1Refactored
{
    public interface IPerson
    {
        Id Id { get; }

        string Lastname { get; }

        string Firstname { get; }

        Gender Gender { get; }

        int Age { get; }

        Address Address { get; }
    }
}
