using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float Timer;
    public float BulletSpeedInt;
    // Update is called once per frame
    void Update()
    {
        if (Variables.Pause == false)
        {
            //Bullet with travel along the Y axis every frame
            transform.Translate(0, BulletSpeedInt * Time.deltaTime, 0);
        }
    }
}
