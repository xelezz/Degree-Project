using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    private InputDevice lTargetDevice;
    private InputDevice rTargetDevice;
    [SerializeField]
    private XRNode xrNode;
    private bool lButtonPressed = false;
    private bool rButtonPressed = false;
    private int activeIndexL = 1;
    private int activeIndexR = 1;
    public bool isRight;
    private List<InputDevice> Rdevices = new List<InputDevice>();
    private List<InputDevice> Ldevices = new List<InputDevice>();
    private float timer = 1;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        //right input Device
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, Rdevices);
        //Left input device
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, Ldevices);

        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }
        weapons[0].SetActive(false);
        weapons[1].SetActive(true);
        activeIndexL = 0;
        activeIndexR = 0;

        ControllerSpawn();

    }
    private void Update()
    {
        SwitchAvatar();
        
    }
    private void ControllerSpawn()
    {
      

        if (isRight)
        {
            if (Rdevices.Count > 0)
            {
                rTargetDevice = Rdevices[0];
            }
        }
        else
        {
            if (Ldevices.Count > 0)
            {
                lTargetDevice = Ldevices[0];
            }
        }
        }
    

    public void SwitchAvatar()
    {
        lTargetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool lGripButtonValue);
        
            if (lGripButtonValue && !lButtonPressed)
            {
            if (activeIndexL == 0)
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                activeIndexL = 1;
            }
            else if (activeIndexL == 1)
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                activeIndexL = 0;
            }
            Debug.Log("Pressing left grip button(GRIP)");
                lButtonPressed = true;
            }
            if (!lGripButtonValue)
            {
                lButtonPressed = false;
            }
        if (isRight)
        {

        rTargetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rGripButtonValue);

        if (rGripButtonValue && !rButtonPressed)
        {
            if (activeIndexR == 0)
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                activeIndexR = 1;
            }
            else if (activeIndexR == 1)
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                activeIndexR = 0;
            }
            Debug.Log("Pressing right grip button(GRIP)");
            rButtonPressed = true;
        }
        if (!rGripButtonValue)
        {
            rButtonPressed = false;
        }
        }

    }
}