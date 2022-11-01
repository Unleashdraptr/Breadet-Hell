using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekzelAttackLibrary : MonoBehaviour
{
    public GameObject Player;
    public GameObject Salt;
    public void SaltThrow()
    {
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 60), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 70), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 80), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 90), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 100), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 110), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Salt, transform.position, Quaternion.Euler(0, 0, angle - 120), GameObject.Find("ProjectileStorage").transform);
    }

    public void SaltDrop(Transform SaltShaker)
    {
        Instantiate(Salt, SaltShaker.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
    }

    public void Screencharge()
    {
        int ScreenWidth = Random.Range(20, Screen.width - 50);
        Vector2 Pos = new(0, ScreenWidth);
        int Screenside = Random.Range(1, 2);
        if (Screenside == 1)
        {
            Pos.x = 200;
            Pos.x = Screen.height + 100;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 180));
        }
        if(Screenside == 2)
        {
            Pos.x = Screen.height + 100;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        }
    }

    public void TunnelUp()
    {

    }
}
