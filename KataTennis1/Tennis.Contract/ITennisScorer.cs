namespace Tennis.Contract
{
    public interface ITennisScorer
    {
        string GetScore();
        void PlayerAScores();
        void PlayerBScores();
    }
}