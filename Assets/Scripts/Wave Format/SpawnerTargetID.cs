using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnerTargetID : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] Enemies;
    [Tooltip(" 1 = BUNny, 2 = Nyaan, 3 = Breadgehog, 4 = Hot Dog, 5 = (Not added yet), 6 = Bossling, 7 = Toaster ")]
    [Range(1,7)]
    public int EnemySpawnID;
    [Tooltip(" Wave the spawner appears in the level ")]
    [Range(1, 12)]
    public int WaveSpawnNum;
    [Tooltip(" (at the end) Wave the spawner disappears in the level ")]
    [Range(1, 12)]
    public int WaveDespawnNum;
    [Tooltip(" The direction the enemies will walk after spawning ")]
    public SpawnerID.Directions SpawnDirection;
    public enum Difficulties { Normal, Toasty, Burnt, Breadendary }
    [Tooltip(" The difficulty the spawner will be used on ")]
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
        EditorGUILayout.BeginHorizontal();
        //Sprite sprite = EditorGUILayout.ObjectField(Tar.Enemies[Tar.EnemySpawnID-1], typeof(Sprite), true, GUILayout.Height(48), GUILayout.Width(48)) as Sprite;
        EditorGUILayout.EndHorizontal();
        EditorApplication.QueuePlayerLoopUpdate();
    }
}
