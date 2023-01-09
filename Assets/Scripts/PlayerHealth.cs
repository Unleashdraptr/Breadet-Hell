using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public float InvisTimer;
    public Button EatButton;

    public GameObject Scores;

    public Slider HungerTimer;
    public Slider Fullness;
    float CosNumeTimer;

    //public GameObject Container; Ignore this stuff, as unity decided to crash and i lost 2 hours of work
    //private Animator ContainerAnim;

    public Animator animator;

    void Start()
    {
        Health = Variables.PlayerHealth[Variables.Difficulties - 1];
        HungerTimer.value = Variables.HungerNum[Variables.Difficulties - 1];
        HungerTimer.maxValue = Variables.HungerNum[Variables.Difficulties - 1];
        if (Variables.PracticeMode == true)
        {
            Health = 20;
        }

        animator.SetInteger("HP", Health);

        //ContainerAnim = Container.GetComponent<Animator>();
    }

    private void Update()
    {
        if (gameObject.CompareTag("CosnumeMode"))
        {
            CosNumeTimer += 1 * Time.deltaTime;
        }

        if(InvisTimer >= Variables.InvisTimer[Variables.Difficulties - 1])
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if(Variables.Pause != true)
        {
            HungerTimer.value -= 1 * Time.deltaTime;
            InvisTimer += 2 * Time.deltaTime;
        }

        if(HungerTimer.value <= 0)
        {
            EatButton.gameObject.SetActive(true);
            //Container.gameObject.SetActive(false);
        }

        if(CosNumeTimer >= 20)
        {
            gameObject.tag = "Player";
            EatButton.gameObject.SetActive(false);
            //Container.gameObject.SetActive(true);
            HungerTimer.value = HungerTimer.maxValue;
            Fullness.value = 0;
            CosNumeTimer = 0;
        }
        //ContainerAnim.SetFloat("Fill", HungerTimer.value);
    }
    void ReduceHealth()
    {
        Health -= 1;
    }
    void DeathCheck()
    {
        //Destroys the player gameobject when its has 0HP, also updates the UI to tell the player and stop the game completely
        if (Health <= 0)
        {
            GameObject.Find("Canvas").GetComponent<GameState>().PlayerDead = true;
            Destroy(gameObject);
        }
    }

    public void BeenHit()
    {
        //animator.SetInteger("HP", Health);

        //Makes it so the player cant be hit anymore and reduces the players health
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        InvisTimer = 0;
        ReduceHealth();
        animator.SetInteger("HP", Health);
        //Checks if theyre dead
        DeathCheck();
    }

    public void FullnessCheck()
    {
        if(Fullness.value >= Fullness.maxValue)
        {
            gameObject.tag = "Player";
            EatButton.gameObject.SetActive(false);
            //Container.gameObject.SetActive(true);
            HungerTimer.value = HungerTimer.maxValue;
            Fullness.value = 0;
            CosNumeTimer = 0;
        }
    }

    public void ActivateEatMode()
    {
        gameObject.tag = "CosnumeMode";
        Fullness.value = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Bullet") && gameObject.CompareTag("Player"))
        {
            //If a bullet hits the player they lose some health and can't be hit for a bit
            Destroy(collision.gameObject);
            BeenHit();
        }
        if (collision.gameObject.CompareTag("Enemy_Bullet") && gameObject.CompareTag("CosnumeMode"))
        {
            Destroy(collision.gameObject);
            Fullness.value += 1;
            Scores.GetComponent<ScoreUpKeep>().ConScore += 1;
        }
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("CosnumeMode"))
        {
            Destroy(collision.gameObject);
            Fullness.value += 10;
            Scores.GetComponent<ScoreUpKeep>().ConScore += 10;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("CosnumeMode"))
        {
            Fullness.value += 1;
            collision.transform.GetComponentInParent<Snekzel_AI>().Health -= 1;
            Scores.GetComponent<ScoreUpKeep>().ConScore += 1;
        }
    }
}

