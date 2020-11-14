using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Responsible for connet to Photon Server", MessageType.Info);

        LoginManager loginManager = (LoginManager)target;
        if(GUILayout.Button("Connect Annoymously"))
        {
            loginManager.ConnectToPhoton();
        }
    }
}

