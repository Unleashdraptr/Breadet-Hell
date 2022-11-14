using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningBullet : MonoBehaviour
{
    public float Timer;
    public int BulletSpeedInt;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeedInt * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 0.2f);
    }
}

