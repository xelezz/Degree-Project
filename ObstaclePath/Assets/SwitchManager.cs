using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class SwitchManager : MonoBehaviour
{
    public bool sword;    // 
    public bool saber;    // 
    //public bool other;    // 

    public GameObject choice1;  // 
    public GameObject choice2;  // 
    //public GameObject choice3;  // 

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

        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        choice1 = FindObjectOfType<GameObject>();  // gets access to the p1 game object
        choice2 = FindObjectOfType<GameObject>();  // gets access to the p2 game object

        if (sword = true)
        {
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(false);
            //choice3.gameObject.SetActive(false);
            saber = false;
            //other = false;
        }

        if (saber = true)
        {
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(true);
            //choice3.gameObject.SetActive(false);
            sword = false;
            //other = false;
        }

    }

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue);
        if (gripButtonValue)
        {
            sword = true;
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(false);
            saber = false;
            Debug.Log("yea");
        }

        if (!gripButtonValue)
        {
            saber = true;
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(true);
            sword = false;
        }

    }
}



