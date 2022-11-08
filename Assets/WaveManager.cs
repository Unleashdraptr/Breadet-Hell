using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] Enemies;


    public GameObject Spawners;
    public int CurrentWave;
    public int[] EnemyNums;
    public float Wait;

    [Range(1, 25)]
    public int WaveNum;
    private void Start()
    {
        EnemyNums = new int[Spawners.transform.childCount];
        UpdateWaveInfo();
    }
    private void Update()
    {
        Wait += 1 * Time.deltaTime;
        if (Wait >= 30)
        {
            UpdateWaveInfo();
            StartCoroutine(SpawnEnemies());
            Wait = 0;
        }
    }


    public int SpawnerNum = 0;
    public int IDK;
    public int NumPerSpawn;
    IEnumerator SpawnEnemies()
    {
        IDK = 0;
        SpawnerNum = 0;
        for (int i = 0; i < Spawners.transform.childCount; i++)
        {
            NumPerSpawn = EnemyNums[i] / Spawners.transform.GetChild(i).childCount;
            for (int j = 0; j < EnemyNums[i]; j++)
            {
                if(IDK == NumPerSpawn)
                {
                    SpawnerNum += 1;
                    IDK = 0;
                }
                if(SpawnerNum >= Spawners.transform.GetChild(i).childCount)
                {
                    SpawnerNum = 0;
                }
                GameObject Spawned = Instantiate(Enemies[i], Spawners.transform.GetChild(i).GetChild(SpawnerNum).position, Quaternion.identity, GameObject.Find("EnemyStorage").transform);
                IDK += 1;
                yield return new WaitForSeconds(0.5f);
            }
            IDK = 0;
            SpawnerNum = 0;
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
