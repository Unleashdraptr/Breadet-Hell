using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
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
            Vector2 Player = new Vector2(transform.position.x, transform.position.y);
            float Distance = Vector2.Distance(Input.GetTouch(0).position, Player);
            if (Distance < 75)
            {
                if (Input.GetTouch(0).position.x <= 2485 && Input.GetTouch(0).position.x >= 460 && Input.GetTouch(0).position.y >= 20)
                {
                    transform.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
                
                }
                if (Reload >= 0.2f)
                {
                    Instantiate(Bullet, Pos, Quaternion.identity, BulletStorage.transform);
                    Reload = 0;
                }
            }
        }
    }
}
