using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;

    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        device = devices.FirstOrDefault();
    }

    private void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        List<InputFeatureUsage> features = new List<InputFeatureUsage>();

        foreach (var feature in features)
        {
            
            
                Debug.Log($"Feature {feature.name} type {feature.type}");

            
        }

    }

}
