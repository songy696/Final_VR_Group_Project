using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Advance : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetButtonDown("Button.One")) {
                SceneManager.LoadScene("Game2");
            }
    }
}
