using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private string _poolKey;

    private Vector3 _newRoadPosition;

    private void Update()
    {
        if (_playerTransform.position.z >= _newRoadPosition.z - _spawnDistance)
        {
            SpawnRoad(_poolKey, _newRoadPosition, Quaternion.identity);
        }
    }

    private void SpawnRoad(string key, Vector3 position, Quaternion rotation)
    {
        var roadGameObject = ObjectPooler.Instance.SpawnFromPool(key, position, rotation);
        
        //spawning asteroids on the spawned road prefab
        var asteroidSpawner = roadGameObject.GetComponent<AsteroidsSpawner>();
        asteroidSpawner?.SpawnAsteroids();
        
        //setting position for the next road prefab
        _newRoadPosition = new Vector3(_newRoadPosition.x, _newRoadPosition.y, _newRoadPosition.z + _spawnDistance);
    }
}