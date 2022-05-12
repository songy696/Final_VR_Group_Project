using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TowerHealth : MonoBehaviour
{
    GameManager gm;

    bool alive = true;
    bool hurt = false;

    public Volume volume;
    public Vignette vignette;

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
                gm.TakeDamage(10);
                StartCoroutine(HurtEffect());
                if (alive){
                    StartCoroutine(GotHurt());
                }else{
                    StartCoroutine(Dead());
                }
            }
        }

        if (alive && !hurt){
            if(other.tag == "Boss"){
                gm.TakeDamage(30);
                StartCoroutine(HurtEffect());
                if (alive){
                    StartCoroutine(GotHurt());
                }else{
                    StartCoroutine(Dead());
                }
            }
        }
    }

    IEnumerator GotHurt()
    {
        hurt = true;

        yield return new WaitForSeconds(1f);

        hurt = false;
    }

    IEnumerator Dead()
    {
        alive = false;

        yield return new WaitForSeconds(.5f);
    }

    IEnumerator HurtEffect()
    {
        vignette.intensity.value = 0.18f;
        yield return new WaitForSeconds(0.5f);
        vignette.intensity.value = 0f;
    }
}
