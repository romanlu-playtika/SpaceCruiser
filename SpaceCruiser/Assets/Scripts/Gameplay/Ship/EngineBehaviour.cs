using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _engineFlame;
    [SerializeField] private float _simpleFlameValue;
    [SerializeField] private float _boostedFlameValue;
    
    private void OnEnable()
    {
        EventsObserver.AddEventListener<PlayerBoostEvent>(BoostListener);
    }

    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<PlayerBoostEvent>(BoostListener);
    }
    
    
    private void BoostListener(PlayerBoostEvent e)
    {
        //setting engine flames depending on if player is boosted or not
        _engineFlame.startLifetime = e.IsBoosted ? _boostedFlameValue : _simpleFlameValue;
    }
}
