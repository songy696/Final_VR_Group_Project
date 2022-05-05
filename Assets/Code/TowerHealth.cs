using System.Collections;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    GameManager gm;

    bool alive = true;
    bool hurt = false;

    public int playerNum = 1;

    void Start() 
    {
        gm = FindObjectOfType<GameManager>();  
    }

    private void OnTriggerEnter(Collider other) {
        TowerHit(other.gameObject);
    }

    void TowerHit(GameObject other)
    {
        if (alive && !hurt){
            if(other.tag == "Enemy"){
                alive = gm.UpdateHealth(playerNum - 1, 10);
                if(alive){
                    StartCoroutine(GotHurt());
                } else{
                    StartCoroutine(Dead());
                }
            }
        }
    }

    IEnumerator GotHurt()
    {
        hurt = true;

        yield return new WaitForSeconds(.5f);

        hurt = false;
    }

    IEnumerator Dead()
    {
        alive = false;

        yield return new WaitForSeconds(.5f);
    }
}
