using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement 
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool WithinField;
    public bool Moving;
    public Vector2 MoveSpeed;
    public bool Targeting;
    private Animator animator;

    public void Start()
    {
        //Sets up the animator and other components
        animator = GetComponent<Animator>();
        Moving = true;
        Health = 30;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target, then it charges at them
        if (Moving == true)
        {
            transform.Translate(MoveSpeed.x * Time.deltaTime, MoveSpeed.y * Time.deltaTime, 0);
            if (Targeting == true)
            {
                transform.Translate(MoveSpeed.x * 2 * Time.deltaTime, MoveSpeed.y * 2 * Time.deltaTime, 0);
            }
        }

        //If within field then it will start to shoot
        if (WithinField)
        {
            InvisTimer += 1 * Time.deltaTime;
        }
        if (InvisTimer >= 3)
        {
            Moving = false;
            WithinField = false;
            StartCoroutine(SnipeAttack());
            InvisTimer = 0;
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
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            animator.SetBool("Stalling", true);
            WithinField = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Stops shooting if outside of player's view
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = false;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }



    IEnumerator SnipeAttack()
    {
        //Calculates the amount of times it will shoot the hotdogs
        int ShootAmount = 1;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            ShootAmount *= 2;
        }
        //For the amount it will shoot
        for (int i = 0; i < ShootAmount; i++)
        {
            //Play an animate
            animator.SetTrigger("Reloading");
            yield return new WaitForSeconds(0.15f);
            //Find the player
            Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Figure out what side of the map its on
            Vector3 Pos = new(transform.position.x, transform.position.y, transform.position.z);
            if (transform.position.x >= 2500)
            {
                transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, transform.eulerAngles.y, 180-angle));
            }
            else
                transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z+angle));
            //Spawn the hot dog
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
            animator.SetTrigger("Shot");
            yield return new WaitForSeconds(0.15f);
        }
        //It will wait and check if its low enough on burnt and higher
        yield return new WaitForSeconds(0.5f);
        if (Variables.Difficulties >= 3 && Health < 25)
        {
            //Once angered, he will turn into a hot dog
            animator.SetBool("Angered", true);
        }
        yield return new WaitForSeconds(0.5f);
        //Sets up for his charging state
        animator.SetBool("Stalling", false);
        Targeting = true;
        Moving = true;
    }
}