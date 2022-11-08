using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningBullet : MonoBehaviour
{
    public float Timer;
    public int BulletSpeedInt;
    //public Quaternion Angle;
    public float TEMP;
    private void Start()
    {
        TEMP = transform.rotation.z;
    }
    // Update is called once per frame
    void Update()
    {
        //Quaternion.Euler(0, 0, TEMP);
        //Vector3 Rotate = new(0, 0, transform.rotation.z + 10);
        //transform.Translate(0, BulletSpeedInt * Time.deltaTime, 0);
        //transform.transform.Rotate .z = 1;
        //transform.rotation = Quaternion.Euler(0, 0, TEMP + 1);
    }
}

