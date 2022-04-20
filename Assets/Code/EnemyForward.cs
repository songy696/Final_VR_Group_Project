using System.Collections;
using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public float speed = 3;
    
    private void Update() 
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
