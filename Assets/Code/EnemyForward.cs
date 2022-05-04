using System.Collections;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed;
    public int enemyLife;

    Animator enemyAnimation;

    private bool isMoving;
    private bool isAttacking;

    void Start() 
    {
        enemyAnimation = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other) 
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
        isAttacking = false;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        enemyAnimation.SetBool("isMoving", true);
    }

    void Attack()
    {
        isMoving = false;
        isAttacking = true;
        speed = 0;
        enemyAnimation.SetBool("isAttack", true);
    }
}
