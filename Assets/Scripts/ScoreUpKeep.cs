using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpKeep : MonoBehaviour
{
    public int Score;
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = ("Score: " + Score);
    }
}
