using System.Collections;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed;
    public int enemyLife;

    Animator enemyAnimation;
    Rigidbody rb;

    private bool isMoving;
    private bool isAttacking;

    void Start() 
    {
        enemyAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        Attack(other.gameObject);
    }
    
    void Update() 
    {
        Movement();
    }

    void Movement()
    {
        isAttacking = false;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        enemyAnimation.SetBool("isMoving", true);
    }

    void Attack(GameObject other)
    {
        if(other.tag == "Tower")
        {
            isMoving = false;
            speed = 0;
            enemyAnimation.SetBool("isAttack", true);
        }
    }
}
