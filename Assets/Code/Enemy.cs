using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    float random;
    float randomSpeed;
    private float startPosition;

    private void Start() 
    {
        enemyRb = GetComponent<Rigidbody>();
        random = Random.Range(3f, 5f);
        randomSpeed = Random.Range(.2f, .5f);
        startPosition = transform.position.x;
    }

    void Update() 
    {
        Movement();

        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        // transform.position = new Vector3(Mathf.PingPong(Time.time, random) * randomSpeed, transform.position.y, transform.position.z);
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(startPosition, startPosition + random, Mathf.PingPong(Time.time * randomSpeed, 1));
        transform.position = newPosition;
    }
}
