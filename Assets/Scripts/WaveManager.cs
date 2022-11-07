using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject SpiralEnemies;
    public GameObject HomingEnemies;
    public GameObject TripleEnemies;
    public GameObject SnipeEnemies;
    public GameObject EnemyStorage;



    public int Waves;
    public int WaveNum;
    public int SpawnRate;

    //Each array value is an enemy
    public int[] EnemyAmount = {0,1,2,3,4,5,6,7};
    

    private void Start()
    {

    }
    private void Update()
    {

    }
}
