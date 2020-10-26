using UnityEngine;

public class BeforeStartUIController : AbstractUIMenuBase
{
    private void Update()
    {
        if (Input.anyKey)
        {
            EventsObserver.Publish(new StopTimeEvent(false));
        }
    }

}