using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtillaCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Same as player where the character cant be hit for a bit and loses health
            Destroy(collision.gameObject);
            GetComponentInParent<Turtilla_AI>().Health -= 1;
            //Also checks if the enemy is dead
            GetComponentInParent<Turtilla_AI>().DeathCheck();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
    }
    
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        //For snekzel Specifically, when he hits the bottom he will change forms
        if (collision.gameObject.CompareTag("BoundingBox") && GetComponentInParent<Turtilla_AI>().state == Turtilla_AI.BossPhase.PHASE_2)
        {
            GetComponentInParent<Transform>().gameObject.SetActive(false);
            GetComponentInParent<Transform>().GetChild(1).gameObject.SetActive(true);
            GetComponentInParent<Turtilla_AI>().UpdateHealth(90);
            GetComponentInParent<Turtilla_AI>().LeaveTransition = false;
            GetComponentInParent<Turtilla_AI>().InvisTimer = 0;
        }
    }
    */
}
