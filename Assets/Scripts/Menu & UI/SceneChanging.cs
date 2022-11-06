using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanging : MonoBehaviour
{
    //All difficulty names so they player can tell the difference
    public string[] DifficultyNames = {"Normal", "Toasty", "Burnt", "Breadendary" };
    //Loads into game
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    //Loads toi the Snekzel Boss Fight
    public void SnekzelButton()
    {
        SceneManager.LoadScene("Snekzel_Boss_Fight");
    }

    //Loads out of game & Resets the pause state
    public void QuitButton()
    {
        Variables.Pause = false;
        SceneManager.LoadScene("Menu");
    }
    //Updates the difficulty button for the player
    public void DifficultyButton()
    {
        Variables.Difficulties += 1;
        if(Variables.Difficulties > 4)
        {
            Variables.Difficulties = 1;
        }
        GameObject.Find("Difficulty Mode").GetComponent<TextMeshProUGUI>().text = DifficultyNames[Variables.Difficulties - 1];
    }
}
