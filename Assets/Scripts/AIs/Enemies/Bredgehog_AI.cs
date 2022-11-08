using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bredgehog_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool Stopped;
    public int ShootTimes;
    public int ShootMovment;
    public Vector2 MoveSpeed;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(15, 50);
        Moving = true;
        ShootMovment = Random.Range(1, 10);

        if (GameObject.Find("Spawners").transform.GetChild(2).GetComponent<WaveInfo>().directions == WaveInfo.Directions.Left)
        {
            MoveSpeed.x = -150;
        }
        if (GameObject.Find("Spawners").transform.GetChild(2).GetComponent<WaveInfo>().directions == WaveInfo.Directions.right)
        {
            MoveSpeed.x = 150;
        }
        if (GameObject.Find("Spawners").transform.GetChild(2).GetComponent<WaveInfo>().directions == WaveInfo.Directions.Up)
        {
            MoveSpeed.y = 150;
        }
        if (GameObject.Find("Spawners").transform.GetChild(2).GetComponent<WaveInfo>().directions == WaveInfo.Directions.Down)
        {
            MoveSpeed.y = -150;
        }
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
        int ShootDelay = Random.Range(4, 8);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            if (ShootTimes != ShootMovment - 1)
            {

                StartCoroutine(SpiralAttack());
            }
            InvisTimer = 1;
            ShootTimes += 1;
        }
        //Once shootTimes is as many as the random chance said it should shoot, it will start to move again
        if (ShootTimes == ShootMovment)
        {
            animator.SetTrigger("UnSpike");
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
            animator.SetTrigger("Spike");
            Moving = false;
            Stopped = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }




    IEnumerator SpiralAttack()
    {
        for (int i = 0; i < 25; i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180 + i * 20), GameObject.Find("ProjectileStorage").transform);
            if (Variables.Difficulties == 3 || Variables.Difficulties == 4)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90 + i * 20), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 270 + i * 20), GameObject.Find("ProjectileStorage").transform);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
}
