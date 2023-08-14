using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour
{
    public int CurrentNum;
    public int TutorialID = 1;
    public GameObject WaveManager;
    public GameObject Dummy;
    private GameObject D1;
    private GameObject D2;
    private GameObject D3;
    // Start is called before the first frame update
    void Start()
    {
        Variables.Pause = true;
        if (Variables.Pause == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void UpdateText(int Num)
    {
        if (CurrentNum != transform.childCount)
        {
            transform.GetChild(CurrentNum).gameObject.SetActive(false);
            transform.GetChild(CurrentNum + Num).gameObject.SetActive(true);
            CurrentNum += Num;
        }

        if (TutorialID == 1)
        {
            if (Num == 5)
            {
                WaveManager.SetActive(true);
                gameObject.SetActive(false);
                Variables.Pause = false;
                Destroy(D1);
                Destroy(D2);
                Destroy(D3);
            }
            if (transform.GetChild(4).gameObject.activeInHierarchy == true)
            {
                Variables.Pause = false;
            }
            if (transform.GetChild(5).gameObject.activeInHierarchy == true)
            {
                D1 = Instantiate(Dummy, new Vector3(1700, 1200, 0), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                D2 = Instantiate(Dummy, new Vector3(980, 1000, 0), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                D3 = Instantiate(Dummy, new Vector3(2420, 1000, 0), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
            }
            if (transform.GetChild(6).gameObject.activeInHierarchy == true)
            {
                Destroy(D1);
                Destroy(D2);
                Destroy(D3);
            }
            if (transform.GetChild(7).gameObject.activeInHierarchy == true)
            {
                WaveManager.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    public void EndTutorial()
    {
        Variables.Pause = false;
        WaveManager.SetActive(true);
        gameObject.SetActive(false);
    }
}
