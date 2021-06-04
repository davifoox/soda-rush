using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Hand handObstacle;
    [SerializeField] Obstacle airplane;
    [SerializeField] Obstacle bird;
    [SerializeField] PowerUp mentos;
    [SerializeField] PowerUp redMentos;
    [SerializeField] PowerUp threeMentos;
    [SerializeField] Player player;
    private float offset = 15f;
    private float spawnPostion;

    private int timeSinceSpawnedPowerUp = 0;

    private void Start()
    {
        spawnPostion = transform.position.y + 40f;
    }

    int GetRandomIntBetween(int first, int last)
    {
        int number = Random.Range(first, last +1);
        //Debug.Log("random number: " + number);
        return number;
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x, player.transform.position.y + offset);
        if(transform.position.y >= spawnPostion)
        {
            Spawn();
            spawnPostion = spawnPostion + 10f;
        }
    }

    void Spawn()
    {
        timeSinceSpawnedPowerUp++;
        int randomNumber = GetRandomIntBetween(1, 3);

        if(timeSinceSpawnedPowerUp >= 6)
        {
            SpawnPowerUp();
            timeSinceSpawnedPowerUp = 0;
        }
        else if (randomNumber != 1)
        {
            SpawnObstacle();
        }
        else if (timeSinceSpawnedPowerUp >= 4)
        {
            SpawnPowerUp();
            timeSinceSpawnedPowerUp = 0;
        }

        // de 4 a 6 vezes spawnando obstacles, spawnar um mentos
    }


    void SpawnPowerUp()
    {
        //randomize position
        float randomPos;
        int randomNumber = GetRandomIntBetween(1, 3);
        if (randomNumber == 1)
            randomPos = -1.5f;
        else if (randomNumber == 2)
            randomPos = 1.5f;
        else //if (randomNumber == 3)
            randomPos = 0f;


        //randomize type
        int randomMentosType = GetRandomIntBetween(1, 10);
        PowerUp currentMentos;
        if(randomMentosType < 5) //1 blue mentos
            currentMentos = Instantiate(mentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);
        else if (randomMentosType < 8) //1 red mentos
            currentMentos = Instantiate(redMentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);
        else //3 blue mentos
            currentMentos = Instantiate(threeMentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);


        // set power up's player variable
        currentMentos.player = this.player;
    }

    void SpawnObstacle()
    {
        int randomObstacleType = GetRandomIntBetween(1, 10);
        Obstacle newObstacle;
        if(randomObstacleType < 6) //hand
        {
            float xPos = Random.Range(-3, 3);

            if (xPos > 0)
            {
                xPos = 1.6f;
                newObstacle = Instantiate(handObstacle, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                xPos = -1.6f;
                newObstacle = Instantiate(handObstacle, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
                newObstacle.transform.localScale = new Vector2(newObstacle.transform.localScale.x * -1, newObstacle.transform.localScale.y);
            }
        }

        else if (randomObstacleType < 8) //bird
        {
            float xPos = Random.Range(-6f, 4f);
            if (xPos < 0)
                xPos = -4.5f;
            else
                xPos = 4.5f;
            newObstacle = Instantiate(bird, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        }

        else //airplane
        {
            float xPos = Random.Range(-4.5f, 4.5f);
            if (xPos < 0)
                xPos = -4.5f;
            else
                xPos = 7f;
            newObstacle = Instantiate(airplane, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        }

        newObstacle.Initialize(player);
    }
}
