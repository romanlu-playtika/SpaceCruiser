using UnityEngine;

public class CalculateGameTime : MonoBehaviour
{
    public void CalculateTime()
    {
        ScoreManager.ChangeGameTime();
        
        EventsObserver.Publish(new ChangeGameTimeEvent());
    }
}
