

public class ChangeScoreEvent : IEvent
{
    public int Score => _score;

    private int _score;
    
    public int HighestScore => _highestScore;

    private int _highestScore;

    public ChangeScoreEvent(int score , int highestScore)
    {
        _score = score;
        _highestScore = highestScore;
    }
}
