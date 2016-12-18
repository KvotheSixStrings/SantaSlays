using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public int maxSpawn = 8;
    public int spawnCount = 2;
    
    public float spawnInterval = 2;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    private List<GameObject> spawnedShootingEnemies = new List<GameObject>();
    private List<GameObject> spawnedMeleeEnemies = new List<GameObject>();

    void OnEnable()
    {
      
       StartCoroutine("SpawnCoroutine");
             
    }

    void OnDisable()
    {
        StopCoroutine("SpawnCoroutine");
    }      

    IEnumerator SpawnCoroutine()
    {
        for(int i = 0; i < int.MaxValue; i++)
        {
            for(int j = 0; j < maxSpawn; j++)
            {
                int rng = Random.Range(0, 2);
                if(rng == 0)
                {
                    Spawn(1);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawn(int num)
    {
        List<GameObject> shootingEnemies = spawnedShootingEnemies.FindAll(IsInactiveShootingEnemy);
        List<GameObject> meleeEnemies = spawnedMeleeEnemies.FindAll(IsInactiveMeleeEnemy);
        for (int i = 0; i < num; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnloc = Random.Range(0, spawnPoints.Length);
            GameObject enemy = null;
            if(enemyIndex == 0)
            {
                if (i >= shootingEnemies.Count)
                {
                    enemy = Object.Instantiate(enemyPrefabs[enemyIndex]) as GameObject;
                    enemy.transform.parent = transform;
                    spawnedShootingEnemies.Add(enemy);
                }
                else
                {
                    enemy = shootingEnemies[i];
                    enemy.SetActive(true);
                }
            }
            else if(enemyIndex == 1)
            {
                if (i >= meleeEnemies.Count)
                {
                    enemy = Object.Instantiate(enemyPrefabs[enemyIndex]) as GameObject;
                    enemy.transform.parent = transform;
                    spawnedMeleeEnemies.Add(enemy);
                }
                else
                {
                    enemy = meleeEnemies[i];
                    enemy.SetActive(true);
                }
            }
            enemy.transform.position = spawnPoints[spawnloc].position;

        }
    }

    bool IsActiveShootingEnemy(GameObject enemy)
    {
        return enemy.activeSelf;
    }

    bool IsInactiveShootingEnemy(GameObject enemy)
    {
        return !enemy.activeSelf;
    }

    bool IsActiveMeleeEnemy(GameObject enemy)
    {
        return enemy.activeSelf;
    }

    bool IsInactiveMeleeEnemy(GameObject enemy)
    {
        return !enemy.activeSelf;
    }
    
}
