namespace KataSmells.Example4Refactored
{
    public interface IMovie
    {
        int PriceCode { get; set; }
        string Title { get; }

        double GetCharge(int daysRented);
    }
}