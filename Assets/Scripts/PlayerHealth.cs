using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public float InvisTimer;

    public Animator animator;

    void Start()
    {
        Health = Variables.PlayerHealth[Variables.Difficulties - 1];
        if (Variables.PracticeMode == true)
        {
            Health = 20;
        }

        animator.SetInteger("HP", Health);

    }

    private void Update()
    {
        //Timer after getting hit, is shorter the higher the difficuly
        InvisTimer += 2 * Time.deltaTime;
        if(InvisTimer >= Variables.InvisTimer[Variables.Difficulties - 1])
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }





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
        //Checks if theyre dead
        DeathCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            //If a bullet hits the player they lose some health and can't be hit for a bit
            Destroy(collision.gameObject);
            BeenHit();
        }
    }
}

