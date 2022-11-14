using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningBullet : MonoBehaviour
{
    public float Timer;
    public int BulletSpeedInt;
    public float TurnAngle = 0.3f;

    // Update is called once per frame
    void Update()
    {
        TurnAngle = TurnAngle / 1.002f;
        transform.Translate(0, BulletSpeedInt * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + TurnAngle);
    }
}

