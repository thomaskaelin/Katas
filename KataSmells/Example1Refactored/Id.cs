namespace KataSmells.Example1Refactored
{
    public class Id
    {
        public string Value { get; set; }

        public static implicit operator Id (string idAsString)
        {
            return new Id() {Value = idAsString};
        }

        public static implicit operator string(Id idAsObject)
        {
            return idAsObject.Value;
        }

        public static Id operator +(Id first, Id second)
        {
            return new Id(){Value = first.Value + second.Value};
        }
    }
}