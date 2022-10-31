using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snekzel_AI : MonoBehaviour
{
    public enum BossPhase { PHASE1, PHASE2, PHASE3, WIN, LOSE };
    public BossPhase state;
    public int Health;
    public float InvisTimer;
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
    }

    // Update is called once per frame
    void Update()
    {

    }


    void DeathCheck()
    {
        if (Health <= 0 && (state == BossPhase.PHASE3 && Variables.Difficulties >= 3) || Health <= 0 && (state == BossPhase.PHASE2 && Variables.Difficulties <= 3))
        {
            state = BossPhase.WIN;
            Destroy(gameObject);
        }
        else

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
            int TempHealth = 130;
            for (int i = 0; i < Variables.Difficulties - 1; i++)
            {
                TempHealth += (TempHealth * Variables.BossMultiplers[0]) / 100;
            }
            Health = TempHealth;
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
}
