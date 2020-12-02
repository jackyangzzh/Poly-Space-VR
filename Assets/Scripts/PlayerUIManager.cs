using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject VRMenu;
    [SerializeField] GameObject HomeButton;

    // Start is called before the first frame update
    void Start()
    {
        VRMenu.SetActive(false);
        HomeButton.GetComponent<Button>().onClick.AddListener(VirtualWorldManager.instance.LeaveRoom);
    }

}
