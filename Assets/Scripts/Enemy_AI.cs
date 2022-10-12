using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public GameObject Bullet;
    public GameObject BulletStorage;
    public int Health;
    public float InvisTimer;

    public void Start()
    {
        Health = Random.Range(5, 20);
    }

    void Update()
    {
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        if (InvisTimer >= 5)
        {
            Instantiate(Bullet, transform.position, transform.rotation, BulletStorage.transform);
            InvisTimer = 1;
        }
        if (InvisTimer >= 1.24f && InvisTimer <= 1.27f)
        {
            Instantiate(Bullet, transform.position, transform.rotation, BulletStorage.transform);
        }
        //It's invincibility timer
        if (InvisTimer >= 0.75f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }



    void DeathCheck()
    {
        //Removes the enemy once killed
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Same as player where the character cant be hit for a bit and loses health
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            InvisTimer = 0;
            Health -= 1;
            //Also checks if the enemy is dead
            DeathCheck();
        }
    }
}
