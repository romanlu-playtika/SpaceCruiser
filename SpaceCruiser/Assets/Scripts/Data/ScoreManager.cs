public static class ScoreManager
{
    public static int Score => score;
    public static int HighestScore => highestScore;
    public static int AvoidedAsteroids => avoidedAsteroids;
    public static int GameTime => gameGameTime;

    private static int gameGameTime = 0;
    private static int score = 0;
    private static int highestScore = 0;
    private static int startHighestScore = 0;
    private static int avoidedAsteroids = 0;

    private const int RegularScore = 1;
    private const int BoostScore = 2;
    private const int AvoidScore = 5;

    //Setting all scores to default values
    public static void InitScore()
    {
        score = 0;
        gameGameTime = 0;
        highestScore = DataSaver.GetHighScore();
        startHighestScore = highestScore;
    }

    public static void AddRegularScore()
    {
        ChangeScore(RegularScore);
    }

    public static void AddBoostScore()
    {
        ChangeScore(BoostScore);
    }

    public static void AddAvoidScore()
    {
        ChangeScore(AvoidScore);

        AddAvoidedAsteroids();
    }

    public static void ChangeGameTime()
    {
        gameGameTime += 1;
    }
    
    public static bool IsHighScoreBroken()
    {
        return startHighestScore < score;
    }

    private static void SetHighestScore()
    {
        if (highestScore < score)
        {
            highestScore = score;
        }
    }
    
    private static void ChangeScore(int scoreValue)
    {
        score += scoreValue;

        SetHighestScore();

        EventsObserver.Publish(new ChangeScoreEvent(score, highestScore));
    }

    private static void AddAvoidedAsteroids()
    {
        avoidedAsteroids += 1;

        EventsObserver.Publish(new AvoidAsteroidEvent(avoidedAsteroids));
    }
}