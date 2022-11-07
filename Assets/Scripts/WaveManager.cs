using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject SpiralEnemies;
    public GameObject HomingEnemies;
    public GameObject TripleEnemies;
    public GameObject SnipeEnemies;
    public GameObject EnemyStorage;

    public GameObject Spawners;

    public int Waves;
    public int WaveNum;
    public int SpawnRate;

    //Each array value is an enemy
    public int[] EnemyAmount = { 0, 0, 0, 0, 0, 0, 0, 0,0 };
    

    private void Start()
    {
        WaveNum = 1;
        for(int i = 0; i < Spawners.transform.childCount; i++)
        {
            EnemyAmount[i] = Spawners.transform.GetChild(i).GetComponent<WaveNumbers>().EnemyNum[Waves-1];
        }
    }
    private void Update()
    {
        
    }
}
