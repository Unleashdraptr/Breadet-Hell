using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveNumbers : MonoBehaviour
{
    public int[] EnemyNum = new int[10];
    public int[] SpawnerNum;
    private void Start()
    {
        Mathf.Clamp(EnemyNum.Length, 10, 10);
    }
}
