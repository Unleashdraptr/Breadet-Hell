using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bredgehog_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement 
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool WithinField;

    public Vector2 MoveSpeed;
    public Animator animator;
    private void Start()
    {
        //Sets health
        Health = 45;
    }
    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(MoveSpeed.x * Time.deltaTime, MoveSpeed.y * Time.deltaTime, 0);
        }
        if(WithinField)
        {
            InvisTimer += 1 * Time.deltaTime;
        }
        if (InvisTimer >= 4)
        {
            Moving = false;
            WithinField = false;
            StartCoroutine(SpiralAttack());
            InvisTimer = 0;
        }
    }
    void DeathCheck()
    {
        //Removes the enemy once killed and adds to the score
        if (Health == 0)
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
        if (collision.gameObject.CompareTag("CosnumeMode"))
        {
            Health -= 100000;
            //Also checks if the enemy is dead
            DeathCheck();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Stops shooting when outside the players view
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }




    IEnumerator SpiralAttack()
    {
        //Starts to the animation of Breadgehog curling up and then spams out his bullets in a spiral pattern
        animator.SetTrigger("Spike");
        yield return new WaitForSeconds(0.75f);
        for (int i = 0; i < 25; i++)
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180 + i * 20), GameObject.Find("ProjectileStorage").transform);
            if (Variables.Difficulties == 3 || Variables.Difficulties == 4)
            {
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90 + i * 20), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 270 + i * 20), GameObject.Find("ProjectileStorage").transform);
            }
            //To stagger them and not have a wall of bullets
            yield return new WaitForSeconds(0.15f);
        }
        //Uncurls and then starts to move again
        animator.SetTrigger("UnSpike");
        yield return new WaitForSeconds(0.75f);
        WithinField = true;
        Moving = true;
    }
}
