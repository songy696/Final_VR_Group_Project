using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animation;
    // public GameObject deathExplosion; //use enemy_death_skull
    // public GameObject hurtExplosion; //use hit-misc-b

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
        // Instantiate(hurtExplosion, transform.position, Quaternion.identity);
        isHurt = true;
        enemyLife--;
        
        yield return new WaitForSeconds(2f);

        isHurt = false;
    }

    void dead()
    {
        isDead = true;
        animation.SetTrigger("isDead");
        // Instantiate(deathExplosion, transform.position, Quaternion.identity);
        // Destroy(gameObject);
    }
}
