using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDifficulty : MonoBehaviour
{
    public Sprite[] DifficultyStars;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = DifficultyStars[Variables.Difficulties-1];
        if (Variables.PracticeMode == true)
        {
            GetComponent<Image>().sprite = DifficultyStars[Variables.Difficulties + 3];
        }
    }

}
