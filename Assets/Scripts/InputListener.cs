using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputListener : MonoBehaviour
{
    private List<InputDevice> inputDevices;
    private InputDeviceCharacteristics deviceCharacteristics;

    public XRNode xrNode;

    private void Awake()
    {
        inputDevices = new List<InputDevice>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deviceCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;
        InputDevices.GetDevicesAtXRNode(xrNode, inputDevices);

        foreach (InputDevice inputDevice in inputDevices)
        {
            Debug.Log(inputDevice.name);
        }
    }
}
