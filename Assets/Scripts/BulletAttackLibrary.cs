using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackLibrary : MonoBehaviour
{
    public GameObject Bullet;
    //Store for all attacks the enemies and players could use for access quickly by multiple objects.
    public void Attack1(GameObject Enemy)
    {
        Instantiate(Bullet, Enemy.transform.position, Enemy.transform.rotation, GameObject.Find("ProjectileStorage").transform);
    }
    public IEnumerator Attack2(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < RandomTimes; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 155), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 40), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, -40), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, -155), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.75f);
        }
    }
    public IEnumerator Attack3(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties-1]);
        for (int a = 0; a < RandomTimes; a++)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, (36 * i)+a*10), GameObject.Find("ProjectileStorage").transform);
            }
            yield return new WaitForSeconds(0.75f);
        }
    }
    public IEnumerator Attack4(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < RandomTimes; i++)
        {
            int random = Random.Range(5, 360);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, random), GameObject.Find("ProjectileStorage").transform);
            random = Random.Range(5, 360);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, random), GameObject.Find("ProjectileStorage").transform);
            random = Random.Range(5, 360);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, random), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator Attack5(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < 15+ RandomTimes; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 240 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
