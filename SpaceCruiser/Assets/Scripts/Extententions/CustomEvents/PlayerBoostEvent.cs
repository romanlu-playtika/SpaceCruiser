using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostEvent : IEvent
{
    public bool IsBoosted => _isBoosted;
    private bool _isBoosted = false;

    public PlayerBoostEvent(bool isBoosted)
    {
        _isBoosted = isBoosted;
    }
}
