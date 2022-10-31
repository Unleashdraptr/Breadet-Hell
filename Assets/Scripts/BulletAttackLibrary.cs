using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackLibrary : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;
    //Store for all attacks the enemies and players could use for access quickly by multiple objects.
    public void HomingBullet(GameObject Enemy)
    {
        Vector3 dir = Player.transform.position - Enemy.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0 ,0, angle-90), GameObject.Find("ProjectileStorage").transform);
    }
    public void TripleShot(GameObject Enemy)
    {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 0), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, -120), GameObject.Find("ProjectileStorage").transform);
    }
    public IEnumerator SpiralShot(GameObject Enemy)
    {
        for (int i = 0; i < 25; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 90 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 180 + i * 20), GameObject.Find("ProjectileStorage").transform);
            if (Variables.Difficulties == 3 || Variables.Difficulties == 4)
            {
                Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 270 + i * 20), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
    public IEnumerator HomingEnemy(GameObject Enemy)
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
    public IEnumerator BeamShot(GameObject Enemy)
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
    public IEnumerator Charger(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < 15 + RandomTimes; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 240 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.15f);
        }
    }
    public IEnumerator Shotgun(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < 15 + RandomTimes; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 240 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.15f);
        }
    }
    public IEnumerator BIGSHOT(GameObject Enemy)
    {
        int RandomTimes = Random.Range(1, Variables.ShootRandomness[Variables.Difficulties - 1]);
        for (int i = 0; i < 15 + RandomTimes; i++)
        {
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 120 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 240 + i * 20), GameObject.Find("ProjectileStorage").transform);
            Instantiate(Bullet, Enemy.transform.position, Quaternion.Euler(0, 0, 360 + i * 20), GameObject.Find("ProjectileStorage").transform);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
