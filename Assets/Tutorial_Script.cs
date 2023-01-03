using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour
{
    public int CurrentNum;
    public GameObject WaveManager;
    // Start is called before the first frame update
    void Start()
    {
        Variables.Pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.Pause == false && transform.GetChild(0).gameObject.activeInHierarchy == false)
        {
            Variables.Pause = true;
        }
        if(Variables.Pause == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void UpdateText(int Num)
    {
        if (CurrentNum != transform.GetChild(1).childCount)
        {
            transform.GetChild(1).GetChild(CurrentNum).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(CurrentNum + Num).gameObject.SetActive(true);
            CurrentNum += Num;
        }
        if (transform.GetChild(1).GetChild(4).gameObject.activeInHierarchy == true)
        {
            Variables.Pause = false;
        }
        if (transform.GetChild(1).GetChild(6).gameObject.activeInHierarchy == true)
        {
            WaveManager.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
