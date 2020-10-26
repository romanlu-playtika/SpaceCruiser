
public class StopTimeEvent : IEvent
{
    public bool IsTimeStopped => _isTimeStopped;

    private bool _isTimeStopped;

    public StopTimeEvent(bool isTimeStopped)
    {
        _isTimeStopped = isTimeStopped;
    }
}
