using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public bool EnemyDead;
    public bool PlayerDead;
    public int NextLevel;

    // Update is called once per frame
    void Update()
    {
        //Will go to a win state if Snekzel is dead
        if(EnemyDead == true)
        {
            Debug.Log("Won: " + Variables.Progress);
            if(NextLevel - 1 == Variables.Progress)
            {
                Debug.Log("Next Level");
                Variables.Progress += 1;
            }
            Debug.Log("After: " + Variables.Progress);
            Variables.Pause = true;
            transform.GetChild(1).gameObject.SetActive(true);
        }
        //Will go to a lose state if the player is dead, also tells the player what phase they were on when they died
        if (PlayerDead == true)
        {
            Variables.Pause = true;
            if (Variables.BossFight == true)
            {
                transform.GetChild(3).GetComponent<TextMeshProUGUI>().SetText(GameObject.Find("Snekzel").GetComponent<Snekzel_AI>().state.ToString());
            }
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
