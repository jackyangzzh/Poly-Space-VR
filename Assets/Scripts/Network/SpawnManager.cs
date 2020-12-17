using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject genericVRPlayer;

    public Vector3 SpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(genericVRPlayer.name, SpawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
