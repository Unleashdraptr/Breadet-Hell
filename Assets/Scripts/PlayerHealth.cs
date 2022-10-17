using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    //Healthbar
    public Slider HealthNum;
    //Invinceiblity Frames
    public float InvisTimer;
    void Start()
    {
        //Sets healthbar in UI
        HealthNum.maxValue = Variables.PlayerHealth[Variables.Difficulties-1];
        HealthNum.value = Variables.PlayerHealth[Variables.Difficulties - 1];
    }
    private void Update()
    {
        //Timer after getting hit
        InvisTimer += 1 * Time.deltaTime;
        if(InvisTimer >= Variables.InvisTimer[Variables.Difficulties - 1])
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }


    void ReduceHealth()
    {
        //Reduces health on UI aswell as the value
        HealthNum.value -= 1;
    }
    void DeathCheck()
    {
        //Destroys the player gameobject when its has 0HP
        if (HealthNum.value <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet")
        {
            //If a bullet hits the player they lose some health and can't be hit for a bit
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            InvisTimer = 0;
            ReduceHealth();
            //Checks if theyre dead
            DeathCheck();
        }
    }
}

