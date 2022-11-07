using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettings : MonoBehaviour
{
    public string SceneName;
    public int ProgressRequirement;

    public void Start()
    {
        if (Variables.Progress < ProgressRequirement)
        {
            Destroy(gameObject);
        }
        else if (Variables.Progress == ProgressRequirement)
        {
            transform.Find("Score").gameObject.SetActive(false);
            transform.Find("Eats").gameObject.SetActive(false);
            transform.Find("Hits").gameObject.SetActive(false);
            transform.Find("Crown").gameObject.SetActive(false);
        }
        else if (Variables.Progress > ProgressRequirement)
        {
            transform.Find("NEW").gameObject.SetActive(false);
        }

    }

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneName);
    }



}
