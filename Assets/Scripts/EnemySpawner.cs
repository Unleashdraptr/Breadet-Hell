using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPositions;
    public Transform[] EnemyPositionsVectors;
    public GameObject SpawnYPosition;
    public GameObject SpiralEnemies;
    public GameObject HomingEnemies;
    public GameObject TripleEnemies;
    public GameObject ShotgunEnemies;
    public GameObject EnemyStorage;

    public float Timer;

    private void Start()
    {
        //Gathers all the positions the enemies can stop at
        EnemyPositionsVectors = EnemyPositions.GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        //Creates a timer that will randomly reset every time it spawns the enemies
        Timer += 1 * Time.deltaTime;
        int randomSpawn = Random.Range(5, 12);
        if (Timer >= randomSpawn)
        {
            //Cycles through all positions they can spawn and randomly spawns them in each place
            for (int i = 0; i < EnemyPositionsVectors.Length; i++)
            {
                int random = Random.Range(1, Variables.SpawnChance[Variables.Difficulties-1]);
                if (random > 7)
                {
                    //Remove the enemies spawning where the parent object is
                    int Bias;
                    if (i == 0)
                    {
                        Bias = 1;
                    }
                    else
                        Bias = 0;
                    //Spawns the enemy above the object so they can slowly enter, giving the player time to get some damage in
                    Vector2 Pos = new(EnemyPositionsVectors[i+Bias].position.x, SpawnYPosition.transform.position.y);
                    int EnemySelect = Random.Range(1, 5);
                    if(EnemySelect == 1)
                    {
                        Instantiate(SpiralEnemies, Pos, Quaternion.Euler(0, 0, 180), EnemyStorage.transform);
                    }
                    if (EnemySelect == 2)
                    {
                        Instantiate(HomingEnemies, Pos, Quaternion.Euler(0, 0, 180), EnemyStorage.transform);
                    }
                    if (EnemySelect == 3)
                    {
                        Instantiate(TripleEnemies, Pos, Quaternion.Euler(0, 0, 180), EnemyStorage.transform);
                    }
                    if (EnemySelect == 4)
                    {
                        Instantiate(ShotgunEnemies, Pos, Quaternion.Euler(0, 0, 180), EnemyStorage.transform);
                    }
                }
            }
            Timer = 0;
        }
    }
}
