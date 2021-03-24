using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR;
public class PickupHand : MonoBehaviour
{
    public float distToPickup = 0.3f;
    private bool handClosed = false;
    public XRNode xrNode = XRNode.LeftHand;

    private void FixedUpdate()
    {
        
    }
}
