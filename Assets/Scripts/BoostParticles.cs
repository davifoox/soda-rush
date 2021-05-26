using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostParticles : MonoBehaviour
{
    public Player player;
    private Transform target;
    private ParticleSystem particle;
    private float screenHorizontalLimit = 3.3f;

    private void Start()
    {
        target = player.particlesSpawnPoint.transform;
        particle = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        transform.position = target.position;
        transform.position = new Vector2(transform.position.x, transform.position.y); //- 0.2f);
        transform.rotation = target.rotation;

        if (!particle.isEmitting)
            Destroy(this.gameObject);
        MirrorPosition();
    }

    void MirrorPosition()
    {
        if (target.transform.position.x > screenHorizontalLimit)
        {
            StopCoroutine("PauseParticles");
            StartCoroutine(PauseParticles(0.1f));
        }
        else if (target.transform.position.x < -screenHorizontalLimit)
        {
            StopCoroutine("PauseParticles");
            StartCoroutine(PauseParticles(0.1f));
        }
    }

    public IEnumerator PauseParticles(float waitTime)
    {
        particle.Stop();
        yield return new WaitForSeconds(waitTime);
        particle.Play();
    }
}
