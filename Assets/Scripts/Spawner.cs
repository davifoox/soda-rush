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
        SpawnPowerUp(0f);
        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnerTimer");
    }

    void SpawnPowerUp(float xPos)
    {
        Instantiate(mentos, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }

    void SpawnObstacle(float xPos)
    {
        Instantiate(enemy, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }
}
