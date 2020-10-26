using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _gameplaySource;
    [SerializeField] private AudioClip _gameplayMusic;
    [SerializeField] private AudioClip _sessionStopMusic;

    private void OnEnable()
    {
        EventsObserver.AddEventListener<StopTimeEvent>(TurnMusic);
    }

    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<StopTimeEvent>(TurnMusic);
    }

    private void TurnMusic(StopTimeEvent e)
    {
        _gameplaySource.Stop();
        _gameplaySource.clip = !e.IsTimeStopped ? _gameplayMusic : _sessionStopMusic;
        _gameplaySource.Play();
    }
}