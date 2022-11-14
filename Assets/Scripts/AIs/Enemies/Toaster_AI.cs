using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public GameObject BulletReverse;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool Stopped;
    public int ShootTimes;
    public int ShootMovment;
    public float MoveSpeed;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(1000, 1000);
        Moving = true;
        ShootMovment = Random.Range(1, 10);
        MoveSpeed = 150f;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(8, 8);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            if (ShootTimes != ShootMovment - 1)
            {

                StartCoroutine(Explode());
            }
            InvisTimer = 1;
            ShootTimes += 1;
        }
        //Once shootTimes is as many as the random chance said it should shoot, it will start to move again
        if (ShootTimes == ShootMovment)
        {
            Moving = true;
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
            animator.SetTrigger("Popup");
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




    IEnumerator Explode()
    {
        int Mult = Variables.Difficulties;
        for (int i = 0; i < 9 * Mult; i++)
        {
            if (Variables.Difficulties > 0)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 40 / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 400;
                GameObject bBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, ((i * 40) + 20) / Mult), GameObject.Find("ProjectileStorage").transform);
                bBullet.GetComponent<TurningBullet>().BulletSpeedInt = 300;
            }
            if (Variables.Difficulties > 2)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 40 / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 500;
            }
            if (Variables.Difficulties > 3)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, ((i * 40)+20) / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 600;
            }

        }
            yield return new WaitForSeconds(0.10f);
    }
}