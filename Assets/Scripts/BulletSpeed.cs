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
        transform.Translate(0, 100*Time.deltaTime, 0);
    }
}
