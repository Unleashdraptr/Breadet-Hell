using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool WithinField;
    private Animator animator;
    Animator ExplosionAnimator;

    public bool Exploded = false;

    public GameObject TimerObject;
    public GameObject Explosion;

    private int Defeated = 0;

    private float ToastProgress;
    private int Toastyness;

    public void Start()
    {
        ExplosionAnimator = Explosion.GetComponent<Animator>();
        animator = GetComponent<Animator>();
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = 50;

        ToastProgress = TimerObject.GetComponent<Timer>().totalTime / (Variables.Difficulties + 1);
        Toastyness = Variables.Difficulties;
    }

    void Update()
    {

        if (TimerObject.GetComponent<Timer>().countdown < (ToastProgress * Toastyness) - ToastProgress/3 && (Toastyness != 0))
        {
            print("toast");
            animator.SetTrigger("Toast");
            Toastyness--;
        }
        //its invinciblity frames and when it will shoot at certain times

        if (TimerObject.GetComponent<Timer>().countdown <= 0 && Exploded == false)
        {
            Exploded = true;
            StartCoroutine(Explode());
        }
    }
    void DeathCheck()
    {
        //Removes the enemy once killed
        if (Health == 0)
        {
            Defeated = 1;
            GameObject.Find("Score").GetComponent<ScoreUpKeep>().Score += 1;
            StartCoroutine(Explode());
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
        if (collision.gameObject.CompareTag("BoundingBox") && WithinField == false)
        {
            TimerObject.GetComponent<Timer>().StartTimer = true;
            WithinField = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }




    public IEnumerator Explode()
    {
        animator.SetTrigger("Popup");
        yield return new WaitForSeconds(1f);
        ExplosionAnimator.SetTrigger("Exploded");
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("Popup");
        yield return new WaitForSeconds(0.1f);
        int Mult = Variables.Difficulties;
        int IDK = 0;
        if(Variables.Difficulties == 1)
        {
            IDK = 1;
        }
        for (int i = 0; i < 9 * Mult; i++)
        {

            GameObject bBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, ((i * 40) + 20) / Mult), GameObject.Find("ProjectileStorage").transform);
            bBullet.GetComponent<TurningBullet>().BulletSpeedInt = 300;

            if (Variables.Difficulties + IDK - Defeated > 1)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 40 / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 400;
            }

            if (Variables.Difficulties - Defeated > 2)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, i * 40 / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 500;
            }
            if (Variables.Difficulties - Defeated > 3)
            {
                GameObject aBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, ((i * 40)+20) / Mult), GameObject.Find("ProjectileStorage").transform);
                aBullet.GetComponent<TurningBullet>().BulletSpeedInt = 600;
            }
        }
        yield return new WaitForSeconds(0.10f);
        Destroy(gameObject);
    }
}