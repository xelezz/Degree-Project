using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerCharacteristics : MonoBehaviour
{
    private InputDevice rightDevice;
    private InputDevice leftDevice;
    private List<InputDevice> Rdevices = new List<InputDevice>();
    private List<InputDevice> Ldevices = new List<InputDevice>();
    private List<InputDevice> devices = new List<InputDevice>();
    public List<GameObject> controllerPrefabs;
    private GameObject spawnedController;
    public InputDeviceCharacteristics controllerCharacteristics;
    public bool isRight;

    void Start()
    {
        //Right input device
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, Rdevices);
        //Left input device
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, Ldevices);

        InputDevices.GetDevices(devices);
        foreach (var device in devices)
        {
            Debug.Log(device.name + device.characteristics);
        }
    }

    void Update()
    {
        ControllerInput();
        ControllerSpawn();
    }
    
    private void ControllerSpawn()
    {
        if (isRight)
        {

            if (Rdevices.Count > 0)
            {
                rightDevice = Rdevices[0];
                //GameObject prefab = controllerPrefabs.Find(controller => controller.name == rightDevice.name);
                //if (prefab)
                //{
                //    spawnedController = Instantiate(prefab, transform);
                //}
                //else
                //{
                //    Debug.LogError("did not find controller model");
                //    spawnedController = Instantiate(controllerPrefabs[0], transform);
                //}
            }

        }
        else
        {

            if (Ldevices.Count > 0)
            {
                //leftDevice = Ldevices[0];
                //GameObject prefab = controllerPrefabs.Find(controller => controller.name == leftDevice.name);
                //if (prefab)
                //{
                //    spawnedController = Instantiate(prefab, transform);
                //}
                //else
                //{
                //    Debug.LogError("did not find controller model");
                //    spawnedController = Instantiate(controllerPrefabs[0], transform);
                //}
            }

        }


    }

    private void ControllerInput()
    {
        //The input for right controller
        #region RightHandInput
            if (rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rPrimaryButtonValue) && rPrimaryButtonValue)//A
            {
                Debug.Log("Pressing primary button(A)");
            }
        if (rightDevice.TryGetFeatureValue(CommonUsages.trigger, out float rTriggerValue) && rTriggerValue > 0.1f)//RIGHT TRIGGER
        {
            Debug.Log("Pressing trigger button(RightTrigger)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rPrimary2DaxisValue) && rPrimary2DaxisValue != Vector2.zero)//RIGHT THUMBSTICK MOVEMENT
        {
            Debug.Log("Moving right thumbstick(Right2daxis)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool rPrimary2DAxisClickValue) && rPrimary2DAxisClickValue)//LEFT THUMBSTICK PRESS
        {
            Debug.Log("Pressing RIGHT thumbstick(Left2daxis)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rGripButtonValue) && rGripButtonValue)//RIGHT GRIP
        {
            Debug.Log("Pressing grip button(Right GRIP)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rSecondaryButtonValue) && rSecondaryButtonValue)
        {
            Debug.Log("Pressing secondary button(B)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool rSecondaryTouchValue) && rSecondaryTouchValue)
        {
            Debug.Log("Touching secondary touch button(B)");
        }
        if (rightDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool rPrimaryTouchValue) && rPrimaryTouchValue)
        {
            Debug.Log("Touching primary touch button(A)");
        }

        #endregion RightHandInput

        //The input for the left controller
        #region LeftHandInput
        if (leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool lPrimaryButtonValue) && lPrimaryButtonValue)//X
        {
            Debug.Log("Pressing primary button(X)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.trigger, out float lTriggerValue) && lTriggerValue > 0.1f)//LEFT TRIGGER
        {
            Debug.Log("Pressing trigger button(LeftTrigger)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 lPrimary2DAxisValue) && lPrimary2DAxisValue != Vector2.zero)//LEFT THUMBSTICK MOVEMENT
        {
            Debug.Log("Moving left thumbstick(Left2daxis)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool lPrimary2DAxisClickValue) && lPrimary2DAxisClickValue)//LEFT THUMBSTICK PRESS
        {
            Debug.Log("Pressing left thumbstick(Left2daxis)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool lGripButtonValue) && lGripButtonValue)//LEFT GRIP
        {
            Debug.Log("Pressing grip button(Left GRIP)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue) && menuButtonValue)//MENUBUTTON
        {
            Debug.Log("Pressing menu button(MENUBUTTON)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool lSecondaryButtonValue) && lSecondaryButtonValue)
        {
            Debug.Log("Pressing secondary button(Y)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool lSecondaryTouchValue) && lSecondaryTouchValue)
        {
            Debug.Log("Touching secondary touch button(Y)");
        }
        if (leftDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool lPrimaryTouchValue) && lPrimaryTouchValue)
        {
            Debug.Log("Touching primary touch button(X)");
        }

        #endregion LeftHandInput





        //#region RightHandInput
        //rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rPrimaryButtonValue);
        //if (rPrimaryButtonValue)//A
        //    Debug.Log("Pressing primary button(A)" + rPrimaryButtonValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.trigger, out float rTriggerValue); 
        //if (rTriggerValue > 0.1f)//RIGHT TRIGGER
        //    Debug.Log("Pressing trigger button(RightTrigger)" + rTriggerValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rPrimary2DaxisValue);
        //if (rPrimary2DaxisValue != Vector2.zero)//RIGHT THUMBSTICK MOVEMENT
        //    Debug.Log("Moving right thumbstick(Right2daxis)" + rPrimary2DaxisValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool rSecondary2DAxisValue); 
        //if (rSecondary2DAxisValue)//LEFT THUMBSTICK PRESS
        //    Debug.Log("Pressing RIGHT thumbstick(Left2daxis)" + rSecondary2DAxisValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rGripButtonValue); 
        //if(rGripButtonValue)//RIGHT GRIP
        //    Debug.Log("Pressing grip button(Right GRIP)" + rGripButtonValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rSecondaryButtonValue); 
        //if(rSecondaryButtonValue)
        //    Debug.Log("Pressing secondary button(B)" + rSecondaryButtonValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool rSecondaryTouchValue); 
        //if( rSecondaryTouchValue)
        //    Debug.Log("Touching secondary touch button(B)" + rSecondaryTouchValue);

        //rightDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool rPrimaryTouchValue);
        //if(rPrimaryTouchValue)
        //    Debug.Log("Touching primary touch button(A)" + rPrimaryTouchValue);

        ////if (rightDevice.TryGetFeatureValue(CommonUsages.thumbrest, out bool rthumbTouchValue) && rthumbTouchValue)
        ////{
        ////    Debug.Log("Touching right thumbrest");
        ////}
        //#endregion RightHandInput

        ////The input for the left controller
        //#region LeftHandInput
        //leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool lPrimaryButtonValue);
        //if (lPrimaryButtonValue)//X
        //    Debug.Log("Pressing primary button(X)" + lPrimaryButtonValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.trigger, out float lTriggerValue);//LEFT TRIGGER
        //if(lTriggerValue > 0.1f)
        //        Debug.Log("Pressing trigger button(LeftTrigger)" + lTriggerValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 lPrimary2DAxisValue);//LEFT THUMBSTICK MOVEMENT
        //if (lPrimary2DAxisValue != Vector2.zero) 
        //    Debug.Log("Moving left thumbstick(Left2daxis)" + lPrimary2DAxisValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool lSecondary2DAxisValue);//LEFT THUMBSTICK PRESS
        //if(lSecondary2DAxisValue)
        //    Debug.Log("Pressing left thumbstick(Left2daxis)" + lSecondary2DAxisValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool lGripButtonValue);//LEFT GRIP
        //if (lGripButtonValue)
        //    Debug.Log("Pressing grip button(Left GRIP)" + lGripButtonValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue);//MENUBUTTON
        //if (menuButtonValue)
        //    Debug.Log("Pressing menu button(MENUBUTTON)" + menuButtonValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool lSecondaryButtonValue);
        //if (lSecondaryButtonValue)
        //    Debug.Log("Pressing secondary button(Y)"+ lSecondaryButtonValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool lSecondaryTouchValue); 
        //if (lSecondaryTouchValue)        
        //    Debug.Log("Touching secondary touch button(Y)" + lSecondaryTouchValue);

        //leftDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool lPrimaryTouchValue);
        //if (lPrimaryTouchValue)
        //    Debug.Log("Touching primary touch button(X)" + lPrimaryTouchValue);

        //if (leftDevice.TryGetFeatureValue(CommonUsages.thumbrest, out bool lthumbTouchValue) && lthumbTouchValue)
        //{
        //    Debug.Log("Touching left thumbrest");
        //}
        //#endregion LeftHandInput
        
        //Shows all devices
        //InputDevices.GetDevices(devices);
    }
}
