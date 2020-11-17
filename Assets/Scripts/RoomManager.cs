using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region UI Callback Methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callback Methods

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name + " is created");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined");
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerConstants.mapTypeKey))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerConstants.mapTypeKey, out mapType))
            {
                Debug.Log(mapType.ToString());
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player Count " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;    // Limit of the free version

        string[] roomPropertyInLobby = { MultiplayerConstants.mapTypeKey };

        ExitGames.Client.Photon.Hashtable customRoomProperty = new ExitGames.Client.Photon.Hashtable() { { MultiplayerConstants.mapTypeKey, MultiplayerConstants.mapTypeValueOutdoor } };


        roomOptions.CustomRoomPropertiesForLobby = roomPropertyInLobby;
        roomOptions.CustomRoomProperties = customRoomProperty;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }
}
