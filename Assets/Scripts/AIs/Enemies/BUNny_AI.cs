using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUNny_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement 
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool WithinField;
    public Vector2 MoveSpeed;

    private void Start()
    {
        Health = 25;
    }

    void Update()
    {
        //BUNny's movement and stops if the game is paused
        if (Variables.Pause == false)
        {
            transform.Translate(MoveSpeed.x * Time.deltaTime, MoveSpeed.y * Time.deltaTime, 0);
            //If the player can see it, it starts shooting
            if (WithinField)
            {
                InvisTimer += 1 * Time.deltaTime;

                if (InvisTimer >= 2)
                {
                    HomingBulletAttack();
                    InvisTimer = 0;
                }
            }
        }
    }
    void DeathCheck()
    {
        //Removes the enemy once killed and add to score
        if(Health <= 0)
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
        if (collision.gameObject.CompareTag("BoundingBox"))
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
        //Stops shooting when out of players view
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }


    void HomingBulletAttack()
    {
        //Finds the player position and then changes the angle depending on where they are relative to the player
        Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
    }
}
