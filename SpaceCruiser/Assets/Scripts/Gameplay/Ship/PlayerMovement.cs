using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 5.0f;
    [SerializeField] private float _strafeSpeed = 5.0f;
    [SerializeField] private float _tiltSpeed = 5.0f;
    [SerializeField] private float _tiltExtent = 50.0f;
    [SerializeField] private float _strafeLimit = 4.0f;
    [SerializeField] private float _boostModifier = 2.0f;

    private const string inputKey = "Horizontal";

    private bool _boosted = false;

    private void PlayerStrafe(Vector2 direction)
    {
        transform.Translate(direction * _strafeSpeed * Time.deltaTime, Space.World);

        //setting maximum values of strafing (x axis)
        Vector3 maxPosition = transform.position;
        maxPosition.x = Mathf.Clamp(maxPosition.x, -_strafeLimit, _strafeLimit);
        transform.position = maxPosition;
    }

    private void PlayerRotate(Vector3 tilt)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-tilt), _tiltSpeed * Time.deltaTime);
    }

    private void PlayerAccel(bool Boosted)
    {
        var boostVector = (Boosted)
            ? Vector3.forward * _movingSpeed * _boostModifier * Time.deltaTime
            : Vector3.forward * _movingSpeed * Time.deltaTime;

        transform.Translate(boostVector);
    }

    private void Update()
    {
        var input = Input.GetAxis(inputKey);
        var direction = new Vector2(input, 0);
        var tilt = new Vector3(0, 0, input * _tiltExtent);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PublishBoostEvent();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PublishBoostEvent();
        }

        PlayerStrafe(direction);
        PlayerRotate(tilt);
        PlayerAccel(_boosted);
    }

    private void PublishBoostEvent()
    {
        _boosted = !_boosted;

        EventsObserver.Publish(new PlayerBoostEvent(_boosted));
    }
}