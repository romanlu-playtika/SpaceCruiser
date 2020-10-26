using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _asteroidsToSpawn = new List<GameObject>();

    private int _spawnQuantity;

    public void SpawnAsteroids()
    {
        //determining how many asteroids we have to spawn on a road prefab depending on current difficulty level
        _spawnQuantity = (int) (_asteroidsToSpawn.Count * CalculateDifficulty.CurrentDifficultyValue);

        foreach (var asteroid in _asteroidsToSpawn)
        {
            asteroid.SetActive(false);
        }

        while (_spawnQuantity > 0)
        {
            foreach (var asteroid in _asteroidsToSpawn)
            {
                if (_spawnQuantity <= 0)
                {
                    break;
                }

                //getting 10% chance to spawn an asteroid to the particular spot to randomize
                var random = Random.Range(0, 9);
                
                //if 10% chance passed and the spot is free, place an asteroid (set it active)
                if (random < 1 && !asteroid.activeSelf)
                {
                    asteroid.SetActive(true);

                    _spawnQuantity--;
                }
            }
        }
    }
}