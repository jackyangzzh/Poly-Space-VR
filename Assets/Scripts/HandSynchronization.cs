using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandSynchronization : MonoBehaviour, IPunObservable
{
    [SerializeField] Transform leftHandTransform;

    private PhotonView photonView;
    private float distance_Left;
    // Position
    private Vector3 handDirection_Left;
    private Vector3 networkPosition_Left;
    private Vector3 storePosition_Left;
    // Rotation
    private Quaternion networkRotation_Left;
    private float angle_Left;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();

        storePosition_Left = leftHandTransform.localPosition;
        networkPosition_Left = Vector3.zero;
        networkRotation_Left = Quaternion.identity;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            handDirection_Left = leftHandTransform.localPosition - storePosition_Left;
            storePosition_Left = leftHandTransform.localPosition;

            stream.SendNext(storePosition_Left);
            stream.SendNext(handDirection_Left);
            stream.SendNext(leftHandTransform.localRotation);
        }
        else
        {

        }
    }

}
