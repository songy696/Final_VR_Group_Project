using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public Volume volume;
    public Vignette vignette;
    int towerInGame = 1;
    
    public int[] towerHealth;
    public RectTransform[] healthBars;
    bool hurt = false;

    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);

        towerHealth = new int[towerInGame];
        for (int i = 0; i < towerHealth.Length; i++)
        {
            towerHealth[i] = 100;
        }
    }

    private void Update()
    {
        if (hurt == true)
        {
            StartCoroutine(HurtEffect());
        }
    }

    public bool UpdateHealth(int hitTower, int damage)
    {
        towerHealth[hitTower] -= damage;
        hurt = true;
        healthBars[hitTower].localScale = new Vector3(towerHealth[hitTower] * .01f, 1, 1);
        
        if (towerHealth[hitTower] > 0)
        {
            return true;
        }
        else
        {
            towerHealth[hitTower] = 0;
            towerInGame--;
            CheckRoundOver();
            return false;
        }
    }

    IEnumerator HurtEffect() {
        vignette.intensity.value = 0.18f;
        yield return new WaitForSeconds(0.5f);
        vignette.intensity.value = 0f;
    }


    void CheckRoundOver()
    {
        if (towerInGame < 1)
        {
            SceneManager.LoadScene("DeadScene");
        }
    }
}
