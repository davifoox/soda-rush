using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle handObstacle;
    [SerializeField] Obstacle airplane;
    [SerializeField] Obstacle bird;
    [SerializeField] PowerUp mentos;
    [SerializeField] PowerUp threeMentos;
    [SerializeField] Player player;
    private float offset = 15f;

    private float spawnPostion;

    private void Start()
    {
        spawnPostion = transform.position.y + 5f;
    }

    int GetRandomIntBetween(int first, int last)
    {
        int number = Random.Range(first, last +1);
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
        float randomNumber = Random.Range(0, 6);

        if (randomNumber < 1)   SpawnPowerUp();
        else                    SpawnObstacle();
    }

    //Quando instanciar (tanto power up quanto obstacle) setar a variável player (da instância) como this.player 
    //(para cada objeto spawnado checar a posição do player e saber se deve ser destruído)

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
        int randomMentosType = GetRandomIntBetween(1, 6);
        PowerUp currentMentos;
        if(randomMentosType < 5)
            currentMentos = Instantiate(mentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);
        else
            currentMentos = Instantiate(threeMentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);

        // set power up's player variable
        currentMentos.player = this.player.transform;
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
                xPos = 6f;
            newObstacle = Instantiate(airplane, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        }

        newObstacle.player = this.player.transform;
    }
}
