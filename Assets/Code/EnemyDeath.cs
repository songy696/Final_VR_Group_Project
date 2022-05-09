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
            Dead();
        }
    }

    IEnumerator hurt()
    {
        isHurt = true;
        enemyLife --;
        animation.SetBool("isHurt", true);

        yield return new WaitForSeconds(3f);

        isHurt = false;
    }

    void Dead()
    {
        isDead = true;
        animation.SetBool("isDead", true);
    }
}
