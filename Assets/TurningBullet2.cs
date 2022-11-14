using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningBullet2 : MonoBehaviour
{
    public float Timer;
    public int BulletSpeedInt;
    private Vector3 originalPosition;
    public int Direction;

    private void Start()
    {
        originalPosition = transform.position;

        transform.Translate(0, BulletSpeedInt * 10 * Direction * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = originalPosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.Translate(0 , BulletSpeedInt * Direction * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle + 10 * Direction);
    }
}

