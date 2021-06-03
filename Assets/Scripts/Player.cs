using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource boostSound;
    [SerializeField] BoostParticles boostParticles;
    [SerializeField] TrailParticles trailParticles;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Transform particlesSpawnPoint;

    private Vector3 accelerometerVector = new Vector3();
    private float screenHorizontalLimit = 3.3f;

    private float speed = 15f;
    private float maxSpeed = 18f;
    private float slowDownValue = 0.2f;
    private float gravity = 10f;

    public bool isInvincible = false;
    private float invicibilityTimer = 6f;
    private float currentinvicibilityTimer = 0f;

    // EVENTS
    public delegate void PlayerBoosted(float shakeTime);
    public event PlayerBoosted OnPlayerBoosted;

    public delegate void PlayerGotInvicible(bool value);
    public event PlayerGotInvicible OnPlayerGotInvincible;

    public delegate void PlayerPickedMentos(int quantity, string mentosColor);
    public event PlayerPickedMentos OnPlayerPickedMentos;
    // ------

    float mentosBoostValue = 5f; // colocar no próprio mentos?

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
        SlowDown();
        MirrorPosition();

        if (currentinvicibilityTimer > 0)
            currentinvicibilityTimer -= Time.deltaTime;
        else if (isInvincible == true)
        {
            BackToNormal();
        }
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

    public void Boost(float shakeTime)
    {
        GameManager.Instance.VibratePhone(50);
        OnPlayerBoosted(shakeTime);
        SpawnBoostParticles();
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        boostSound.Play();

        speed += mentosBoostValue;
        if (speed > maxSpeed)
            speed = maxSpeed;
    }

    void Invincible()
    {
        Boost(invicibilityTimer);
        GetComponent<Animation>().Play();
        spriteRenderer.color = Color.red;
        currentinvicibilityTimer = invicibilityTimer;
        OnPlayerGotInvincible(false);
        isInvincible = true;
    }

    void BackToNormal()
    {
        GetComponent<Animation>().Stop();
        spriteRenderer.color = Color.white;
        currentinvicibilityTimer = 0;
        OnPlayerGotInvincible(true);
        isInvincible = false;
    }

    void SpawnBoostParticles()
    {
        BoostParticles currentParticles;
        currentParticles = Instantiate(boostParticles, particlesSpawnPoint.transform.position, Quaternion.identity);
        currentParticles.player = this;

        trailParticles.StopCoroutine("PauseParticles");
        StartCoroutine(trailParticles.PauseParticles(2f));
    }

    void HitEnemy()
    {
        GameManager.Instance.VibratePhone(100);
        Vibration.VibratePeek();
        speed = -5f;
        hitSound.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) // Power Up Layer
        {
            PowerUp powerUp = collision.gameObject.GetComponent<PowerUp>();

            if (collision.gameObject.tag == "Mentos")
            {
                if (powerUp.mentosColor == "blue")
                    Boost(2.5f);
                else if (powerUp.mentosColor == "red")
                    Invincible();
            }
            else if (collision.gameObject.tag == "3Mentos")
            {
                GameManager.Instance.VibratePhone(25);
                OnPlayerPickedMentos(3, powerUp.mentosColor);
            }
        }


        if (collision.gameObject.layer == 10) // Obstacle Layer
        {
            if (collision.gameObject.tag == "Airplane")
                HitEnemy();
            else if (collision.gameObject.tag == "Bird")
                HitEnemy();
            else if (collision.gameObject.tag == "Hand")
                HitEnemy(); //fazer a lata ser pega pela mão (comportamento específico da mão)

        }
    }
}
