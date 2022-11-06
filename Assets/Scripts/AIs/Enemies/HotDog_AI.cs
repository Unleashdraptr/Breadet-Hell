using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool Stopped;
    public int ShootMovment;
    public float MoveSpeed;
    public void Start()
    {
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(15, 50);
        Moving = true;
        MoveSpeed = 150f;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        { 
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(4, 8);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            StartCoroutine(SnipeAttack());
            InvisTimer = 1;
        }
    }
    void DeathCheck()
    {
        //Removes the enemy once killed
        if (Health <= 0)
        {
            GameObject.Find("Score").GetComponent<ScoreUpKeep>().Score += 1;
            Destroy(gameObject);
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

        //Checks if it the enemy has hit its intented target to start shooting.
        if (collision.gameObject.CompareTag("EndPos") && Stopped == false)
        {
            Moving = false;
            MoveSpeed = 450f;
            Stopped = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }




    IEnumerator SnipeAttack()
    {
        int ShootAmount = 1;
        bool Shot = false;
        float angle = 0;
        for (int i =0; i < Variables.Difficulties-1; i++)
        {
            ShootAmount *= 2;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.3f);
            if(i == ShootAmount)
            {
                Shot = true;
                break;
            }
            
        }
        if (Shot == true)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, angle - 90));
            Moving = true;
        }
    }
}