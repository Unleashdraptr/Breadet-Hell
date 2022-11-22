using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snekzlette_AI : MonoBehaviour
{
    public GameObject Bullet;
    public bool Charge;
    public float Delay;
    public int Health;
    public float DropDelay;
    readonly float[] Speeeeed = { 1000, 1333, 1666, 2000 }; 
    private void Start()
    {
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = Random.Range(15, 50);
    }
    // Update is called once per frame
    void Update()
    {
        if (Charge == false)
        {
            Delay += 1 * Time.deltaTime;
        }
        if (Delay >= 0.5f && Charge == false)
        {
            StartCoroutine(GetComponent<SnekzelAttackLibrary>().Screencharge(false));
            Vector3 dir = GameObject.Find("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (transform.position.x >= 2500)
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z - angle));
            }
            else
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z+angle));
            Delay = 0;
            Charge = true;
        }
        if (Charge == true)
        {
            transform.Translate(Speeeeed[Variables.Difficulties-1] * Time.deltaTime, 0, 0);
            if(DropDelay >= (0.75/Variables.Difficulties))
            {
                DropDelay = 0;
                Instantiate(Bullet, transform.position, Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
            }
            DropDelay += 1 * Time.deltaTime;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Charge = false;
        }
    }
}
