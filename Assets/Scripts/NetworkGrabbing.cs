using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    private PhotonView _photonView;
    private Rigidbody rigidbody;

    public bool isHeld = false;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            rigidbody.isKinematic = true;
            gameObject.layer = 13;
        }
        else
        {
            rigidbody.isKinematic = false;
            gameObject.layer = 8;
        }
    }

    public void OnSelectEnter()
    {
        photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);

        if (photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            return;
        }

        TransferOwnership();
    }

    public void OnSelectExit()
    {
        photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
    }

    private void TransferOwnership()
    {
        _photonView.RequestOwnership();
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if(targetView != photonView){
            return;
        }
        _photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {

    }

    [PunRPC]
    public void StartNetworkGrabbing()
    {
        isHeld = true;
    }

    [PunRPC]
    public void StopNetworkGrabbing()
    {
        isHeld = false;
    }
}
