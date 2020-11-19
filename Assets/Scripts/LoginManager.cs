﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoginManager : MonoBehaviourPunCallbacks
{
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
        Debug.Log("Connected to master");
    }
    #endregion
}
