using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //The bullet and where its stored in the heiarchy for cleaness sake
    public GameObject Bullet;
    public GameObject BulletStorage;
    float Reload;
    void Update()
    {
        Reload += 1 * Time.deltaTime;
        Vector2 Pos = new Vector3(transform.position.x, transform.position.y+25, transform.position.z);
        //Spawns the bullet at the player everytime the screen is touched (Work in progress)
        if (Input.touchCount > 0)
        {
            transform.SetPositionAndRotation(Input.GetTouch(0).position, transform.rotation);
            if (Reload >= 0.2f)
            {
                Instantiate(Bullet, Pos, Quaternion.identity, BulletStorage.transform);
                Reload = 0;
            }
        }
    }
}
