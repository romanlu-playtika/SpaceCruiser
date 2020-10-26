using TMPro;
using UnityEngine;

public class GameplayUIController : AbstractUIMenuBase
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _asteroidsText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _hiScoreText;
    
    private void OnEnable()
    {
        EventsObserver.AddEventListener<AvoidAsteroidEvent>(AsteroidListener);
        EventsObserver.AddEventListener<ChangeScoreEvent>(ScoreListener);
        EventsObserver.AddEventListener<ChangeGameTimeEvent>(ChangeTimeListener);
    }
    
    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<AvoidAsteroidEvent>(AsteroidListener);
        EventsObserver.RemoveEventListener<ChangeScoreEvent>(ScoreListener);
        EventsObserver.RemoveEventListener<ChangeGameTimeEvent>(ChangeTimeListener);
    }

    private void ScoreListener(ChangeScoreEvent e)
    {
        if (_scoreText)
        {
            _scoreText.text = e.Score.ToString();
        }
        
        if (_hiScoreText)
        {
            _hiScoreText.text = e.HighestScore.ToString();
        }
    }

    private void AsteroidListener(AvoidAsteroidEvent e)
    {
        if (_asteroidsText)
        {
            _asteroidsText.text = e.Asteroids.ToString();
        }
    }
    
    private void ChangeTimeListener(ChangeGameTimeEvent e)
    {
        if (_timeText)
        {
            _timeText.text = ScoreManager.GameTime.ToString();
        }
    }
}
