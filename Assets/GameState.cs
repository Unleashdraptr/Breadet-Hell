using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool SnekzelDead;
    public bool PlayerDead;

    // Update is called once per frame
    void Update()
    {
        if(SnekzelDead == true)
        {
            Variables.Pause = true;
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (PlayerDead == true)
        {
            Variables.Pause = true;
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
