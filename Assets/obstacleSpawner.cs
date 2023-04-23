using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public float start_delay_seconds = 0f;
    public float spawn_rate_seconds = 2.0f;
    public GameObject[] obstacle_prefabs;
    gameManager gm;

    int obstacle_index;
    public void BeginSpawning()
    {
        InvokeRepeating("SpawnObstacle", start_delay_seconds, spawn_rate_seconds);
    }

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        //InvokeRepeating("SpawnObstacle", start_delay_seconds, spawn_rate_seconds);
        Invoke("SpawnObstacle", start_delay_seconds);
    }
    void SpawnObstacle()
    {
        obstacle_index = Random.Range(0, obstacle_prefabs.Length);
        Instantiate(obstacle_prefabs[obstacle_index], transform.position, Quaternion.identity);

        if (!gm.game_over)
        {
            Invoke("SpawnObstacle", spawn_rate_seconds);
        }
    }
}
