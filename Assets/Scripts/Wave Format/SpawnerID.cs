using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerID : MonoBehaviour
{
    public enum Directions { Left, Up, Down, right };
    public Directions directions;
    public int[] Difficulties = {0,1,2,3};
    public int DespawnNum;

}
