using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettings : MonoBehaviour
{
    public string SceneName;
    public int ProgressRequirement;

    //triggers when the script is started
    public void Start()
    {
        //checks if the current progress is less than the target
        if (Variables.Progress < ProgressRequirement)
        {
            //Removes the level listing from the menu
            gameObject.SetActive(false);
        }
        //checks if the current progress is equal to the target
        else if (Variables.Progress == ProgressRequirement)
        {
            //disactivates all objects used for scoring
            transform.Find("Score").gameObject.SetActive(false);
            transform.Find("Eats").gameObject.SetActive(false);
            transform.Find("Hits").gameObject.SetActive(false);
            transform.Find("Crown").gameObject.SetActive(false);
            transform.position = new(transform.position.x, transform.position.y, 0);
        }
        //checks if the current progress is more than the target
        else if (Variables.Progress > ProgressRequirement)
        {
            //finds the NEW sprite and disactivates it
            transform.Find("NEW").gameObject.SetActive(false);
            transform.position = new(transform.position.x, transform.position.y, 0);
        }
    }

    //function for when the play button is pressed
    public void PlayButton()
    {
        //loads the scene with the given name
        SceneManager.LoadScene(SceneName);
    }



}
