using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSpiral : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public GameObject BulletReverse;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool WithinField;
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
        if (collision.gameObject.CompareTag("EndPos") && WithinField == false)
        {
            animator.SetTrigger("Popup");
            Moving = false;
            MoveSpeed = 450f;
            WithinField = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = false;
        }
    }


    IEnumerator Explode()
    {
        for (int j = 0; j < 1; j++)
        {
            for (int i = 0; i < 12; i++)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 30), GameObject.Find("ProjectileStorage").transform);
                Instantiate(BulletReverse, transform.position, Quaternion.Euler(0, 0, i * 30), GameObject.Find("ProjectileStorage").transform);
            }
            yield return new WaitForSeconds(0.10f);
        }
    }
}