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

    bool firsTake = false;

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

    private void OnEnable()
    {
        firsTake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            leftHandTransform.localPosition = Vector3.MoveTowards(leftHandTransform.localPosition, networkPosition_Left, distance_Left * (1.0f / PhotonNetwork.SerializationRate));
            leftHandTransform.localRotation = Quaternion.RotateTowards(leftHandTransform.localRotation, networkRotation_Left, angle_Left * (1.0f / PhotonNetwork.SerializationRate));
        }

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
            networkPosition_Left = (Vector3)stream.ReceiveNext();
            handDirection_Left = (Vector3)stream.ReceiveNext();

            if (firsTake)
            {
                leftHandTransform.localPosition = networkPosition_Left;
                distance_Left = 0;
            }
            else
            {
                float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                networkPosition_Left += handDirection_Left * lag;
                distance_Left = Vector3.Distance(leftHandTransform.localPosition, networkPosition_Left);
            }

            networkRotation_Left = (Quaternion)stream.ReceiveNext();
            if (firsTake)
            {
                angle_Left = 0;
                leftHandTransform.localRotation = networkRotation_Left;
            }
            else
            {
                angle_Left = Quaternion.Angle(leftHandTransform.localRotation, networkRotation_Left);
            }

            if (firsTake)
            {
                firsTake = false;
            }
        }
    }

}
