using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetScript : MonoBehaviour, IPoolable
{
    private Bounds levelArea;
    private float height;
    private bool wasHit;
    private float radius;
    
    void Awake()
    {
        levelArea = GameManager.Instance.LevelBounds;
        height = GameManager.Instance.SpawnHeight;
        wasHit = false;
        radius = transform.GetComponent<SphereCollider>().radius;
    }

    private void OnCollisionEnter (Collision other)
    {
        if (!other.transform.CompareTag("Projectile") || wasHit) return;
        GameManager.Instance.StartCoroutine("SpawnNewTarget");
        gameObject.SetActive(false);
        wasHit = true;
    }

    public void OnSpawn()
    {
        wasHit = false;
        Vector3 spawnPosition;

        do {
            spawnPosition = GenerateSpawnPosition();
        } while (Physics.OverlapSphere(spawnPosition, radius).Length != 0);
        
        transform.position = spawnPosition;
    }

    private Vector3 GenerateSpawnPosition()
    {
        var min = levelArea.min;
        var max = levelArea.max;
        return new Vector3(Random.Range(min.x + radius , max.x - radius), height, Random.Range(min.z + radius, max.z - radius));
    }
}
