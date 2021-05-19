using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; // alterar para Enemy quando criar o script dele
    [SerializeField] MentosBehaviour mentos;
    [SerializeField] PlayerBehaviour player;
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
        float randomNumber = Random.Range(0, 3);

        if (randomNumber < 2)   SpawnPowerUp(0f);
        else                    SpawnObstacle(randomXPos);

        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnerTimer");
    }

    void SpawnPowerUp(float xPos)
    {
        Instantiate(mentos, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
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
