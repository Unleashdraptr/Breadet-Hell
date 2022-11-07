using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Variables
{
    public static int Difficulties = 1;
    public static int Progress = 4;
    //Will pause the game state if true
    public static bool Pause;

    //Player side of stats that change for each difficulty
    public static int[] PlayerHealth = { 7, 6, 3, 200 };
    public static float[] InvisTimer = { 1, 0.75f, 0.5f, 0.25f };

    //Temporary
    //Enemy Spawning side changing shooting mechanics and spawn chances
    public static int[] ShootDelayMin = { 5, 4, 3, 3 };
    public static int[] ShootDelayMax = { 20, 15, 12, 12 };
    public static int[] ShootRandomness = { 3, 5, 8, 12 };
    public static int[] SpawnChance = { 10, 11, 12, 12 };

    //The multipler each boss will use for health scaling
    public static int[] BossMultiplers = {20 };
}
