using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            EventsObserver.Publish(new StopTimeEvent(false));
        }
    }
}
