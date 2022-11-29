using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyaanCat_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool WithinField;
    public int ShootTimes;
    public int ShootMovment;
    public Vector2 MoveSpeed;
    public void Start()
    {
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(15, 50);
        Moving = true;
        ShootMovment = Random.Range(1, 10);
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(MoveSpeed.x * Time.deltaTime, MoveSpeed.y * Time.deltaTime, 0);
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(2, 6);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            if (ShootTimes != ShootMovment - 1)
            {
                TripleAttack();
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
            GameObject.Find("Canvas").GetComponent<ScoreUpKeep>().Score += 10;
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
        if (collision.gameObject.CompareTag("PlayField") && WithinField == false)
        {

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




    void TripleAttack()
    {
        Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 50), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 130), GameObject.Find("ProjectileStorage").transform);
    }
}
