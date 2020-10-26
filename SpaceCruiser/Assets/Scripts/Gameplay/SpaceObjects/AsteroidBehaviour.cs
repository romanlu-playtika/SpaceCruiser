using UnityEngine;

public class AsteroidBehaviour : SpaceObjectBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();

        if (player)
        {
            player.PlayerDamage();
        }
    }
}