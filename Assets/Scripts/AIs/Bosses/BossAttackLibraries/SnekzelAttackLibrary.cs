using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekzelAttackLibrary : MonoBehaviour
{
    public GameObject Player;
    public GameObject Salt;
    public GameObject P2Saltshakers;
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
                Instantiate(Salt, P2Saltshakers.transform.GetChild(2).position, Quaternion.Euler(0, 0, 120), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Salt, P2Saltshakers.transform.GetChild(2).position, Quaternion.Euler(0, 0, 60), GameObject.Find("ProjectileStorage").transform);

                Instantiate(Salt, P2Saltshakers.transform.GetChild(18).position, Quaternion.Euler(0, 0, 165), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Salt, P2Saltshakers.transform.GetChild(18).position, Quaternion.Euler(0, 0, 15), GameObject.Find("ProjectileStorage").transform);
                ShootDelay = 0;
            }
            ShootTime += 1*Time.deltaTime;
            if(ShootTime >= 4)
            {
                Charge = false;
                GetComponent<Snekzel_AI>().Attacking = false;
                ShootTime = 0;
                if(GetComponent<Snekzel_AI>().state == Snekzel_AI.BossPhase.PHASE_3)
                {
                    GetComponent<Snekzel_AI>().UpdateHealth(80);
                    GetComponentInParent<Snekzel_AI>().LeaveTransition = false;
                    GetComponent<Transform>().GetChild(2).gameObject.SetActive(true);
                    GameObject.Find("Phase 2").SetActive(false);
                }
            }
        }
    }
    public void SaltThrow()
    {
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform Head = GameObject.Find("P1Head").transform;
        for(int i = 0; i < 7; i++)
        {
            Instantiate(Salt, Head.position, Quaternion.Euler(0, 0, angle - (i + 6) * 10), GameObject.Find("ProjectileStorage").transform);
        }
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
        if(Screenside == 2)//Left
        {
            Pos.x = -440 ;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        }
        yield return new WaitForSeconds(0.75f);
        Charge = true;
    }

    public IEnumerator TunnelUp()
    {
        GameObject.Find("Phase 3").transform.GetChild(1).gameObject.SetActive(false);
        int ScreenY = Random.Range(200, (Screen.height - 200));
        int ScreenX = Random.Range(850, (Screen.width - 400));
        Vector2 Pos = new(ScreenX, ScreenY);
        transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Phase 3").transform.GetChild(1).gameObject.SetActive(true);

        Transform Head = GameObject.Find("P3Head").transform;
        for (int i = 0; i < 36; i++)
        {
            Instantiate(Salt, Head.position, Quaternion.Euler(0, 0, 10*i), GameObject.Find("ProjectileStorage").transform);
        }
    }
}
