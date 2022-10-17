using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    //Enemy_AI that can shoot and contains health
    public int Health;
    public float InvisTimer;
    public bool Moving;
    public void Start()
    {
        Health = Random.Range(3, 15);
        Moving = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if(Moving == true)
        {
            transform.Translate(0, 0.5f, 0);
            float GhostingTime = Random.Range(1, 30);
            GhostingTime -= 1 * Time.deltaTime;
            if(GhostingTime <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        //its invinciblity frames and when it will shoot at certain times
        InvisTimer += 1 * Time.deltaTime;
        int ShootDelay = Random.Range(2,10);
        if (InvisTimer >= ShootDelay && Moving == false)
        {
            int RandomAttack = Random.Range(1, 6);
            if(RandomAttack == 1)
            {
                GetComponentInParent<BulletAttackLibrary>().Attack1(gameObject);
            }
            if (RandomAttack == 2)
            {
                GetComponentInParent<BulletAttackLibrary>().Attack2(gameObject);
            }
            if (RandomAttack == 3)
            {
                GetComponentInParent<BulletAttackLibrary>().Attack3(gameObject);
            }
            if (RandomAttack == 4)
            {
                GetComponentInParent<BulletAttackLibrary>().Attack4(gameObject);
            }
            if (RandomAttack == 5)
            {
                StartCoroutine(GetComponentInParent<BulletAttackLibrary>().Attack5(gameObject));
            }
            Debug.Log(RandomAttack);
            InvisTimer = 1;
        }
        //It's invincibility timer
        if (InvisTimer >= 0.1f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }



    void DeathCheck()
    {
        //Removes the enemy once killed
        if(Health <= 0)
        {
            GameObject.Find("Score").GetComponent<ScoreUpKeep>().Score += 1;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndPos")
        {
            Moving = false;
        }
    }
}
