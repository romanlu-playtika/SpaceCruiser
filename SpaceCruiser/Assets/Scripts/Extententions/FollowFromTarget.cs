using UnityEngine;

public class FollowFromTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _step;
    
    private void Start()
    {
        //determining starting range from the target
        _step = transform.position - _target.position;
    }
    
    private void LateUpdate()
    {
        //moving with the target within determined range
        transform.position = _target.position + _step;
    }
}