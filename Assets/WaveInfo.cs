using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveInfo : MonoBehaviour
{
    [Range(0, 10)]
    public int[] WaveNum;
    public enum Directions{Left, Up, Down, right};
    public Directions directions;


}

