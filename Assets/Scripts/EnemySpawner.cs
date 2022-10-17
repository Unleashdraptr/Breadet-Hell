using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPositions;
    public Transform[] EnemyPositionsVectors;
    public GameObject SpawnYPosition;
    public GameObject Enemies;
    public GameObject EnemyStorage;

    public float Timer;

    private void Start()
    {
        EnemyPositionsVectors = EnemyPositions.GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        Timer += 1 * Time.deltaTime;
        int randomSpawn = Random.Range(7, 20);
        if (Timer >= randomSpawn)
        {
            for (int i = 0; i < EnemyPositionsVectors.Length; i++)
            {
                int random = Random.Range(1, 10);
                if (random > 7)
                {
                    Vector2 Pos = new Vector2(EnemyPositionsVectors[i+1].position.x, SpawnYPosition.transform.position.y);
                    Instantiate(Enemies, Pos, Quaternion.Euler(0,0,180), EnemyStorage.transform);
                }
            }
            Timer = 0;
        }
    }
}
