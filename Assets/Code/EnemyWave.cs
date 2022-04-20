using System.Collections;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject enemyOne;
    // public GameObject enemyTwo;
    // public GameObject enemyThree;

    public int enemySpawnCount1;
    // public int enemySpawnCount2;
    // public int enemySpawnCount3;

    void Start() 
    {
        StartCoroutine(spawnEnemy1(enemyOne));
    }

    IEnumerator spawnEnemy1(GameObject enemy)
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < enemySpawnCount1; i++)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 5f), 1.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
        }
    }

    // IEnumerator spawnEnemy2(GameObject enemy)
    // {
    //     yield return new WaitForSeconds(1f);

    //     for(int i = 0; i < enemySpawnCount2; i++)
    //     {
    //         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 5f), 15, 0), Quaternion.identity);
    //         yield return new WaitForSeconds(.5f);
    //     }
    // }

    // IEnumerator spawnEnemy3(GameObject enemy)
    // {
    //     yield return new WaitForSeconds(1f);

    //     for(int i = 0; i < enemySpawnCount3; i++)
    //     {
    //         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 5f), 15, 0), Quaternion.identity);
    //         yield return new WaitForSeconds(.5f);
    //     }
    // }
}
