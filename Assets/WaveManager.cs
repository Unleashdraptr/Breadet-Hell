using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] Enemies;


    public GameObject Spawners;
    public int WaveNum;
    public int CurrentWave;
    public int[] EnemyNums;
    public float Wait;

    private void Start()
    {
        EnemyNums = new int[Spawners.transform.childCount];
        UpdateWaveInfo();
    }
    private void Update()
    {
        Wait += 1 * Time.deltaTime;
        if (Wait >= 10)
        {
            UpdateWaveInfo();
            SpawnEnemies();
            Wait = 0;
        }
    }


    public int SpawnerNum = 0;
    public int IDK;
    public int NumPerSpawn;
    void SpawnEnemies()
    {
        for (int i = 0; i < Spawners.transform.childCount; i++)
        {
            Debug.Log("I = " + i);
            NumPerSpawn = EnemyNums[i] / Spawners.transform.GetChild(i).childCount;
            for (int j = 0; j < EnemyNums[i]; j++)
            {
                Debug.Log("j = " + j);
                if(IDK == NumPerSpawn)
                {
                    SpawnerNum += 1;
                    IDK = 0;
                }
                Instantiate(Enemies[i], Spawners.transform.GetChild(i).GetChild(0).position, Quaternion.identity, GameObject.Find("EnemyStorage").transform);
                IDK += 1;
            }
        }
        CurrentWave += 1;
    }
    void UpdateWaveInfo()
    {
        for(int i = 0; i < Spawners.transform.childCount; i++)
        {
            EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().WaveNum[CurrentWave - 1];
        }
    }
}
