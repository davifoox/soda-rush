using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource boostSound;
    [SerializeField] BoostParticles boostParticles;
    [SerializeField] TrailParticles trailParticles;
    public Transform particlesSpawnPoint;

    private Vector3 accelerometerVector = new Vector3();
    private float screenHorizontalLimit = 3.3f;

    private float speed = 15f;
    private float maxSpeed = 18f;
    private float slowDownValue = 0.2f;
    private float gravity = 10f;

    // EVENTS
    public delegate void PlayerBoosted();
    public event PlayerBoosted OnPlayerBoosted;

    float mentosBoostValue = 5f; //isso aqui tem que ir pro próprio mentos

    private void Start()
    {
        trailParticles = Instantiate(trailParticles, particlesSpawnPoint.transform.position, Quaternion.identity);
        trailParticles.player = this;
    }

    void Update()
    {
        accelerometerVector = Input.acceleration;
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        Move();
        MirrorPosition();
        SlowDown();
    }

    public void RotatePlayer()
    {
        Quaternion newRotation = Quaternion.Lerp(
            transform.rotation,
            new Quaternion(transform.rotation.x, transform.rotation.y, -accelerometerVector.x, 1f),
            1f);
        transform.rotation = newRotation;
    }

    void Move()
    {
        transform.Translate(Vector3.up * (speed - gravity) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f); // coloca o sprite atrás das partículas
    }

    void SlowDown()
    {
        if (speed > 0)
            speed -= slowDownValue * Time.deltaTime;
        else
            speed = 0;
    }

    void SpeedUp()
    {
        OnPlayerBoosted();
        SpawnBoostParticles();
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        boostSound.Play();

        speed += mentosBoostValue;
        if (speed > maxSpeed)
            speed = maxSpeed;
    }

    void HitEnemy()
    {
        speed = -5f;
        hitSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) // Single Mentos Layer
        {
            SpeedUp();
        }

        // se colisão for com camada de outro powerup (ex: 3mentos) emitir evento pro level manager resolver (aparecer na ui, etc)

        if (collision.gameObject.layer == 10) // Obstacle Layer
        {
            HitEnemy();
        }
    }

    void MirrorPosition()
    {
        if (transform.position.x > screenHorizontalLimit)
        {
            transform.position = new Vector2(-screenHorizontalLimit, transform.position.y);
        }
        else if (transform.position.x < -screenHorizontalLimit)
        {
            transform.position = new Vector2(screenHorizontalLimit, transform.position.y);
        }
    }

    void SpawnBoostParticles()
    {
        BoostParticles currentParticles;
        currentParticles = Instantiate(boostParticles, particlesSpawnPoint.transform.position, Quaternion.identity);
        currentParticles.player = this;

        trailParticles.StopCoroutine("PauseParticles");
        StartCoroutine(trailParticles.PauseParticles(2f));
    }
}
