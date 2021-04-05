using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour, IPoolable
{
    public Projectile Projectile;

    private SpawnPools pools;
    private string name;
    private float moveSpeed;
    private float rotateSpeed;
    private bool isHoming;

    private ParticleSystem fly;
    private Rigidbody rb;
    void Start()
    {
        name = Projectile.name;
        moveSpeed = Projectile.moveSpeed;
        isHoming = Projectile.homing;
        rotateSpeed = Projectile.rotateSpeed;
        rb = GetComponent<Rigidbody>();
        pools = SpawnPools.Instance;
        
    }

    private void Awake()
    {
        fly = transform.Find("Fly").GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        ProjectileMovement();
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag("Target"))
        {
            pools.SpawnFromPool("Success", transform);
        }
        else
        {
            pools.SpawnFromPool("Fail", transform);
        }
        
        fly.Stop();
        gameObject.SetActive(false);
    }

    public void OnSpawn()
    {
        fly.Clear();
        fly.Play();
    }
    
    private void ProjectileMovement()
    {
        if (isHoming)
        {
            var target = SearchTarget();

            if (!(target == Vector3.zero))
            {
                var rotateAmount = Quaternion.LookRotation(target - transform.position);
                rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotateAmount, rotateSpeed));
            }
        }
        
        rb.velocity = transform.forward * (moveSpeed * Time.fixedDeltaTime);
    }

    private Vector3 SearchTarget()
    {
        var activeTargets = pools.GetActivePoolObjects("Targets");
        
        if (activeTargets?.Count == 0)
            return Vector3.zero;

        float shortestDis = Vector3.Distance(activeTargets[0].transform.position, transform.position);
        int idxOfNearestTarget = 0;

        for (int i = 1; i < activeTargets.Count; i++)
        {
            var currentDis = Vector3.Distance(activeTargets[i].transform.position, transform.position);
            if (currentDis < shortestDis)
            {
                shortestDis = currentDis;
                idxOfNearestTarget = i;
            }
        }
        
        return activeTargets[idxOfNearestTarget].transform.position;
    }
}
