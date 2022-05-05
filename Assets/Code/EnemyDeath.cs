using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator animation;

    private bool isDead;
    private bool isHurt;

    public int enemyLife;

    private void Start() 
    {
        isDead = false;
        animation = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(!isDead && other.gameObject.tag == "Bullet")
        {
            StartCoroutine(hurt());
        } else if (enemyLife < 1)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator hurt()
    {
        isHurt = true;
        enemyLife --;
        animation.SetBool("isHurt", true);

        yield return new WaitForSeconds(.25f);

        isHurt = false;
    }

    IEnumerator Dead()
    {
        isDead = true;
        animation.SetBool("isDead", true);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
