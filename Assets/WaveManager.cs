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
        if (Wait >= 15)
        {
            UpdateWaveInfo();
            StartCoroutine(SpawnEnemies());
            Wait = 0;
        }
    }


    public int SpawnerNum = 0;
    public int RotationNum;
    public int NumPerLoop;
    Vector2 MoveDirect;
    IEnumerator SpawnEnemies()
    {
        RotationNum = 0;
        SpawnerNum = 0;
        for (int i = 0; i < Spawners.transform.childCount; i++)
        {
            NumPerLoop = EnemyNums[i] / Spawners.transform.GetChild(i).childCount;
            if (NumPerLoop != 0)
            {
                NumPerLoop = EnemyNums[i] / NumPerLoop;
            }
            for (int j = 0; j < EnemyNums[i]; j++)
            {
                if(RotationNum == NumPerLoop)
                {
                    SpawnerNum += 1;
                    RotationNum = 0;
                    yield return new WaitForSeconds(0.75f);
                }
                GameObject Clone = Instantiate(Enemies[i], Spawners.transform.GetChild(i).GetChild(RotationNum).position, Quaternion.identity, GameObject.Find("EnemyStorage").transform);
                SetMove(Spawners.transform.GetChild(i).GetChild(RotationNum).GetComponent<DirectionMove>().directions);
                CheckAI(Clone);
                RotationNum += 1;
            }
            RotationNum = 0;
            SpawnerNum = 0;
        }
        CurrentWave += 1;
    }

    void SetMove(DirectionMove.Directions Dir)
    {
        if(Dir == DirectionMove.Directions.Left)
        {
            MoveDirect = new(-150, 0);
        }
        if (Dir == DirectionMove.Directions.Up)
        {
            MoveDirect = new(0, 150);
        }
        if (Dir == DirectionMove.Directions.right)
        {
            MoveDirect = new(150, 0);
        }
        if (Dir == DirectionMove.Directions.Down)
        {
            MoveDirect = new(0, -150);
        }
    }
    void CheckAI(GameObject Clone)
    {
        if(Clone.name == "BUNny(Clone)")
        {
            Clone.GetComponent<BUNny_AI>().MoveSpeed = MoveDirect;
        }
        if (Clone.name == "Nyaan(Clone)")
        {
            Clone.GetComponent<NyaanCat_AI>().MoveSpeed = MoveDirect;
        }
        if (Clone.name == "Breadgehog(Clone)")
        {
            Clone.GetComponent<Bredgehog_AI>().MoveSpeed = MoveDirect;
        }
        if (Clone.name == "SnipeShot(Clone)")
        {
            Clone.GetComponent<HotDog_AI>().MoveSpeed = MoveDirect;
        }
    }
    void UpdateWaveInfo()
    {
        for(int i = 0; i < Spawners.transform.childCount; i++)
        {
            EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().WaveNum[CurrentWave - 1];
        }
    }
}
