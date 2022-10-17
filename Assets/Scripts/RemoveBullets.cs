using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullets : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
