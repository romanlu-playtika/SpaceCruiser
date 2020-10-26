using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _scoreAddingDelay = 1.0f;
    
    private bool _isPlayerBoosted;

    private void Awake()
    {
        ScoreManager.InitScore();
    }

    private void OnEnable()
    {
        EventsObserver.AddEventListener<PlayerBoostEvent>(BoostListener);
        EventsObserver.AddEventListener<PlayerDeathEvent>(EndGameSession);
        EventsObserver.AddEventListener<StopTimeEvent>(PauseListener);
    }

    private void Start()
    {
        EventsObserver.Publish(new StopTimeEvent(true));
        StartCoroutine(ScoreAdder());
    }

    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<PlayerBoostEvent>(BoostListener);
        EventsObserver.RemoveEventListener<PlayerDeathEvent>(EndGameSession);
        EventsObserver.RemoveEventListener<StopTimeEvent>(PauseListener);
    }

    private IEnumerator ScoreAdder()
    {
        var delay = new WaitForSeconds(_scoreAddingDelay);

        while (true)
        {
            yield return delay;

            if (!_isPlayerBoosted)
            {
                ScoreManager.AddRegularScore();
            }
            else
            {
                ScoreManager.AddBoostScore();
            }
        }
    }

    private void EndGameSession(PlayerDeathEvent e)
    {
        DataSaver.SaveData();
        EventsObserver.Publish(new StopTimeEvent(true));
    }

    private void BoostListener(PlayerBoostEvent boostEvent)
    {
        _isPlayerBoosted = boostEvent.IsBoosted;
    }
    
    private void PauseListener(StopTimeEvent e)
    {
        var time = (e.IsTimeStopped) ? 0 : 1;
        
        SetTimeScale(time);
    }
    
    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }
    
}