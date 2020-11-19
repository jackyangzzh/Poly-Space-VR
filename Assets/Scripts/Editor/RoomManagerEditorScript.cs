﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Responsible for creating and joining rooms", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("Join Random Room"))
        {
            roomManager.JoinRandomRoom();
        }

        if (GUILayout.Button("Join School Room"))
        {
            roomManager.OnEnterRoomButton_School();
        }

        if (GUILayout.Button("Join Outdoor Room"))
        {
            roomManager.OnEnterRoomButton_Outdoor();
        }
    }
}
