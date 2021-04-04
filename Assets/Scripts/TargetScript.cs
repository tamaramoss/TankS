using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetScript : MonoBehaviour, IPoolable
{
    private Bounds levelArea;
    private float height;
    private bool wasHit;
    void Awake()
    {
        levelArea = GameManager.Instance.LevelBounds;
        height = GameManager.Instance.SpawnHeight;
        wasHit = false;
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag("Projectile") && !wasHit)
        {
            GameManager.Instance.StartCoroutine("SpawnNewTarget");
            gameObject.SetActive(false);
            wasHit = true;
        }
    }

    public void OnSpawn()
    {
        wasHit = false;
        bool validPositionFound = false;
        int count = 0;
        
        while (!validPositionFound && count <= 40)
        {
            var spawnPosition = GenerateSpawnPosition();
            bool hit = Physics.SphereCast(spawnPosition, transform.GetComponent<Collider>().bounds.extents.x / 2, Vector3.zero, out var hitInfo);
            
            if (!hit)
            {
                transform.position = spawnPosition;
                validPositionFound = true;
            }

            count++;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        var min = levelArea.min;
        var max = levelArea.max;
        var sphereSize = transform.GetComponent<Collider>().bounds.extents.x * 2;
        return new Vector3(Random.Range(min.x + sphereSize , max.x - sphereSize), height, Random.Range(min.z + sphereSize, max.z - sphereSize));
    }
}
