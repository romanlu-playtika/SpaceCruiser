using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidAsteroidEvent : IEvent
{
    public int Asteroids => _asteroids;

    private int _asteroids;

    public AvoidAsteroidEvent (int asteroids)
    {
        _asteroids = asteroids;
    }
}
