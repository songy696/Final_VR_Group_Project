using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Animator _animation;

    public float speed;
    public int life;

    private bool isMoving = true;
    private bool isAttacking = false;
    private bool isHurt = false;
    private bool isDead = false;

    void Start() 
    {
        _animation = GetComponent<Animator>();
        SetStats();
    }

    void Update() 
    {
        if(isMoving)
        {   
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _animation.SetBool("isMoving", true);
        } 
        else if(isAttacking)
        {
            _animation.SetBool("isAttack", true);
             StartCoroutine("DamageTaken", 2f);
        }
    }

    void SetStats()
    {
         if(this.gameObject.CompareTag("Boss"))
        {
            life = 5;
            speed = .5f;
        }

        if(this.gameObject.CompareTag("Enemy"))
        {
            life = 2;
            speed = 1f;
        }
    }


    IEnumerator DamageTaken()
    {
        isHurt = true;
        _animation.SetBool("isHurt", true);
        life--;
        if(life == 0)
        {
            _animation.SetBool("isDead", true);
            isDead = true;
            StartCoroutine("CleanEnemy");
        } else {
            yield return new WaitForSeconds(1f);
            isHurt = false;
        }
    }

    IEnumerator CleanEnemy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    //should this be a trigget or collider?
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Tower")
        {
            speed = 0;
            isMoving = false;
            isAttacking = true;
        }
    }
    
    //should this be a trigget or collider?
    private void OnCollisionEnter(Collision other) 
    {
        if(!isDead && !isHurt && other.gameObject.CompareTag("Bullet"))
        {
            isAttacking = false;
            StartCoroutine("DamageTaken");
        }
    }

}
