using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
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
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);

        //towerHealth = new int[towerInGame];
        //for (int i = 0; i < towerHealth.Length; i++)
        //{
        //   towerHealth[i] = 100;
        //}
    }


    public void TakeDamage(int damage)
    {
        StartCoroutine(HurtEffect());
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
        SceneManager.LoadScene("GameOverScene");
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

    */

    IEnumerator HurtEffect() {
        m_Vignette.intensity.value = 0.3f;
        yield return new WaitForSeconds(0.5f);
        m_Vignette.intensity.value = 0;
    } 

}