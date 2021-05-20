using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFollow : MonoBehaviour
{
    [SerializeField] PlayerBehaviour player;
    private Transform target;
    [SerializeField] ParticleSystem particle;
    private float screenHorizontalLimit = 3.3f;

    private void Start()
    {
        target = player.pivot.transform;
        particle = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        transform.position = target.position;
        transform.position = new Vector2(transform.position.x, transform.position.y); //- 0.2f);
        transform.rotation = target.rotation;

        MirrorPosition();
    }

    void MirrorPosition()
    {
        if (target.transform.position.x > screenHorizontalLimit)
        {
            StopCoroutine("PauseParticles");
            StartCoroutine("PauseParticles");
            target.transform.position = new Vector2(-screenHorizontalLimit, target.transform.position.y);
        }
        else if (target.transform.position.x < -screenHorizontalLimit)
        {
            StopCoroutine("PauseParticles");
            StartCoroutine("PauseParticles");
            target.transform.position = new Vector2(screenHorizontalLimit, target.transform.position.y);
        }
    }

    IEnumerator PauseParticles()
    {
        particle.Pause();
        yield return new WaitForSeconds(0.1f);
        particle.Play();
    }
}
