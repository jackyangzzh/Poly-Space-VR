using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject UIOpenWorld;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        UIOpenWorld.SetActive(false);
    }

    public void OnWorldsButtonClicked()
    {
        Debug.Log("World button");
        if (UIOpenWorld != null)
        {
            UIOpenWorld.SetActive(true);
        }
    }

    public void OnHomeButtonClicked()
    {

    }

    public void OnAvatarButtonClicked()
    {
        AvatarSelectionManager.Instance.ActivateAvatarSelectionPlatform();
    }
}
