using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    GameManager gm;

    bool alive = true;
    bool hurt = false;

    public int playerNum = 1;

    private void OnCollisionEnter(Collision other) {
        TowerHit(other.gameObject);
    }

    void TowerHit(GameObject other)
    {
        if (alive && !hurt){
            if(other.CompareTag("Enemy")){
                alive = gm.UpdateHealth(playerNum, 10);
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
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
