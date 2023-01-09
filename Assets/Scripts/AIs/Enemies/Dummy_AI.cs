using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_AI : MonoBehaviour
{
    //Health and AI necessities needed for movement
    public int Health;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        //Sets up all the stats and gets the enemy moving to its location to fire
        Health = 50;
    }
    void DeathCheck()
    {
        //Removes the enemy once killed
        if (Health == 0)
        {
            StartCoroutine(Die());
            //GameObject.Find("Canvas").GetComponent<ScoreUpKeep>().Score += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && Health > 0)
        {
            //Same as player where the character cant be hit for a bit and loses health
            Destroy(collision.gameObject);
            Health -= 1;
            //Also checks if the enemy is dead
            DeathCheck();
        }
    }

    public IEnumerator Die()

    {
        animator.SetTrigger("Defeat");
        yield return new WaitForSeconds(2.0f);
        animator.SetTrigger("Revive");
        Health = 30;
    }
}