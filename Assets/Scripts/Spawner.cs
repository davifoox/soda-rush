using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle handObstacle;
    [SerializeField] Obstacle airplane;
    [SerializeField] PowerUp mentos;
    [SerializeField] PowerUp threeMentos;
    [SerializeField] Player player;
    private float offset = 15f;

    private float spawnPostion;

    private void Start()
    {
        spawnPostion = transform.position.y + 5f;
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
        int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
            randomPos = -1.5f;
        else if (randomNumber == 2)
            randomPos = 1.5f;
        else
            randomPos = 0f;

        //randomize type
        int randomMentosType = Random.Range(0, 6);
        PowerUp currentMentos;
        if(randomMentosType < 4)
            currentMentos = Instantiate(mentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);
        else
            currentMentos = Instantiate(threeMentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);

        // set power up's player variable
        currentMentos.player = this.player.transform;
    }

    void SpawnObstacle()
    {
        int randomObstacleType = Random.Range(0,10);
        Obstacle newObstacle;
        if(randomObstacleType < 7) //hand
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
        else //airplane
        {
            float xPos = Random.Range(-4.5f, 4.5f);
            if (xPos < 0)
                xPos = -4.5f;
            else
                xPos = 4.5f;
            newObstacle = Instantiate(airplane, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        }

        newObstacle.player = this.player.transform;
    }
}
