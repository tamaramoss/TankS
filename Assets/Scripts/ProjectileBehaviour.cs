using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ProjectileBehaviour : MonoBehaviour, IPoolable
{
    public Projectile Projectile;

    private SpawnPools pools;
    private string name;
    private float moveSpeed;
    private float rotateSpeed;
    private bool isHoming;
    

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
        gameObject.SetActive(false);
    }

    public void OnSpawn()
    {
        var p = transform.Find("Fly").GetComponent<ParticleSystem>();
        p.Clear();
        p.Play();
    }

    private void ProjectileMovement()
    {
        if (isHoming)
        {
            var target = SearchTarget();
            var rotateAmount = Quaternion.LookRotation((target - transform.position) );
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotateAmount, rotateSpeed));
        }
        
        rb.velocity = transform.forward * (moveSpeed * Time.deltaTime);
    }

    private Vector3 SearchTarget()
    {
        var activeTargets = SpawnPools.Instance.GetActivePoolObjects("Targets");
        
        if (activeTargets.Count == 0)
            return Vector3.left;
        
        float distance = 10000;
        int idxOfNearestTarget = 0;

        for (int i = 0; i < activeTargets.Count; i++)
        {
            var d = Vector3.Distance(activeTargets[i].transform.position, transform.position);
            if (d < distance)
            {
                distance = d;
                idxOfNearestTarget = i;
            }
        }
        
        return activeTargets[idxOfNearestTarget].transform.position;
    }
}
