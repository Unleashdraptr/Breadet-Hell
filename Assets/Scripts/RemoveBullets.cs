using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullets : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        //If a bullet hits the bounding box it will disappear.
        if (collision.gameObject.CompareTag("Enemy_Bullet") || collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If an enemy hits the bounding box it will disappear.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
