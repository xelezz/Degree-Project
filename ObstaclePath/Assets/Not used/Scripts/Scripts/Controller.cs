using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector2 inputVec;
    private Vector3 movement;

    [SerializeField]
    private float walkSpeed;
    [SerializeField] 
    private GameObject camera;
    void Update()
    {
        inputVec = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        movement = camera.transform.TransformDirection(inputVec.x, 0, inputVec.y);
        movement.y = 0;
        movement = movement.magnitude == 0 ? Vector3.zero : movement / movement.magnitude;
        movement *= Time.deltaTime * walkSpeed;
        this.transform.Translate(movement);
    }
}
