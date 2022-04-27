using System.Collections;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed;
    public int enemyLife;
    Animator enemyAnimation;

    private bool isMoving;

    void Start() 
    {
        enemyAnimation = GetComponent<Animator>();
    }
    
    void Update() 
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        enemyAnimation.SetBool("isMoving", true);
    }

    // void StopMovement()
    // {

    // }
}
