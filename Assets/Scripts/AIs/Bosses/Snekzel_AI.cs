using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snekzel_AI : MonoBehaviour
{
    public enum BossPhase { PHASE_1, PHASE_2, PHASE_3, WIN, LOSE };
    public BossPhase state;
    public int Health;
    public float InvisTimer;
    float SaltDropTimer;
    float DropTime;
    public bool LeaveTransition;
    public bool Attacking;
    // Start is called before the first frame update
    void Start()
    {
        //Game will start by setting Snekzel's health to what it should be and the salt drop time
        state = BossPhase.PHASE_1;
        int TempHealth = 250;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (250 * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;
        DropTime = 1.25f;
    }
    void Update()
    {
        //Will stop if the game is paused
        if (Variables.Pause == false)
        {
            //Timer for all salt to drop
            SaltDropTimer += 1 * Time.deltaTime;
            //Makes it so Phase 2 is more consistent
            if (Attacking == false)
            {
                InvisTimer += 1 * Time.deltaTime;
            }

            //After the time period snekzel will perform his salth throw
            if (state == BossPhase.PHASE_1 && InvisTimer >= 2)
            {
                GetComponent<SnekzelAttackLibrary>().SaltThrow();
                InvisTimer = 0;
            }
            //After the time period snekzel will perform his charge across the screen
            if (state == BossPhase.PHASE_2 && InvisTimer >= 2)
            {
                Attacking = true;
                StartCoroutine(GetComponent<SnekzelAttackLibrary>().Screencharge());
                InvisTimer = 0;
            }
            //After the time period snekzel will perform his Tunneling that has a warning on it
            if (state == BossPhase.PHASE_3 && InvisTimer >= 4)
            {
                StartCoroutine(GetComponent<SnekzelAttackLibrary>().TunnelUp());
                InvisTimer = 0;
            }
            //After the time period salt will drop off of snekzel with the potential to hit the player
            if (SaltDropTimer >= DropTime && state != BossPhase.PHASE_3)
            {
                //Scales with difficulty
                for (int i = 0; i < Variables.Difficulties; i++)
                {
                    int SaltPos = Random.Range(1, gameObject.transform.GetChild(1).GetChild(0).childCount);
                    GetComponent<SnekzelAttackLibrary>().SaltDrop(gameObject.transform.GetChild(1).GetChild(0).GetChild(SaltPos));
                }
                SaltDropTimer = 0;
            }

            //Snekzel will charge the player at the end of Phase 2
            if (LeaveTransition == true && state == BossPhase.PHASE_2)
            {
                InvisTimer = 0;
                transform.Translate(0, -550 * Time.deltaTime, 0);
            }
        }
    }


    public void DeathCheck()
    {
        //Checks if its the final phase (Depends on difficulty)
        if (Health <= 0 && (state == BossPhase.PHASE_3 && Variables.Difficulties >= 3 && LeaveTransition == false) || Health <= 0 && (state == BossPhase.PHASE_2 && Variables.Difficulties <= 3 && LeaveTransition == false))
        {
            state = BossPhase.WIN;
            GameObject.Find("Canvas").GetComponent<GameState>().EnemyDead = true;
            Destroy(gameObject);
        }
        //When in the higher difficulties he will transistion to Phase 3
        if (Health <= 0 && state == BossPhase.PHASE_2 && LeaveTransition == false)
        {
            state = BossPhase.PHASE_3;
            LeaveTransition = true;
        }
        //Transition to Phase 2
        if (Health <= 0 && state == BossPhase.PHASE_1)
        {
            state = BossPhase.PHASE_2;
            LeaveTransition = true;
        }
    }

    //This function updates Snekzel's health everytime he transitions to the next phase
    public void UpdateHealth(int LowestHealth)
    {
        int TempHealth = LowestHealth;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (TempHealth * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;
        if (state == BossPhase.PHASE_2)
        {
            DropTime = 0.25f;
        }
    }
}
