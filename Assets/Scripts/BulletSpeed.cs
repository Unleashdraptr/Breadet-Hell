using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float Timer;
    // Update is called once per frame
    void Update()
    {
        //Bullet with travel along the Y axis every frame
        transform.Translate(0, 1f, 0);
        //Tells the bullet to delete itself once it's far from the battle and no longer needed
        Timer += 1 * Time.deltaTime;
        if(Timer >= 10)
        {
            Destroy(this.gameObject);
        }
    }
}
