using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIController : AbstractUIMenuBase
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _asteroidsText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreBreakText;

    private void OnEnable()
    {
        InitText(_scoreText, DataSaver.GetScore().ToString());
        InitText(_highScoreText, DataSaver.GetHighScore().ToString());
        InitText(_asteroidsText, DataSaver.GetAsteroids().ToString());
        InitText(_timeText, DataSaver.GetTime().ToString());

        SetHighScoreMessage();
    }

    private void InitText(TextMeshProUGUI textMeshPro, string textValue)
    {
        if (textMeshPro)
        {
            textMeshPro.text = textValue;
        }
    }

    private void SetHighScoreMessage()
    {
        if (_highScoreBreakText)
        {
            _highScoreBreakText.gameObject.SetActive(ScoreManager.IsHighScoreBroken());
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}