using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private ParticleSystem particles;
    public void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (!particles.isPlaying)
        {
            gameObject.SetActive(false);
            particles.Clear();
        }
    }
}
