using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    private InputDevices targetDevice;


    public XRNode handRole = XRNode.LeftHand;

    private void Start() 
    {
        // List<InputDevices> devices = new List<InputDevices>();
        // InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.RightHand | InputDeviceCharacteristics.Controller;
        // InputDevices.GetDeviceWithCharacteristics(rightControllerCharacteristics, devices);

        // foreach (var item in devices)
        // {
        //     Debug.Log(item.name + item.characteristics);
        // }

        // if(device.Count > 0)
        // {
        //     targetDevice = device[0];
        // }

    }

    private void Update() 
    {
        //targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        //targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        
        InputDevices.GetDeviceAtXRNode(handRole).TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if(primaryButtonValue)
        {
            SceneManager.LoadScene("Game2");
        }
        
    }

     public void StartButton()
    {
        SceneManager.LoadScene("Game2");
    }



}
