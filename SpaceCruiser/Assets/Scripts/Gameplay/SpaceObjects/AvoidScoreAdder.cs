using UnityEngine;

public class AvoidScoreAdder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        
        if (player)
        {
            ScoreManager.AddAvoidScore();
        }
    }
}
