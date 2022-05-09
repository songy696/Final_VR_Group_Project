using System.Collections;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject bossObj;

    public int enemySpawnBase = 3;
    public int enemySpawnAdd = 0;

    public Transform spawnPoint;

    void Start() 
    {
       StartCoroutine(spawnEnemy(enemyObj));
       InvokeRepeating("EnemyCheck", 5, 5);
    }

    void EnemyCheck()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //print(enemiesLeft);
        if (enemiesLeft < 2)
        {
            StartCoroutine(spawnEnemy(enemyObj));
        } else if (enemiesLeft <1)
        {
            StartCoroutine(spawnEnemy(bossObj));
        }
    }

    IEnumerator spawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < enemySpawnBase + enemySpawnAdd; i++)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(spawnPoint.position.x - 5f, spawnPoint.position.x + 5f), 
                                                     spawnPoint.position.y, 
                                                     spawnPoint.position.z), Quaternion.identity);

            yield return new WaitForSeconds(.5f);
        }

    }

}
