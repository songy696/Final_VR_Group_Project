using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator animation;

    private bool isDead;

    private void Start() 
    {
        isDead = false;
        animation = GetComponent<Animator>();
    }

     private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Bullet")
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        isDead = true;
        animation.SetBool("isDead", true);

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
