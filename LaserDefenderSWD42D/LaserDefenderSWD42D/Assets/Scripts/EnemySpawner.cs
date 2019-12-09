using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int maximumNumberOfEnemies = 10;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] GameObject firstSpawnPoint; //the type for prefabs is GameObject

    int currentNumberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    /*
     * Coroutines are special methods used to suspend/pause a method execution. During the pause, the process responsible
     * for the method, won't stop instead it will go back and continue with other functionalities. The functionality will
     * resume once either the amount of time is up or a condition has been met. The functionality will resume where it
     * left off and the function won't start from the beginning.
     */

    IEnumerator SpawnEnemies()
    {
        while (currentNumberOfEnemies < maximumNumberOfEnemies)
        {
            GameObject enemyClone = Instantiate(enemyPrefab, firstSpawnPoint.transform.position, Quaternion.identity);

            // since we don't need any rotation for the enemy clone, we're using Quaternion.identity (no identity)

            currentNumberOfEnemies++;

            yield return new WaitForSeconds(spawnTime);

            /*
             * The yield keyword is used for Coroutines to indicate where the execution should continue once either
             * the amount of time is up or once the condition has been met.
             */

        }
    }
}
