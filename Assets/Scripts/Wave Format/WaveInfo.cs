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
    public enum Difficulties { Normal, Toasty, Burnt, Breadendary }
    [Tooltip(" The lowest difficulty the spawner will be used on ")]
    public Difficulties difficulties;
}
/*
[CustomEditor(typeof(WaveInfo))]
public class WaveUpdate : Editor
{
    void UpdateField(ref int[] Nums)
    {
        for (int i = 0; i < Nums.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Wave " + (i + 1), GUILayout.MaxWidth(50));
            int IDK = EditorGUILayout.IntField(Nums[i]);
            Nums[i] = IDK;
            EditorGUILayout.EndHorizontal();
        }
    }
    public override void OnInspectorGUI()
    {
        WaveInfo Waveinfo = target as WaveInfo;
        DrawDefaultInspector();
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Normal)
        {
            System.Array.Resize(ref Waveinfo.D1WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            UpdateField(ref Waveinfo.D1WaveNum);
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Toasty)
        {
            System.Array.Resize(ref Waveinfo.D2WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            UpdateField(ref Waveinfo.D2WaveNum);
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Burnt)
        {
            System.Array.Resize(ref Waveinfo.D3WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            UpdateField(ref Waveinfo.D3WaveNum);
        }
        if (Waveinfo.difficulties == WaveInfo.Difficulties.Breadendary)
        {
            System.Array.Resize(ref Waveinfo.D4WaveNum, GameObject.Find("WaveManager").GetComponent<WaveManager>().TotalWaves);
            UpdateField(ref Waveinfo.D4WaveNum);
        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Difficluty Reset"))
        {
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Normal)
            {
                Waveinfo.D1WaveNum = new int[Waveinfo.D1WaveNum.Length];
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Toasty)
            {
                Waveinfo.D2WaveNum = new int[Waveinfo.D2WaveNum.Length];
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Burnt)
            {
                Waveinfo.D3WaveNum = new int[Waveinfo.D3WaveNum.Length];
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Breadendary)
            {
                Waveinfo.D4WaveNum = new int[Waveinfo.D4WaveNum.Length];
            }
        }
        if(GUILayout.Button("Full Reset"))
        {
            Waveinfo.D1WaveNum = new int[Waveinfo.D1WaveNum.Length];
            Waveinfo.D2WaveNum = new int[Waveinfo.D2WaveNum.Length];
            Waveinfo.D3WaveNum = new int[Waveinfo.D3WaveNum.Length];
            Waveinfo.D4WaveNum = new int[Waveinfo.D4WaveNum.Length];
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Copy Up"))
        {
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Normal)
            {
                for (int i = 0; i < Waveinfo.D1WaveNum.Length; i++)
                {
                    Waveinfo.D2WaveNum[i] = Waveinfo.D1WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Toasty)
            {
                for (int i = 0; i < Waveinfo.D2WaveNum.Length; i++)
                {
                    Waveinfo.D3WaveNum[i] = Waveinfo.D2WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Burnt)
            {
                for (int i = 0; i < Waveinfo.D3WaveNum.Length; i++)
                {
                    Waveinfo.D4WaveNum[i] = Waveinfo.D3WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Breadendary)
            {
                for (int i = 0; i < Waveinfo.D4WaveNum.Length; i++)
                {
                    Waveinfo.D1WaveNum[i] = Waveinfo.D4WaveNum[i];
                }
            }
        }
        if (GUILayout.Button("Copy Down"))
        {
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Normal)
            {
                for (int i = 0; i < Waveinfo.D1WaveNum.Length; i++)
                {
                    Waveinfo.D4WaveNum[i] = Waveinfo.D1WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Toasty)
            {
                for (int i = 0; i < Waveinfo.D2WaveNum.Length; i++)
                {
                    Waveinfo.D1WaveNum[i] = Waveinfo.D2WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Burnt)
            {
                for (int i = 0; i < Waveinfo.D3WaveNum.Length; i++)
                {
                    Waveinfo.D2WaveNum[i] = Waveinfo.D3WaveNum[i];
                }
            }
            if (Waveinfo.difficulties == WaveInfo.Difficulties.Breadendary)
            {
                for (int i = 0; i < Waveinfo.D4WaveNum.Length; i++)
                {
                    Waveinfo.D3WaveNum[i] = Waveinfo.D4WaveNum[i];
                }
            }
        }
        EditorGUILayout.EndHorizontal();
    }
}
*/

