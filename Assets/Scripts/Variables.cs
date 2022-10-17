using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Variables
{
    public static int Difficulties = 1;

    //Player side of stats that change for each difficulty
    public static int[] PlayerHealth = { 7, 5, 4, 2 };
    public static float[] InvisTimer = { 1, 0.75f, 0.5f, 0.25f };

    //Temporary
    //Enemy Spawning side changing shooting mechanics and spawn chances
    public static int[] ShootDelayMin = { 5, 4, 3, 3 };
    public static int[] ShootDelayMax = { 20, 15, 12, 12 };
    public static int[] ShootRandomness = { 3, 5, 8, 12 };
    public static int[] SpawnChance = { 10, 11, 12, 12 };

    //Temporary
    //Enemy Attack side that changes the chances of the different type of attacks
    public static int[] Attack1Chances = { 65, 50, 25, 0 };
    public static int[] Attack2Chances = { 75, 60, 40, 35 };
    public static int[] Attack3Chances = { 85, 75, 60, 55 };
    public static int[] Attack4Chances = { 95, 85, 80, 75 };
    public static int[] Attack5Chances = { 100, 95, 85, 85 };
}
