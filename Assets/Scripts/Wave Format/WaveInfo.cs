using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveInfo : MonoBehaviour
{
    [HideInInspector]
    public int[] D1WaveNum;
    [HideInInspector]
    public int[] D2WaveNum;
    [HideInInspector]
    public int[] D3WaveNum;
    [HideInInspector]
    public int[] D4WaveNum;
    public enum Difficulties{Normal, Toasty, Burnt, Breadendary}
    public Difficulties difficulties;
}


[CustomEditor(typeof(WaveInfo))]
public class WaveUpdate : Editor
{
    public override void OnInspectorGUI()
    {
        WaveInfo Waveinfo = target as WaveInfo;
        DrawDefaultInspector();
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Normal)
        {
            System.Array.Resize(ref Waveinfo.D1WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            for (int i = 0; i < Waveinfo.D1WaveNum.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Wave " + (i + 1), GUILayout.MaxWidth(50));
                int IDK = EditorGUILayout.IntField(Waveinfo.D1WaveNum[i]);
                Waveinfo.D1WaveNum[i] = IDK;
                EditorGUILayout.EndHorizontal();
            }
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Toasty)
        {
            System.Array.Resize(ref Waveinfo.D2WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            for (int i = 0; i < Waveinfo.D2WaveNum.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Wave " + (i + 1), GUILayout.MaxWidth(50));
                int IDK = EditorGUILayout.IntField(Waveinfo.D2WaveNum[i]);
                Waveinfo.D2WaveNum[i] = IDK;
                EditorGUILayout.EndHorizontal();
            }
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Burnt)
        {
            System.Array.Resize(ref Waveinfo.D3WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            for (int i = 0; i < Waveinfo.D3WaveNum.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Wave " + (i + 1), GUILayout.MaxWidth(50));
                int IDK = EditorGUILayout.IntField(Waveinfo.D3WaveNum[i]);
                Waveinfo.D3WaveNum[i] = IDK;
                EditorGUILayout.EndHorizontal();
            }
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Breadendary)
        {
            System.Array.Resize(ref Waveinfo.D4WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            for (int i = 0; i < Waveinfo.D4WaveNum.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Wave " + (i + 1), GUILayout.MaxWidth(50));
                int IDK = EditorGUILayout.IntField(Waveinfo.D4WaveNum[i]);
                Waveinfo.D4WaveNum[i] = IDK;
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}

