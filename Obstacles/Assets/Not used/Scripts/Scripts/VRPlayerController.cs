using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class VRPlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private XRNode controllerNode = XRNode.RightHand;
    [SerializeField]
    private bool checkGroundJump;
    [Header ("Capsule Collision")]
    [Tooltip("adjusts the center of the capsule")]
    [SerializeField]
    private Vector3 capsuleCenter;
    [SerializeField]
    private float capsuleHeight;
    [SerializeField]
    private float capsuleRadius;

    public XRControllerState controllerState;

    private CapsuleDirection capsuleDirection = CapsuleDirection.YAxis;
    private InputDevice controller;

    private bool isGrounded;

    private bool buttonIsPressed;

    private Rigidbody rbComponent;

    private CapsuleCollider capsuleCollider;
    private List<InputDevice> devices = new List<InputDevice>();

    public enum CapsuleDirection
    {
        XAxis,
        YAxis,
        ZAxis
    }

    private void OnEnable()
    {
        rbComponent = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        rbComponent.constraints = RigidbodyConstraints.FreezeRotation;
        capsuleCollider.direction = (int)capsuleDirection;
        capsuleCollider.radius = capsuleRadius;
        capsuleCollider.center = capsuleCenter;
        capsuleCollider.height = capsuleHeight;
    }

    private void Start()
    {
        GetDevice();
    }

    public void UpdateTracking()
    {
        controllerState.poseDataFlags = UnityEngine.SpatialTracking.PoseDataFlags.NoData;
    }
    private void GetDevice()
    {
        //InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        //controller = devices.FirstOrDefault();
        if (controller.TryGetFeatureValue(CommonUsages.trackingState, out var trackingState))
        {
            if((trackingState & InputTrackingState.Position) != 0 && controller.TryGetFeatureValue(CommonUsages.devicePosition, out var devicePosition))
            {
                controllerState.position = devicePosition;
                controllerState.poseDataFlags |= UnityEngine.SpatialTracking.PoseDataFlags.Position;
                Debug.Log("ye");
            }
            if ((trackingState & InputTrackingState.Rotation) != 0 && controller.TryGetFeatureValue(CommonUsages.deviceRotation, out var deviceRotation))
            {
                controllerState.rotation = deviceRotation;
                controllerState.poseDataFlags |= UnityEngine.SpatialTracking.PoseDataFlags.Rotation;
                Debug.Log("ya");
            }
            Debug.Log("whoop");
        }
    }
    void Update()
    {
        if(controller == null)
        {
            GetDevice();
        }
        UpdateMovement();
        UpdateJump();
    }
    

    private void UpdateMovement()
    {
        Vector2 primary2dValue;
        InputFeatureUsage<Vector2> primary2dVector = CommonUsages.primary2DAxis;
        if (controller.TryGetFeatureValue(primary2dVector, out primary2dValue) && primary2dValue != Vector2.zero)
        {
            Debug.Log("primary2daxis is pressed" + primary2dValue);
            var xAxis = primary2dValue.x * speed * Time.deltaTime;
            var zAxis = primary2dValue.y * speed * Time.deltaTime;

            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            transform.position += right * xAxis;
            transform.position += forward * zAxis;
        }
    }
    private void UpdateJump()
    {

    }
}
