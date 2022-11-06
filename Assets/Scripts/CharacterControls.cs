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
        //Checks if the game has been paused
        if (Variables.Pause == false)
        {
            //Updates the reload time and gets the players position for the bullets to spawn
            Reload += 1 * Time.deltaTime;
            Vector2 Pos = new(transform.position.x, transform.position.y + 30);
            if (Input.touchCount > 0)
            {
                //Checks the distance between the character on screen and where the player has touched on the screen, this avoids teleporting
                Vector2 Player = new(transform.position.x, transform.position.y);
                float Distance = Vector2.Distance(Input.GetTouch(0).position, Player);
                if (Distance < 150)
                {
                    //This is the bounding box so the player cant go behind the UI or off screen 
                    if (Input.GetTouch(0).position.x <= 2910 && Input.GetTouch(0).position.x >= 735 && Input.GetTouch(0).position.y >= 20)
                    {
                        transform.position = new(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
                    }
                    //If it can shoot it will then fire 3 bullets off of the players position
                    if (Reload >= 0.1f)
                    {
                        Instantiate(Bullet, new(Pos.x + 40, Pos.y), Quaternion.identity, BulletStorage.transform);
                        Instantiate(Bullet, new(Pos.x, Pos.y + 40), Quaternion.identity, BulletStorage.transform);
                        Instantiate(Bullet, new(Pos.x - 40, Pos.y), Quaternion.identity, BulletStorage.transform);
                        Reload = 0;
                    }
                }
            }
        }
    }
}
