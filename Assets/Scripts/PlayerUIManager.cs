using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject VRMenu;

    // Start is called before the first frame update
    void Start()
    {
        VRMenu.SetActive(false);
    }

}
