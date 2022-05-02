using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int towerInGame = 1;
    
    int[] towerHealth;
    public RectTransform[] healthBars;

    void Start()
    {
        towerHealth = new int[towerInGame];
        for (int i = 0; i < towerHealth.Length; i++)
        {
            towerHealth[i] = 200;
        }
    }

    public bool UpdateHealth(int hitTower, int damage)
    {
        towerHealth[hitTower] -= damage;
        healthBars[hitTower].localScale = new Vector3(towerHealth[hitTower] * .01f, 1, 1);
        
        if (towerHealth[hitTower] > 0)
        {
            return true;
        }
        else
        {
            towerHealth[hitTower] = 0;
            towerInGame--;
            // CheckRoundOver();
            return false;
        }
    }

    // void CheckRoundOver()
    // {
    //     if (towerInGame < 1)
    //     {
    //         SceneManager.LoadScene(DeadScene);
    //     }
    // }
}
