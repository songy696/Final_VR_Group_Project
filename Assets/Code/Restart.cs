using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetButtonDown("0")) {
                SceneManager.LoadScene("Game2");
            }
    }
}
