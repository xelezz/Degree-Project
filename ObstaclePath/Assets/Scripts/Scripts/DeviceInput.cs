using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class DeviceInput : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();
    public List<GameObject> controllerPrefabs;
    private GameObject spawnedController;
    public InputDeviceCharacteristics controllerCharacteristics;
    public bool isRight;
    private InputDevice device;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
