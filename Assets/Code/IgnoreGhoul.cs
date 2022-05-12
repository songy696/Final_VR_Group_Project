using System.Collections;
using UnityEngine;

public class IgnoreGhoul : MonoBehaviour
{
    public GameObject ghoul;

    void Start() 
    {
        GameObject ghoul = GameObject.FindGameObjectWithTag("Enemy");
        Physics.IgnoreCollision(ghoul.GetComponent<Collider>(), GetComponent<Collider>());
    }

     private void OnCollisionEnter(Collision other) 
     {
         if(other.gameObject.CompareTag("Enemy"))
         {
            Physics.IgnoreCollision(ghoul.GetComponent<Collider>(), GetComponent<Collider>());
         }
     }
}
