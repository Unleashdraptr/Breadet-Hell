using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnerTargetID : MonoBehaviour
{
    [Range(1,8)]
    public int EnemySpawnID;
    [Range(1, 12)]
    public int WaveSpawnNum;
    [Range(1, 12)]
    public int WaveDespawnNum;
    public SpawnerID.Directions SpawnDirection;
    public enum Difficulties { Normal, Toasty, Burnt, Breadendary }
    public Difficulties difficulties;
    [HideInInspector]
    public Color[] Colour = { new(0,100,100), new(0,100,62), new(0,100,30), Color.black };
}
[CustomEditor(typeof(SpawnerTargetID))]
public class SpawnerTargetIDEditor : Editor
{
    public override void OnInspectorGUI()
    {

        SpawnerTargetID Tar = target as SpawnerTargetID;
        DrawDefaultInspector();
        if (Tar.difficulties == SpawnerTargetID.Difficulties.Normal)
        {
            Tar.GetComponentInParent<SpriteRenderer>().color = Tar.Colour[0];
        }
        if (Tar.difficulties == SpawnerTargetID.Difficulties.Toasty)
        {
            Tar.GetComponent<SpriteRenderer>().color = Tar.Colour[1];
        }
        if (Tar.difficulties == SpawnerTargetID.Difficulties.Burnt)
        {
            Tar.GetComponent<SpriteRenderer>().color = Tar.Colour[2];
        }
        if (Tar.difficulties == SpawnerTargetID.Difficulties.Breadendary)
        {
            Tar.GetComponent<SpriteRenderer>().color = Tar.Colour[3];
        }
        EditorApplication.QueuePlayerLoopUpdate();
    }
}
