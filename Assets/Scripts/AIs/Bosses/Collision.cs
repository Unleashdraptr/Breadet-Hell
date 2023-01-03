using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Same as player where the character cant be hit for a bit and loses health
            Destroy(collision.gameObject);
            GetComponentInParent<Snekzel_AI>().Health -= 1;
            //Also checks if the enemy is dead
            GetComponentInParent<Snekzel_AI>().DeathCheck();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player took contact damage and is telling the player
            collision.gameObject.GetComponent<PlayerHealth>().BeenHit();
        }
        if (collision.gameObject.CompareTag("CosnumeMode"))
        {
            GetComponentInParent<Snekzel_AI>().Health -= 1;
            //Also checks if the enemy is dead
            GetComponentInParent<Snekzel_AI>().DeathCheck();
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        //For snekzel Specifically, when he hits the bottom he will change forms
        if (collision.gameObject.CompareTag("BoundingBox") && GetComponentInParent<Snekzel_AI>().state == Snekzel_AI.BossPhase.PHASE_2)
        {
            GetComponentInParent<Transform>().gameObject.SetActive(false);
            GetComponentInParent<Transform>().GetChild(1).gameObject.SetActive(true);
            GetComponentInParent<Snekzel_AI>().UpdateHealth(70);
            GetComponentInParent<Snekzel_AI>().LeaveTransition = false;
            GetComponentInParent<Snekzel_AI>().InvisTimer = 0;
        }
    }
}
