using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    public void OnWorldsButtonClicked()
    {
        Debug.Log("World button");
    }

    public void OnHomeButtonClicked()
    {
        Debug.Log("Home Button");
    }

    public void OnAvatarButtonClicked()
    {
        Debug.Log("Avatar Button");
    }
}
