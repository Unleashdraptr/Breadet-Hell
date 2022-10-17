using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool Stopped;
    public int ShootTimes;
    public int ShootMovment;
    public float MoveSpeed;
    public void Start()
    {
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(3, 15);
        Moving = true;
        ShootMovment = Random.Range(1, 10);
        MoveSpeed = 0.5f;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(0, MoveSpeed, 0);
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(Variables.ShootDelayMin[Variables.Difficulties-1], Variables.ShootDelayMax[Variables.Difficulties-1]);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            if (ShootTimes != ShootMovment - 1)
            {
                int RandomAttack = Random.Range(1, 100);
                if (RandomAttack >= 1 && RandomAttack < Variables.Attack1Chances[Variables.Difficulties - 1])
                {
                    GetComponentInParent<BulletAttackLibrary>().Attack1(gameObject);
                }
                if (RandomAttack >= Variables.Attack1Chances[Variables.Difficulties - 1] && RandomAttack < Variables.Attack2Chances[Variables.Difficulties - 1])
                {
                    StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack2(gameObject));
                }
                if (RandomAttack >= Variables.Attack2Chances[Variables.Difficulties - 1] && RandomAttack < Variables.Attack3Chances[Variables.Difficulties - 1])
                {
                    StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack3(gameObject));
                }
                if (RandomAttack >= Variables.Attack3Chances[Variables.Difficulties - 1] && RandomAttack < Variables.Attack4Chances[Variables.Difficulties - 1])
                {
                    StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack4(gameObject));
                }
                if (RandomAttack >= Variables.Attack5Chances[Variables.Difficulties - 1])
                {
                    StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack5(gameObject));
                }
            }
            //It will instead shoot 2nd attack as it leaves
            if (ShootTimes == ShootMovment - 1)
            {
                StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack2(gameObject));
            }
                InvisTimer = 1;
                ShootTimes += 1;
        }
        //Once shootTimes is as many as the random chance said it should shoot, it will start to move again
        if(ShootTimes == ShootMovment)
        {
            Moving = true;
        }
        //It's invincibility timer
        if (InvisTimer >= 0.1f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }



    void DeathCheck()
    {
        //Removes the enemy once killed
        if(Health <= 0)
        {
            GameObject.Find("Score").GetComponent<ScoreUpKeep>().Score += 1;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Same as player where the character cant be hit for a bit and loses health
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            InvisTimer = 0;
            Health -= 1;
            //Also checks if the enemy is dead
            DeathCheck();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if it the enemy has hit its intented target to start shooting.
        if (collision.gameObject.tag == "EndPos" && Stopped == false)
        {
            Moving = false;
            MoveSpeed = 1.5f;
            Stopped = true;
        }
    }
}
