using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
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
        animator = GetComponent<Animator>();
        Moving = true;
        Health = 30;
    }

    void Update()
    {
        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(MoveSpeed.x * Time.deltaTime, MoveSpeed.y * Time.deltaTime, 0);
            if (Targeting == true)
            {
                transform.Translate(MoveSpeed.x * 2 * Time.deltaTime, MoveSpeed.y * 2 * Time.deltaTime, 0);
            }
        }

        if (WithinField)
        {
            InvisTimer += 1 * Time.deltaTime;
        }
        if (InvisTimer >= 3)
        {
            Moving = false;
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
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = false;
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
            if (transform.position.x >= 2500)
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, transform.localRotation.y, -angle));
            }
            else
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, transform.localRotation.y, angle));
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
                Targeting = true;
                Moving = true;
                WithinField = false;
            }
        }
    }
}