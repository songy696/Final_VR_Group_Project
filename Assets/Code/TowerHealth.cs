using System.Collections;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    GameManager gm;

    bool cooldown = false;

    void Start() 
    {
        gm = FindObjectOfType<GameManager>();  
    }

    public void ApplyDamageTower(int damage)
    {
        gm.TakeDamage(damage);
        //StartCoroutine("GiveBreak");
    }

    IEnumerator GiveBreak()
    {
        cooldown = true;

        yield return new WaitForSeconds(1f);

        cooldown = false;
    }
}
