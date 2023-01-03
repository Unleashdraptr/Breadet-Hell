using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Variables
{
    public static int Difficulties = 1;
    public static bool PracticeMode = false;

    public static int Progress =  0;
    //Will pause the game state if true
    public static bool Pause;

    //Player side of stats that change for each difficulty
    public static int[] PlayerHealth = { 5, 5, 3, 1 };
    public static int[] HungerNum = { 20, 30, 40, 50 };
    public static float[] InvisTimer = { 2, 1.6f, 1.2f, 0.9f };

    public static int[] SpawnChance = { 10, 11, 12, 12 };

    //The multipler each boss will use for health scaling
    public static int[] BossMultiplers = {20 };
    public static bool BossFight;
}
