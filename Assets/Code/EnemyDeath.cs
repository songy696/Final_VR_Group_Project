using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animation;
    // public AudioSource audio;

    private bool isDead;
    private bool isHurt;

    public int enemyLife;

    private void Start() 
    {
        isDead = false;
        animation = GetComponent<Animator>();
        // audio = GetComponent<AudioSource>();

        if(this.gameObject.CompareTag("Boss"))
        {
            enemyLife = 5;
        }

        if(this.gameObject.CompareTag("Enemy"))
        {
            enemyLife = 2;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(!isDead && other.gameObject.tag == "Bullet")
        {
            StartCoroutine(hurt());
        }
        
        if(enemyLife < 1)
        {
            dead();
        }
    }

    IEnumerator hurt()
    {
        animation.SetTrigger("isHurt");
        isHurt = true;
        enemyLife--;
        
        yield return new WaitForSeconds(2f);

        isHurt = false;
    }

    void dead()
    {
        isDead = true;
        animation.SetTrigger("isDead");
    }
}
