using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanging : MonoBehaviour
{
    //Loads into game
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    //Loads out of game
    public void QuitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    //Create new variables to hold the button game objects
    GameObject Normal;
    GameObject Toasty;
    GameObject Burnt;
    GameObject Breadendary;

    //only occurs once when the scene starts
    private void Start()
    {
        //Setting the variables as the game objects now
        //Important to do here, otherwise script can't find them when SetActive is false
        Normal = GameObject.Find("Normal");
        Toasty = GameObject.Find("Toasty");
        Burnt = GameObject.Find("Burnt");
        Breadendary = GameObject.Find("Breadendary");
    }
    void Update()
    {
        //Checks the difficulty 1-Normal, 2-Toasty, 3-Burnt, 4-Breadendary
        if (Variables.Difficulties == 1)
        {
            //Sets all the buttons apart from the clicked button to true
            Normal.SetActive(false);
            Toasty.SetActive(true);
            Burnt.SetActive(true);
            Breadendary.SetActive(true);
        }
        else if (Variables.Difficulties == 2)
        {
            Normal.SetActive(true);
            Toasty.SetActive(false);
            Burnt.SetActive(true);
            Breadendary.SetActive(true);
        }
        else if (Variables.Difficulties == 3)
        {
            Normal.SetActive(true);
            Toasty.SetActive(true);
            Burnt.SetActive(false);
            Breadendary.SetActive(true);
        }
        else if (Variables.Difficulties == 4)
        {
            Normal.SetActive(true);
            Toasty.SetActive(true);
            Burnt.SetActive(true);
            Breadendary.SetActive(false);
        }
    }


    //Functions called when clicking the buttons
    public void NormalButton()
    {
        Variables.Difficulties = 1;
    }
    public void ToastyButton()
    {
        Variables.Difficulties = 2;
    }
    public void BurntButton()
    {
        Variables.Difficulties = 3;
    }
    public void BreadendaryButton()
    {
        Variables.Difficulties = 4;
    }
}
