using System.Collections;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject enemyOne;
    // public GameObject enemyTwo;
    // public GameObject enemyThree;

    public int enemySpawnCount;
    public int enemySpawnCount2;
    public int enemySpawnCount3;

    public Transform spawnPoint;
    //public Transform spawnPointLeft;
    //public Transform spawnPointRight;

    public int waveNum;

    void Start() 
    {
        StartCoroutine(spawnEnemy1(enemyOne));
        InvokeRepeating("EnemyCheck", 1, 5);
        waveNum = 1;
    }

    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //print(enemiesLeft);
        if (waveNum == 1 && enemiesLeft < 1)
        {
            StartCoroutine(spawnEnemy2(enemyOne));
            waveNum = 2;
        }
        else if (waveNum == 2 && enemiesLeft < 2)
        {
            StartCoroutine(spawnEnemy3(enemyOne));
            waveNum = 1;
        }
    }

    IEnumerator spawnEnemy1(GameObject enemy)
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < enemySpawnCount; i++)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(spawnPoint.position.x - 5f, spawnPoint.position.x + 5f), 
                                                     spawnPoint.position.y, 
                                                     spawnPoint.position.z), Quaternion.identity);

            yield return new WaitForSeconds(.5f);
        }
    }

     IEnumerator spawnEnemy2(GameObject enemy)
     {
        yield return new WaitForSeconds(1f);

         for(int i = 0; i < enemySpawnCount2; i++)
         {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(spawnPoint.position.x - 5f, spawnPoint.position.x + 5f),
                                                    spawnPoint.position.y,
                                                    spawnPoint.position.z), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
         }
     }

     IEnumerator spawnEnemy3(GameObject enemy)
     {
         yield return new WaitForSeconds(1f);

         for(int i = 0; i < enemySpawnCount3; i++)
         {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(spawnPoint.position.x - 5f, spawnPoint.position.x + 5f),
                                                    spawnPoint.position.y,
                                                    spawnPoint.position.z), Quaternion.identity);
            yield return new WaitForSeconds(.5f);
         }
     }
}
