using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnRange = 10; 
    
    private EnemyController spawnedEnemyController;
    
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {

        Vector3 spawnPoint =
            new Vector3(Random.Range(transform.position.x - SpawnRange, transform.position.x + SpawnRange),
                transform.position.y, transform.position.z);
        
        GameObject enemy = Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
        enemy.GetComponent<EnemyController>().EnemyDeath.AddListener(SpawnEnemy);
    }
}
