using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    //public Volume volume;
    //public Vignette vignette;
    int towerInGame = 1;
    
    public int[] towerHealth;
    public RectTransform[] healthBars;

    public Image fill;

    public Slider slider;
    public Gradient gradient;

    public int currentHP;
    public int MaxHP = 100;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start()
    {
        currentHP = MaxHP;
        SetMaxHealth(MaxHP);
        //volume = GetComponent<Volume>();
        //volume.profile.TryGet(out vignette);

        //towerHealth = new int[towerInGame];
        //for (int i = 0; i < towerHealth.Length; i++)
        //{
         //   towerHealth[i] = 100;
        //}
    }


    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        SetHealth(currentHP);

        if(currentHP <= 0)
        {
            currentHP = 0;
            StartCoroutine(CheckRoundOver());
        }
    }
    IEnumerator CheckRoundOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DeadScene");
    }
    /*
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
    /*
        IEnumerator HurtEffect() {
            vignette.intensity.value = 0.18f;
            yield return new WaitForSeconds(0.5f);
            vignette.intensity.value = 0f;
        }

            */

}
