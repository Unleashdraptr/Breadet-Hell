using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public bool EnemyDead;
    public bool PlayerDead;

    // Update is called once per frame
    void Update()
    {
        //Will go to a win state if Snekzel is dead
        if(EnemyDead == true)
        {
            Variables.Pause = true;
            transform.GetChild(2).gameObject.SetActive(true);
        }
        //Will go to a lose state if the player is dead, also tells the player what phase they were on when they died
        if (PlayerDead == true)
        {
            Variables.Pause = true;
            if (Variables.BossFight == true)
            {
                transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("Snekzel").GetComponent<Snekzel_AI>().state.ToString());
            }
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
