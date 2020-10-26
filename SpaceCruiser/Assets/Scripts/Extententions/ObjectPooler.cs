using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string PoolKey;
        public GameObject Prefab;
        public int Size;
    }
    
    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
        CreatePool();
    }
    #endregion

    [SerializeField] private List<Pool> _pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> _poolDictionary;

    private void CreatePool()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in _pools)
        {
            Queue<GameObject>objectPool = new Queue<GameObject>();
            
            for(int i=0; i<pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.PoolKey, objectPool);
        }
    }

    public GameObject SpawnFromPool (string key, Vector3 position, Quaternion rotation)
    {
        //in case if we missed or misspelled a key
        if (!_poolDictionary.ContainsKey(key))
        {
            Debug.LogWarning("Pool with tag " + key + " doesn't exist");
            return null;
        }
        
        GameObject spawnObject = _poolDictionary[key].Dequeue();
        
        spawnObject.SetActive(true);
        spawnObject.transform.position = position;
        spawnObject.transform.rotation = rotation;
        
        _poolDictionary[key].Enqueue(spawnObject);
        
        return spawnObject;
    }
}
