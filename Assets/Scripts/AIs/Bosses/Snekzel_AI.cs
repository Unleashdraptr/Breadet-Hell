using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snekzel_AI : MonoBehaviour
{
    public enum BossPhase { PHASE1, PHASE2, PHASE3, WIN, LOSE };
    public BossPhase state;
    public int Health;
    public float InvisTimer;
    float SaltDropTimer;
    float DropTime;
    bool Drop;
    public bool LeaveTransition;
    public bool Phase2Transition;
    // Start is called before the first frame update
    void Start()
    {
        state = BossPhase.PHASE1;
        int TempHealth = 150;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (150 * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;
        DropTime = 1.25f;
        Drop = true;
    }
    // Update is called once per frame
    void Update()
    {
        SaltDropTimer += 1 * Time.deltaTime;
        InvisTimer += 1 * Time.deltaTime;
        if(state == BossPhase.PHASE1 && InvisTimer >= 2)
        {
            GetComponent<SnekzelAttackLibrary>().SaltThrow();
            InvisTimer = 0;
        }
        if (state == BossPhase.PHASE2 && InvisTimer >= 4 && Phase2Transition == true)
        {
            Debug.Log("CHARGE");
            GetComponent<SnekzelAttackLibrary>().Screencharge();
            InvisTimer = 0;
        }


        if (SaltDropTimer >= DropTime && Drop == true)
        {
            int SaltPos = Random.Range(1, gameObject.transform.GetChild(0).childCount);
            GetComponent<SnekzelAttackLibrary>().SaltDrop(gameObject.transform.GetChild(0).GetChild(SaltPos));
            SaltDropTimer = 0;
        }

        



        if(LeaveTransition == true)
        {
            transform.Translate(0, -550 * Time.deltaTime, 0);
        }
    }


    void DeathCheck()
    {
        if (Health <= 0 && (state == BossPhase.PHASE3 && Variables.Difficulties >= 3) || Health <= 0 && (state == BossPhase.PHASE2 && Variables.Difficulties <= 3))
        {
            state = BossPhase.WIN;
            Destroy(gameObject);
        }
        if (Health <= 0 && state == BossPhase.PHASE2)
        {
            state = BossPhase.PHASE3;
            UpdatePhase();
        }
        if (Health <= 0 && state == BossPhase.PHASE1)
        {
            state = BossPhase.PHASE2;
            UpdatePhase();
        }
    }

    void UpdatePhase()
    {
        if (state == BossPhase.PHASE2)
        {
            LeaveTransition = true;
            int TempHealth = 130;
            for (int i = 0; i < Variables.Difficulties - 1; i++)
            {
                TempHealth += (TempHealth * Variables.BossMultiplers[0]) / 100;
            }
            Health = TempHealth;
            DropTime = 0.25f;
            Drop = false;
        }

        if (state == BossPhase.PHASE3)
        {
            int TempHealth = 30;
            for (int i = 0; i < Variables.Difficulties - 1; i++)
            {
                TempHealth += (30 * Variables.BossMultiplers[0]) / 100;
            }
            Health = TempHealth;
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Same as player where the character cant be hit for a bit and loses health
            Destroy(collision.gameObject);
            Health -= 1;
            //Also checks if the enemy is dead
            DeathCheck();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BoundingBox"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            LeaveTransition = false;
            Phase2Transition = true;
            InvisTimer = 0;
        }
    }
}
