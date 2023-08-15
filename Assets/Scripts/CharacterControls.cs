using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    //The bullet and where its stored in the heiarchy for cleaness sake
    public GameObject Bullet;
    private Animator animator;
    public Vector2 dir;
    public Vector2 PrevPosition;
    float Reload;
    void Update()
    {
        if (Variables.Pause == false)
        {
            animator = GetComponent<Animator>();
            Reload += 1 * Time.deltaTime;
            Vector2 Pos = new(transform.position.x, transform.position.y + 30);
            //Spawns the bullet at the player everytime the screen is touched (Work in progress)
            if (Input.GetMouseButton(0))
            {

                if (PrevPosition.x != 0 && PrevPosition.y != 0)
                {
                    float Distance = Vector2.Distance(Input.mousePosition, PrevPosition);
                    if (Distance < 2000)
                    {
                        dir.x = Input.mousePosition.x - PrevPosition.x;
                        dir.y = Input.mousePosition.y - PrevPosition.y;
                        //Animator Direction
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        if (angle < 0)
                            angle = 360 - angle * -1;
                        animator.SetFloat("Angle", angle);
                        if (transform.position.x + dir.x <= 700)
                        {
                            dir.x = 0;
                        }
                        else if (transform.position.x + dir.x >= 2650)
                        {
                            dir.x = 0;
                        }
                        if (transform.position.y + dir.y >= 1400)
                        {
                            dir.y = 0;
                        }
                        else if (transform.position.y + dir.y <= 100)
                        {
                            dir.y = 0;
                        }
                        transform.position = new(transform.position.x + dir.x, transform.position.y + dir.y);
                        PrevPosition = Input.mousePosition;


                        if (Reload >= 0.1f && gameObject.CompareTag("Player"))
                        {
                            Instantiate(Bullet, new(Pos.x + 40, Pos.y), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                            Instantiate(Bullet, new(Pos.x, Pos.y + 40), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                            Instantiate(Bullet, new(Pos.x - 40, Pos.y), Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
                            Reload = 0;
                        }
                    }
                }
                else
                    PrevPosition = Input.mousePosition;
            }
            else
                PrevPosition = new(0, 0);
        }
    }
}
