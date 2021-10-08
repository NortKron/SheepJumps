using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Crashes : MonoBehaviour
{
    /*
     * Example CrashReport
     * Holds data for a single application crash event and provides access to all gathered crash reports.
     * https://docs.unity3d.com/ScriptReference/CrashReport.html
     * 
     */

    void OnGUI()
    {
        var reports = CrashReport.reports;
        GUILayout.Label("Crash reports:");

        foreach (var r in reports)
        {
            GUILayout.BeginHorizontal();
            
            GUILayout.Label("Crash: " + r.time);
            
            if (GUILayout.Button("Log"))
            {
                Debug.Log(r.text);
            }

            if (GUILayout.Button("Remove"))
            {
                r.Remove();
            }

            GUILayout.EndHorizontal();
        }
    }
}
