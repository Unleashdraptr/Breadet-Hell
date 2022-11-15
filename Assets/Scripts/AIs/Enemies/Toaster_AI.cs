using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public bool WithinField;
    public int ShootTimes;
    public int ShootMovment;
    public float MoveSpeed;
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
        Health = Random.Range(50, 50);
        Moving = true;
        ShootMovment = Random.Range(1, 10);
        MoveSpeed = 150f;


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

        //Tells the enemy to move unless it hits its target
        if (Moving == true)
        {
            transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
        }
        //its invinciblity frames and when it will shoot at certain times

        if (TimerObject.GetComponent<Timer>().countdown <= 0 && Exploded == false)
        {
            Exploded = true;
            StartCoroutine(Explode());
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
        //Destroy(this);
        yield return new WaitForSeconds(0.10f);
        Destroy(gameObject);
    }
}