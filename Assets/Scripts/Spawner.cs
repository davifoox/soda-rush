using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; // alterar para Enemy quando criar o script dele
    [SerializeField] MentosBehaviour mentos;
    [SerializeField] Player player;
    private float offset = 15f;

    private bool startedSpawning = false;

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(this.transform.position.x, player.transform.position.y + offset);
        if(transform.position.y >= 5 && startedSpawning == false)
        {
            StartCoroutine("SpawnerTimer");
            startedSpawning = true;
        }
    }

    IEnumerator SpawnerTimer()
    {
        float randomXPos = Random.Range(-3, 3);
        float randomNumber = Random.Range(0, 4);

        if (randomNumber < 2)   SpawnPowerUp();
        else                    SpawnObstacle(randomXPos);

        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnerTimer");
    }

    void SpawnPowerUp()
    {
        float randomPos;
        int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
            randomPos = -1.5f;
        else if (randomNumber == 2)
            randomPos = 1.5f;
        else
            randomPos = 0f;

        Instantiate(mentos, new Vector3(randomPos, transform.position.y, 0), Quaternion.identity);
    }

    void SpawnObstacle(float xPos)
    {
        if (xPos > 0)
        {
            xPos = 1.6f;
            var newEnemy = Instantiate(enemy, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        }
        else 
        { 
            xPos = -1.6f;
            var newEnemy = Instantiate(enemy, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
            newEnemy.transform.localScale = new Vector2(newEnemy.transform.localScale.x * -1, newEnemy.transform.localScale.y);
        }

    }
}
