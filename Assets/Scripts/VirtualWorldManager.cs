using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{
    #region Photon Callback Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player Count " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
}
