using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtillaAttackLibrary : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public bool Charge;
    public bool Snapping = false;
    public float Speed;

    public bool targeting;

    //Phase 1 Attack
    public IEnumerator SnapAttack()
    {
        yield return new WaitForSeconds(0.5f);
    }


    //Phase 2 Attack
    public IEnumerator ShedAttack()
    {
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
        yield return new WaitForSeconds(0.3f);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
        yield return new WaitForSeconds(0.5f);
    }


    //Phase 3 Attack
    public IEnumerator SplitUp()
    {
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
        yield return new WaitForSeconds(0.5f);
    }


}
