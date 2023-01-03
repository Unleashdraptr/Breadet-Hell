using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snekzlette_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement 
    public GameObject Bullet;
    public bool Charge;
    public float Delay;
    public int Health;
    public bool WithinField;
    public float DropDelay;
    //His speed in each difficulty
    readonly float[] Speeeeed = { 1000, 1333, 1666, 2000 };
    private void Start()
    {
        Health = 75;
    }
    void Update()
    {
        if (Charge == false)
        {
            Delay += 1 * Time.deltaTime;
        }
        if (Delay >= 0.5f && Charge == false)
        {
            //Gets the Snekzel attack position placer but tells it to not activate the charge that snekzel will use
            StartCoroutine(GetComponent<SnekzelAttackLibrary>().Screencharge(false));
            //Then finds the player and does its own charge
            Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 Pos = new(transform.position.x, transform.position.y, -1f);
            //its angle based off its position
            if (transform.position.x >= 2500)
            {
                transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, transform.eulerAngles.y, 180-angle));
            }
            else
                transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z+angle));
            Delay = 0;
            Charge = true;
        }
        //Uses its own charge
        if (Charge == true)
        {
            //Speed based off difficulty
            transform.Translate(Speeeeed[Variables.Difficulties-1] * Time.deltaTime, 0, 0);
            //If the player can see it, he drops his special bullets
            if (WithinField)
            {
                if (DropDelay >= (0.75 / Variables.Difficulties))
                {
                    DropDelay = 0;
                    Instantiate(Bullet, transform.position, Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                }
                DropDelay += 1 * Time.deltaTime;
            }
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
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
        //If the player can see them, they'll charge
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            WithinField = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Once the player cant see them, they stop charging and reset themselves
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Charge = false;
            WithinField = false;
        }
    }
}
