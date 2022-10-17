using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackLibrary : MonoBehaviour
{
    public GameObject Bullet;
    public void Attack1(GameObject Enemy)
    {
        Instantiate(Bullet, Enemy.transform.position, Enemy.transform.rotation, GameObject.Find("ProjectileStorage").transform);
    }
    public void Attack2(GameObject Enemy)
    {
        Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 135), GameObject.Find("ProjectileStorage").transform);
        Instantiate(Bullet, Enemy.transform.position, Enemy.transform.rotation, GameObject.Find("ProjectileStorage").transform);
        Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, -135), GameObject.Find("ProjectileStorage").transform);
    }
    public void Attack3(GameObject Enemy)
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 36*i), GameObject.Find("ProjectileStorage").transform);
        }
    }
    public void Attack4(GameObject Enemy)
    {
        for (int i = 0; i < 10; i++)
        {
            int random = Random.Range(5, 360);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, random), GameObject.Find("ProjectileStorage").transform);
        }
    }
    public IEnumerator Attack5(GameObject Enemy)
    {
        for (int i = 0; i < 25; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 240 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
