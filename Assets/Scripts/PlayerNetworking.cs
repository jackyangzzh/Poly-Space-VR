using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworking : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject localXRRig;
    [SerializeField] GameObject AvatarHead;
    [SerializeField] GameObject AvatarBody;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            localXRRig.SetActive(true);
            gameObject.GetComponent<MovementController>().enabled = true;
            gameObject.GetComponent<AvatarInputConverter>().enabled = true;

            SetLayerRecursive(AvatarHead, 11);
            SetLayerRecursive(AvatarBody, 12);
        }
        else
        {
            localXRRig.SetActive(false);
            gameObject.GetComponent<MovementController>().enabled = false;
            gameObject.GetComponent<AvatarInputConverter>().enabled = false;

            SetLayerRecursive(AvatarHead, 0);
            SetLayerRecursive(AvatarBody, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetLayerRecursive(GameObject gameObject, int layerNumber)
    {
        if (gameObject == null)
        {
            return;
        }
        foreach (Transform trans in gameObject.GetComponentInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
