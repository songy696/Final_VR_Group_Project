using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animation;

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
        }
        
        if(isDead && enemyLife < 1)
        {
            StartCoroutine(dead());
        }
    }

    IEnumerator hurt()
    {
        isHurt = true;
        enemyLife --;
        animation.Play("hurt");

        yield return new WaitForSeconds(2f);

        isHurt = false;
    }

    IEnumerator dead()
    {
        isDead = true;
        animation.Play("die");

        yield return new WaitForSeconds(1.1f);

        Destroy(gameObject);
    }
}
