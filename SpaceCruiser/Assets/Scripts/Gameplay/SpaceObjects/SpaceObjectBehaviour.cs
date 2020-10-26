using UnityEngine;

public class SpaceObjectBehaviour : MonoBehaviour
{
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] protected Vector3 _rotateVector = Vector3.forward;
    [SerializeField] protected Transform _transformToRotate;

    protected virtual void Update()
    {
        _transformToRotate.Rotate(_rotateVector * _rotationSpeed * Time.deltaTime);
    }
}