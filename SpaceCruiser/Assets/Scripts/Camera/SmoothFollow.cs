using System;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float Distance = 10.0f;
    public float BoostedDistance = 5.0f;
    public float Height = 5.0f;
    public float BoostedHeight = 2.0f;
    public float HeightDamping = 2.0f;
    public float RotationDamping = 3.0f;
    public float BoostDamping = 5.0f;
    public Transform Target;

    private float startDistance = 0;
    private float startHeight = 0;

    private bool _isShipBoosted;

    private void Start()
    {
        startDistance = Distance;
        startHeight = Height;
    }

    private void OnEnable()
    {
        EventsObserver.AddEventListener<PlayerBoostEvent>(ChangeSmoothParameters);
    }

    private void OnDisable()
    {
        EventsObserver.RemoveEventListener<PlayerBoostEvent>(ChangeSmoothParameters);
    }

    private void ChangeSmoothParameters(PlayerBoostEvent e)
    {
        _isShipBoosted = e.IsBoosted;
    }

    private void LateUpdate()
    {
        // Early out if we don't have a target
        if (!Target)
        {
            return;
        }

        ChangeZoom();

        // Calculate the current rotation angles
        float wantedRotationAngle = Target.eulerAngles.y;
        float wantedHeight = Target.position.y + Height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle =
            Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, RotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        var pos = transform.position;
        pos = Target.position - currentRotation * Vector3.forward * Distance;
        pos.y = currentHeight;
        transform.position = pos;

        // Always look at the target
        transform.LookAt(Target);
    }

    private void ChangeZoom()
    {
        Distance = Mathf.Clamp(Distance, BoostedDistance, startDistance);
        Height = Mathf.Clamp(Height, BoostedHeight, startHeight);
        
        var damping = BoostDamping * Time.deltaTime;
        
        if (_isShipBoosted)
        {
            Distance -= damping;
            Height -= damping;
        }
        else
        {
            Distance += damping;
            Height += damping;
        }
    }
}