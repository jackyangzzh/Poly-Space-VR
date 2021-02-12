using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementController : MonoBehaviour
{
    [SerializeField] TeleportationProvider teleportationProvider;

    public float speed = 1.0f;
    public List<XRController> controllers;
    public GameObject head = null;

    private GameObject player;
    public GameObject XrRig;


    private void Awake()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        foreach (XRController xRController in controllers)
        {
            if (xRController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 positionVector))
            {
                if (positionVector.magnitude > 0.15f)
                {
                    Move(positionVector);
                }

            }

        }

    }

    private void OnEnable()
    {
        if(teleportationProvider){
            teleportationProvider.endLocomotion += OnEndLocomotion;
        }
        
    }

    private void OnDisable()
    {
        if(teleportationProvider){
            teleportationProvider.endLocomotion -= OnEndLocomotion;
        }
    }

    void OnEndLocomotion(LocomotionSystem locomotionSystem)
    {
        Debug.Log("Teleporation ended");
        player.transform.position = player.transform.TransformPoint(XrRig.transform.localPosition);
        XrRig.transform.localPosition = Vector3.zero;
    }


    private void Move(Vector2 positionVector)
    {
        // Apply the touch position to the head's forward Vector
        Vector3 direction = new Vector3(positionVector.x, 0, positionVector.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        // Rotate the input direction by the horizontal head rotation
        direction = Quaternion.Euler(headRotation) * direction;

        // Apply speed and move
        Vector3 movement = direction * speed;
        transform.position += (Vector3.ProjectOnPlane(Time.deltaTime * movement, Vector3.up));
    }
}
