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
    public int ShootTimes;
    public int ShootMovment;
    public float MoveSpeed;
    public bool Targeting;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(30, 30);
        Moving = true;
        ShootMovment = Random.Range(1, 10);
        MoveSpeed = 150f;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true && Targeting == true)
        {
            transform.Translate(MoveSpeed * 3 * Time.deltaTime, 0, 0);
        }
        else if (Moving == true)
        {
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(6, 6);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            //To remove spamming the 5th Attack when moving off screen
            if (ShootTimes != ShootMovment - 1)
            {
                StartCoroutine(SnipeAttack());
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
            animator.SetBool("Stalling", true);
            Moving = false;
            MoveSpeed = 450f;
            Stopped = true;
        }
    }




    IEnumerator SnipeAttack()
    {
        int ShootAmount = 1;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            ShootAmount *= 2;
        }
        for (int i = 0; i <= ShootAmount; i++)
        {
            animator.SetTrigger("Reloading");
            yield return new WaitForSeconds(0.15f);
            Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, angle));
            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
            animator.SetTrigger("Shot");
            yield return new WaitForSeconds(0.15f);

            if (i == ShootAmount)
            {
                yield return new WaitForSeconds(0.5f);
                if (Variables.Difficulties >= 3 && Health < 25)
                    animator.SetBool("Angered", true);
                yield return new WaitForSeconds(0.5f);
                animator.SetBool("Stalling", false);
                Moving = true;
                Targeting = true;
            }
        }
    }
}