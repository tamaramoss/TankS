using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int TargetCount;
    public GameObject LevelGround;
    public Transform SpawnPosition;
    public float secondsWaitToSpawn = 2f;

    public Bounds LevelBounds => LevelGround.GetComponent<Collider>().bounds;
    public float SpawnHeight => SpawnPosition.position.y;

    private SpawnPools pools;
    
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        pools = SpawnPools.Instance;
        for (int i = 0; i < TargetCount; i++)
        {
            pools.SpawnFromPool("Targets");
        }
    }
    public IEnumerator SpawnNewTarget()
    {
        yield return new WaitForSeconds(secondsWaitToSpawn);
        pools.SpawnFromPool("Targets", transform);
    }
}
