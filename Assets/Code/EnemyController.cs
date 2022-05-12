using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Animator _animation;

    public GameObject explosion;

    TowerHealth _towerHealth;

    public int life;
    private int damage;
    private float speed;
    private float CURRENT_SPEED;

    private bool isMoving = true;
    private bool isAttacking = false;
    private bool isHurt = false;
    private bool isDead = false;


    void Start() 
    {
        _towerHealth = FindObjectOfType<TowerHealth>();  
        _animation = GetComponent<Animator>();

        SetStats();
    }

    void Update() 
    {
        if (isHurt) {return;}

        if(isMoving)
        {   
            transform.Translate(Vector3.forward * CURRENT_SPEED * Time.deltaTime);
            _animation.SetBool("isMoving", true);
        } 
        else if(isAttacking)
        {
            StartCoroutine("AttackingTower");
        }
    }

    void SetStats()
    {
         if(this.gameObject.CompareTag("Boss"))
        {
            life = 5;
            damage = 25;
            speed = 1f;
            CURRENT_SPEED = speed;
        }

        if(this.gameObject.CompareTag("Enemy"))
        {
            life = 2;
            damage = 3;
            speed = 2f;
            CURRENT_SPEED = speed;
        }
    }

    IEnumerator AttackingTower()
    {
        isAttacking = false;
        _animation.SetBool("isAttack", true);

         if(this.gameObject.CompareTag("Enemy"))
         {
            yield return new WaitForSeconds(1.10f);
            _towerHealth.ApplyDamageTower(damage);
         }

         if(this.gameObject.CompareTag("Boss"))
        {  
            _towerHealth.ApplyDamageTower(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }

      isAttacking = true;

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
            CURRENT_SPEED = speed;
        }
    }

    IEnumerator CleanEnemy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    //should this be a trigget or collider?
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Tower")
        {
            CURRENT_SPEED = 0;
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
            isMoving = false;
            CURRENT_SPEED = 0;
            StartCoroutine("DamageTaken");
        }
    }

}
