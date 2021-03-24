using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VrController : MonoBehaviour
{
    private List<InputDevice> rightHandDevices = new List<InputDevice>();

    private List<InputDevice> leftHandDevices = new List<InputDevice>();


    private void Update()
    {
        InputDevices.GetDevicesWithRole(InputDeviceRole.LeftHanded, leftHandDevices);
        InputDevices.GetDevicesWithRole(InputDeviceRole.RightHanded, rightHandDevices);
        Debug.Log("total devices connected: " + leftHandDevices.Count);
        Debug.Log("total devices connected: " + rightHandDevices.Count);

        if (leftHandDevices.Count >= 1)
        {
            if(leftHandDevices[0].TryGetFeatureValue(CommonUsages.trigger, out float swichWeapon))
            {
                Input.GetAxis("Oculus_LeftHandTrigger");
            }

        }
    }
}
