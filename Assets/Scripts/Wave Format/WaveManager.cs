using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject Spawner;

    public GameObject SpawnerLocations;
    public GameObject Spawners;
    public int CurrentWave;
    public int[] EnemyNums;
    readonly string[] EnemyNames = { "BUNny", "Nyaan Bread", "Breadgehog", "Hot Dog", "Homing", "Croissidile", "Bosslings", "Mines" };
    public float Wait;

    [Range(1, 25)]
    public int TotalWaves;
    private void Start()
    {
        EnemyNums = new int[Spawners.transform.childCount];
        UpdateWaveInfo();
        UpdateSpawners();
    }
    private void Update()
    {
        if (Variables.Pause != true)
        {
            Wait += 1 * Time.deltaTime;
        }
        if (Wait >= 10 && CurrentWave != TotalWaves+1)
        {
            StartCoroutine(SpawnEnemies());
            Wait = 0;
        }
        if (CurrentWave > TotalWaves && GameObject.Find("EnemyStorage").transform.childCount == 0)
        {
            GameObject.Find("Canvas").GetComponent<GameState>().EnemyDead = true;
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
            if (Spawners.transform.GetChild(i).childCount != 0)
            {
                NumPerLoop = Spawners.transform.GetChild(i).childCount;
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
                SetMove(Spawners.transform.GetChild(i).GetChild(RotationNum).GetComponent<SpawnerID>().directions);
                CheckAI(Clone);
                RotationNum += 1;
            }
            RotationNum = 0;
            SpawnerNum = 0;
        }
        CurrentWave += 1;
        UpdateWaveInfo();
        UpdateSpawners();
    }

    void UpdateSpawners()
    {
        for(int i = 0; i < Spawners.transform.childCount; i++)
        {
            for(int k = 0; k < Spawners.transform.GetChild(i).childCount; k++)
            {
                if(Spawners.transform.GetChild(i).GetChild(k).GetComponent<SpawnerID>().DespawnNum < CurrentWave)
                {
                    Destroy(Spawners.transform.GetChild(i).GetChild(k).gameObject);
                }
            }
        }
        for(int i = 0; i < SpawnerLocations.transform.childCount; i++)
        {
            if(SpawnerLocations.transform.GetChild(i).GetComponent<SpawnerTargetID>().WaveSpawnNum == CurrentWave)
            {
                if (((int)SpawnerLocations.transform.GetChild(i).GetComponent<SpawnerTargetID>().difficulties) <= Variables.Difficulties)
                {
                    GameObject Location = SpawnerLocations.transform.GetChild(i).gameObject;
                    Vector3 Pos = new(Location.transform.position.x, Location.transform.position.y, 0);
                    GameObject nSpawner = Instantiate(Spawner, Pos, Quaternion.identity, GameObject.Find(EnemyNames[Location.GetComponent<SpawnerTargetID>().EnemySpawnID - 1]).transform);
                    nSpawner.GetComponent<SpawnerID>().DespawnNum = Location.GetComponent<SpawnerTargetID>().WaveDespawnNum;
                    nSpawner.GetComponent<SpawnerID>().directions = Location.GetComponent<SpawnerTargetID>().SpawnDirection;
                    Destroy(SpawnerLocations.transform.GetChild(i).gameObject);
                }
            }
        }
    }
    void SetMove(SpawnerID.Directions Dir)
    {
        if(Dir == SpawnerID.Directions.Left)
        {
            MoveDirect = new(-150, 0);
        }
        if (Dir == SpawnerID.Directions.Up)
        {
            MoveDirect = new(0, 150);
        }
        if (Dir == SpawnerID.Directions.right)
        {
            MoveDirect = new(150, 0);
        }
        if (Dir == SpawnerID.Directions.Down)
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
            if (Variables.Difficulties == 1)
            {
                EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().D1WaveNum[CurrentWave - 1];
            }
            if (Variables.Difficulties == 2)
            {
                EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().D2WaveNum[CurrentWave - 1];
            }
            if (Variables.Difficulties == 3)
            {
                EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().D3WaveNum[CurrentWave - 1];
            }
            if (Variables.Difficulties == 4)
            {
                EnemyNums[i] = Spawners.transform.GetChild(i).GetComponent<WaveInfo>().D4WaveNum[CurrentWave - 1];
            }
        }
    }
}
