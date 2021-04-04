using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPools : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    
    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolsDictionary;
    
    public static SpawnPools Instance;
    private void Awake()
    {
        Instance = this;
        poolsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); 
                
            for (int i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            poolsDictionary.Add(pool.tag, objectPool);
        }
    }
    
    public List<GameObject> GetActivePoolObjects(string tag)
    {
        if (!poolsDictionary.ContainsKey(tag))
        {
            Debug.Log($"Pool with ${tag} doesn't exist!");
            return null;
        }

        List<GameObject> wantedObjects = new List<GameObject>();
        foreach (var obj in poolsDictionary[tag])
        {
            if (obj.active)
                wantedObjects.Add(obj);
        }

        return wantedObjects;
    }

    public GameObject SpawnFromPool(string tag, Transform tf = null)
    {
        if (!poolsDictionary.ContainsKey(tag))
        {
            Debug.Log($"Pool with ${tag} doesn't exist!");
            return null;
        }
        
        var wantedObject = poolsDictionary[tag].Dequeue();
        wantedObject.SetActive(true);

        if (tf)
        {
            wantedObject.transform.position = tf.position;
            wantedObject.transform.rotation = tf.rotation;
            wantedObject.transform.forward = tf.forward;
        }

        var pooledObject = wantedObject.GetComponent<IPoolable>();

        pooledObject?.OnSpawn();
        
        poolsDictionary[tag].Enqueue(wantedObject);
        return wantedObject;
    }
}
