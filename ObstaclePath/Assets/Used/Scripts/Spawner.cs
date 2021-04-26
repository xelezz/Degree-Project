using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private Transform[] spawnPoints;
    
    private float timer;
    public float spawnTimer;
    public float velocity = 2;
    public float destroyTime = 2;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomPrefab = obstacles[Random.Range(0, obstacles.Length)];

            GameObject spawnPrefab = Instantiate(randomPrefab, randomPoint.position, randomPoint.rotation);

            timer -= spawnTimer;

            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
            rb.velocity = randomPoint.forward * velocity;
            Destroy(spawnPrefab, destroyTime);
            Debug.Log(destroyTime);
        }
    }
}
