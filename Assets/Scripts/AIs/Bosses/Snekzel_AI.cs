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
        state = BossPhase.PHASE_1;
        int TempHealth = 150;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (150 * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;
        DropTime = 1.25f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Variables.Pause == false)
        {
            SaltDropTimer += 1 * Time.deltaTime;
            if (Attacking == false)
            {
                InvisTimer += 1 * Time.deltaTime;
            }


            if (state == BossPhase.PHASE_1 && InvisTimer >= 2)
            {
                GetComponent<SnekzelAttackLibrary>().SaltThrow();
                InvisTimer = 0;
            }
            if (state == BossPhase.PHASE_2 && InvisTimer >= 5)
            {
                Attacking = true;
                StartCoroutine(GetComponent<SnekzelAttackLibrary>().Screencharge());
                InvisTimer = 0;
            }
            if (state == BossPhase.PHASE_3 && InvisTimer >= 4)
            {
                StartCoroutine(GetComponent<SnekzelAttackLibrary>().TunnelUp());
                InvisTimer = 0;
            }
            if (SaltDropTimer >= DropTime && state != BossPhase.PHASE_3)
            {
                int SaltPos = Random.Range(1, gameObject.transform.GetChild(1).GetChild(0).childCount);
                GetComponent<SnekzelAttackLibrary>().SaltDrop(gameObject.transform.GetChild(1).GetChild(0).GetChild(SaltPos));
                SaltDropTimer = 0;
            }



            if (LeaveTransition == true && state == BossPhase.PHASE_2)
            {
                transform.Translate(0, -550 * Time.deltaTime, 0);
            }
        }
    }


    public void DeathCheck()
    {
        if (Health <= 0 && (state == BossPhase.PHASE_3 && Variables.Difficulties >= 3 && LeaveTransition == false) || Health <= 0 && (state == BossPhase.PHASE_2 && Variables.Difficulties <= 3 && LeaveTransition == false))
        {
            state = BossPhase.WIN;
            GameObject.Find("Canvas").GetComponent<GameState>().SnekzelDead = true;
            Destroy(gameObject);
        }
        if (Health <= 0 && state == BossPhase.PHASE_2 && LeaveTransition == false)
        {
            state = BossPhase.PHASE_3;
            LeaveTransition = true;
        }
        if (Health <= 0 && state == BossPhase.PHASE_1)
        {
            state = BossPhase.PHASE_2;
            LeaveTransition = true;
        }
    }

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
