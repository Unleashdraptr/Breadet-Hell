using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekzelAttackLibrary : MonoBehaviour
{
    public GameObject Player;
    public GameObject Salt;
    public bool Charge;
    int ShootDelay = 0;
    float ShootTime = 0;

    void Update()
    {
        if (Charge == true)
        {
            transform.Translate(2500 * Time.deltaTime, 0, 0);
            ShootDelay += 1;
            if (ShootDelay == 10)
            {
                Instantiate(Salt, gameObject.transform.GetChild(1).GetChild(0).GetChild(2).position, Quaternion.Euler(0, 0, 120), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Salt, gameObject.transform.GetChild(1).GetChild(0).GetChild(2).position, Quaternion.Euler(0, 0, 60), GameObject.Find("ProjectileStorage").transform);

                Instantiate(Salt, gameObject.transform.GetChild(1).GetChild(0).GetChild(18).position, Quaternion.Euler(0, 0, 165), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Salt, gameObject.transform.GetChild(1).GetChild(0).GetChild(18).position, Quaternion.Euler(0, 0, 15), GameObject.Find("ProjectileStorage").transform);
                ShootDelay = 0;
            }
            ShootTime += 1*Time.deltaTime;
            if(ShootTime >= 8)
            {
                Charge = false;
                ShootTime = 0;
            }
        }
    }
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

    public IEnumerator Screencharge()
    {
        int ScreenWidth = Random.Range(40, Screen.width/2 - 20);
        Vector2 Pos = new(0, ScreenWidth);
        int Screenside = Random.Range(1, 3);
        if (Screenside == 1)//Right
        {
            Pos.x = Screen.height + 2520;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 180));
        }
        if(Screenside == 2) //Left
        {
            Pos.x = -440 ;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(0.5f);
        Charge = true;
    }

    public void TunnelUp()
    {

    }
}
