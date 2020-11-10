using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField playNameInput;

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region UI Callback Methods

    public void ConnectToPhoton()
    {
        if (playNameInput != null)
        {
            PhotonNetwork.NickName = playNameInput.text;
        }
        PhotonNetwork.ConnectUsingSettings();
    }

    #endregion


    #region Photon Callback Methods
    public override void OnConnected()
    {
        Debug.Log("On connected");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master with name: " + PhotonNetwork.NickName);
    }
    #endregion
}
