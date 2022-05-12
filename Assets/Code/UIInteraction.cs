using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    public XRNode handRole = XRNode.RightHand;

    bool triggerState = false;

    public Button startButton;

    void Update() 
    {
        InputDevices.GetDeviceAtXRNode(handRole).TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger);

            if(trigger && !triggerState)
            {
                startButton.onClick.Invoke();
            }

        triggerState = trigger;
    }
}
