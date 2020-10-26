using UnityEngine;

public static class DataSaver
{
    private const string _highScoreKey = "HighScore";
    private const string _scoreKey = "Score";
    private const string _gameTimeKey = "GameTime";
    private const string _asteroidsKey = "Asteroids";

    public static void SaveData()
    {
        SaveHighScore();
        SaveScore();
        SaveTime();
        SaveAsteroids();
    }
    
    public static void ResetData()
    {
       PlayerPrefs.DeleteAll();
    }
    
    private static void SaveHighScore()
    {
        PlayerPrefs.SetInt(_highScoreKey, ScoreManager.HighestScore);
    }
    
    private static void SaveScore()
    {
        PlayerPrefs.SetInt(_scoreKey, ScoreManager.Score);
    }
    
    private static void SaveTime()
    {
        PlayerPrefs.SetInt(_gameTimeKey, ScoreManager.GameTime);
    }
    
    private static void SaveAsteroids()
    {
        PlayerPrefs.SetInt(_asteroidsKey, ScoreManager.AvoidedAsteroids);
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(_highScoreKey);
    }
    
    public static int GetScore()
    {
        return PlayerPrefs.GetInt(_scoreKey);
    }
    
    public static int GetAsteroids()
    {
        return PlayerPrefs.GetInt(_asteroidsKey);
    }
    
    public static int GetTime()
    {
        return PlayerPrefs.GetInt(_gameTimeKey);
    }
}