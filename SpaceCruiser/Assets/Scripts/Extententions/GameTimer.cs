using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent _timerEvent;
    
    [SerializeField] private int _delay = 1;
    
    private float _elapsed = 0.0f;
    
    private void Update()
    {
        Timing();
    }

    //invoking unity event once in an interval (_delay)
    private void Timing()
    {
        _elapsed += Time.deltaTime;
        
        if (_elapsed >= _delay)
        {
            _elapsed = 0.0f;
            _timerEvent?.Invoke();
        }
    }

}
