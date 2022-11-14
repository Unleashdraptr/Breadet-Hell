using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyannBullet : MonoBehaviour
{
    public float Timer;
    public int BulletSpeedInt;
    private Quaternion Angle;

    private void Start()
    {
        Angle = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        Angle = new(Angle.x, Angle.y, Angle.z + 0.02f, Angle.w);
        //Bullet with travel along the Y axis every frame
        transform.localRotation= Angle;
        transform.Translate(0, BulletSpeedInt * Time.deltaTime, 0);
    }
}
