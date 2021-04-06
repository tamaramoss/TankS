using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ActiveTargetsInLevel;
    public GameObject Level;
    public Transform ProjectileSpawnPosition;
    public float secondsWaitToSpawn = 2f;

    public Bounds LevelBounds => Level.GetComponent<Collider>().bounds;
    public float SpawnHeight => ProjectileSpawnPosition.position.y;

    private SpawnPools pools;
    
    // Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        pools = SpawnPools.Instance;
        
        // Spawn the targets that should be in the level
        for (int i = 0; i < ActiveTargetsInLevel; i++)
        {
            pools.SpawnFromPool("Targets");
        }
    }
    
    // Spawn new target after some seconds
    public IEnumerator SpawnNewTarget()
    {
        yield return new WaitForSeconds(secondsWaitToSpawn);
        pools.SpawnFromPool("Targets", transform);
    }
}
