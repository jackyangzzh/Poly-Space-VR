using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject OVRCameraRig;
    public GameObject pauseMenuUIThing;
    public GameObject[] listOfObjectsToHideOnPause;

    private AudioSource[] audioSources;
    private void OnEnable()
    {
        print("On Enabled");
        // try to find camera rig automatically, if it's not set in the Inspector..
        if (OVRCameraRig == null)
            OVRCameraRig = GameObject.Find("OVRCameraRig");

        // this subscribes to Oculus events, so when they fire our functions get called in this script
        OVRManager.HMDUnmounted += PauseGame;
        OVRManager.HMDMounted += UnPauseGame;
        OVRManager.VrFocusLost += PauseGame;
        OVRManager.VrFocusAcquired += UnPauseGame;
        OVRManager.InputFocusLost += PauseGame;
        OVRManager.InputFocusAcquired += UnPauseGame;
    }

    private void OnDisable()
    {
        // this unsubscribes from the Oculus events when they're no longer needed (when this object is disabled etc)
        OVRManager.HMDUnmounted -= PauseGame;
        OVRManager.HMDMounted -= UnPauseGame;
        OVRManager.VrFocusLost -= PauseGame;
        OVRManager.VrFocusAcquired -= UnPauseGame;
        OVRManager.InputFocusLost -= PauseGame;
        OVRManager.InputFocusAcquired -= UnPauseGame;
    }

    private void PauseGame()
    {
        Debug.Log("PAUSE! --------------------------------------------");
        // show menu message thing, if we have one..
        if (pauseMenuUIThing != null)
            pauseMenuUIThing.SetActive(true);

        // if we have objects to hide, let's hide them..
        for (int i = 0; i < listOfObjectsToHideOnPause.Length; i++)
        {
            listOfObjectsToHideOnPause[i].SetActive(false);
        }

        // find and start all audiosources in the Scene
        AudioSource[] audioSources = GameObject.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].Pause();
        }

        // pause time
        Time.timeScale = 0.0f;
    }

    private void UnPauseGame()
    {
        Debug.Log("UNPAUSE! --------------------------------------------");

        if (OVRManager.hasVrFocus && OVRManager.isHmdPresent && OVRManager.hasInputFocus)
        {
            // hide menu message thing, if we have one..
            if (pauseMenuUIThing != null)
                pauseMenuUIThing.SetActive(false);

            // if we have objects to hide, let's hide them..
            for (int i = 0; i < listOfObjectsToHideOnPause.Length; i++)
            {
                listOfObjectsToHideOnPause[i].SetActive(true);
            }

            // find and stop all audioSources in the Scene
            AudioSource[] audioSources = GameObject.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].UnPause();
            }

            // restart time
            Time.timeScale = 1.0f;
        }
    }

}