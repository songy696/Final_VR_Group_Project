using System.Collections;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed;

    Animator enemyAnimation;
    public GameObject explosion;

    // private bool isMoving;
    // private bool isAttacking;

    void Start() 
    {
        enemyAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Tower")
        {
            Attack();
        }
    }
    
    void Update() 
    {
        Movement();
    }

    void Movement()
    {
        // isAttacking = false;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        enemyAnimation.SetBool("isMoving", true);
    }

    void Attack()
    {
        // isMoving = false;
        // isAttacking = true;
        speed = 0;
        enemyAnimation.SetBool("isAttack", true);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
