using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveNumbers : MonoBehaviour
{
    public int[] EnemyNum;
    public int[] SpawnerNum;
    private void Start()
    {
        EnemyNum = new int[GameObject.Find("WaveManager").GetComponent<WaveManager>().Waves];
        SpawnerNum = new int[transform.childCount];
    }
}
