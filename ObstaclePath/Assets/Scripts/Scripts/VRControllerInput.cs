using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    private InputDevice targetDevice;
    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
        
        //Shows all devices
        //InputDevices.GetDevices(devices);
        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }

        //if (devices.Count > 0)
        //{
        //    targetDevice = 
        //}
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }


    }

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
            Debug.Log("Pressing primary button(X)");

        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue);
        if (gripButtonValue)
            Debug.Log("Pressing grip button(GRIP)");

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
            Debug.Log("Pressing secondary button(Y)");

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouchValue);
        if (secondaryTouchValue)
            Debug.Log("Touching secondary touch button(Y,B)");

        targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouchValue);
        if (primaryTouchValue)
            Debug.Log("Touching primary touch button(X,A)");

        targetDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue);
        if (menuButtonValue)
            Debug.Log("Pressing menu button(MENUBUTTON)");

        targetDevice.TryGetFeatureValue(CommonUsages.secondary2DAxisClick, out bool secondary2DAxisClick);
        if (menuButtonValue)
            Debug.Log("Pressing secondary2DAxisClick");


    }
}



