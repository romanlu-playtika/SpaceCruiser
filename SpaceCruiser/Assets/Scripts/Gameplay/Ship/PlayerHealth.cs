using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _playerHealth = 1;
    
    
    public void PlayerDamage()
    {
        _playerHealth -= 1;
        
        if (_playerHealth <= 0)
        {
            EventsObserver.Publish(new PlayerDeathEvent());
        }
    }

}
