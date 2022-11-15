using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    //The bullet and where its stored in the heiarchy for cleaness sake
    public GameObject Bullet;
    private Animator animator;
    float Reload;
    void Update()
    {
        if (Variables.Pause == false)
        {
            animator = GetComponent<Animator>();
            Reload += 1 * Time.deltaTime;
            Vector2 Pos = new(transform.position.x, transform.position.y + 30);
            //Spawns the bullet at the player everytime the screen is touched (Work in progress)
            if (Input.touchCount > 0)
            {
                Vector2 Player = new(transform.position.x, transform.position.y);
                float Distance = Vector2.Distance(Input.GetTouch(0).position, Player);
                if (Distance < 200)
                {
                    if (Input.GetTouch(0).position.x <= 2910 && Input.GetTouch(0).position.x >= 735 && Input.GetTouch(0).position.y >= 20)
                    {
                        //Animator Direction
                        Vector3 dir = new(Input.GetTouch(0).position.x - transform.position.x, Input.GetTouch(0).position.y - transform.position.y);
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        if (angle < 0)
                            angle = 360 - angle * -1;
                        animator.SetFloat("Angle", angle);

                        transform.position = new(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
                    }
                    if (Reload >= 0.1f)
                    {
                        Instantiate(Bullet, new(Pos.x + 40, Pos.y), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                        Instantiate(Bullet, new(Pos.x, Pos.y + 40), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                        Instantiate(Bullet, new(Pos.x - 40, Pos.y), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                        Reload = 0;
                    }
                }
            }
        }
    }
}
