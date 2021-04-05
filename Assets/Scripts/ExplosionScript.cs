using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (!particles.isPlaying)
        {
            particles.Clear();
            gameObject.SetActive(false);
        }
    }
}
