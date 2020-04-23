using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGen))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGen mapGeneration = (MapGen)target;
        if (DrawDefaultInspector())
        {
            if (mapGeneration.updating)
            {
                mapGeneration.DrawnMapGeneration();
            }
        }

        if (GUILayout.Button("Generate Map"))
        {
            mapGeneration.DrawnMapGeneration();
        }
    }
}
