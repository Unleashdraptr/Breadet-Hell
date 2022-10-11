using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //The bullet and where its stored in the heiarchy for cleaness sake
    public GameObject Bullet;
    public GameObject BulletStorage;
    void Update()
    {
        //Spawns the bullet at the player everytime the screen is touched (Work in progress)
        if(Input.touchCount > 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity, BulletStorage.transform);
        }
    }
}
