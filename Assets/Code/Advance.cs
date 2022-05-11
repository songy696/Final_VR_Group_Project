using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Advance : MonoBehaviour
{
    private OVRGrabbable ovrGrabbable; 
    public OVRInput.Button ovrRInput;

    private void Start() 
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    private void Update() 
    {
        if(OVRInput.GetDown(ovrRInput, ovrGrabbable.grabbedBy.GetController())) {
                SceneManager.LoadScene("Game2");
            }

             if(OVRInput.GetDown(ovrRInput, ovrGrabbable.grabbedBy.GetController())) {
                SceneManager.LoadScene("Game2");
            }
    }
}
