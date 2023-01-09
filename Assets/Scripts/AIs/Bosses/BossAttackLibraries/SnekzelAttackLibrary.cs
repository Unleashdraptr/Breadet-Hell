using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekzelAttackLibrary : MonoBehaviour
{
    //Objects and positisons that Snekzel needs
    public GameObject Player;
    public GameObject Salt;
    public GameObject SuperSalt;
    public GameObject P2Saltshakers;
    public GameObject Toaster;
    public bool Charge;
    float ShootDelay = 0;
    float ShootTime = 0;
    readonly float[] ShootDelayTimes = { 1.45f, 1.475f, 1.475f, 1.5f };
    void Update()
    {
        //If he is charging he will perform the code bellow, he will only charge in Phase 2
        if (Charge == true)
        {
            //He charges across the screen VERY quickly while shooting out salt
            transform.Translate(5000 * Time.deltaTime, 0, 0);
            ShootDelay += 1*Time.deltaTime;
            //ShootDelay depends on the difficulty
            if (ShootDelay >= (1.55f - ShootDelayTimes[Variables.Difficulties - 1]))
            {
                //Faster salt is shot out in higher difficulties (Burnt & Breadendary)
                if (Variables.Difficulties > 1)
                {
                    Instantiate(SuperSalt, P2Saltshakers.transform.GetChild(2).position, Quaternion.Euler(0, 0, 120), GameObject.Find("ProjectileStorage").transform);
                    Instantiate(SuperSalt, P2Saltshakers.transform.GetChild(2).position, Quaternion.Euler(0, 0, 60), GameObject.Find("ProjectileStorage").transform);
                }
                //He shoots out regualar salt always
                Instantiate(Salt, P2Saltshakers.transform.GetChild(18).position, Quaternion.Euler(0, 0, 165), GameObject.Find("ProjectileStorage").transform);
                Instantiate(Salt, P2Saltshakers.transform.GetChild(18).position, Quaternion.Euler(0, 0, 15), GameObject.Find("ProjectileStorage").transform);
                ShootDelay = 0;
            }
            //The minimum time he will charge across the screen before checking if hes dead/ needs to change forms
            ShootTime += 1*Time.deltaTime;
            if(ShootTime >= 2)
            {
                //Stops the charge and prevents him to charge again while he changes forms
                Charge = false;
                GetComponent<Snekzel_AI>().Attacking = false;
                ShootTime = 0;
                //Sets up for Phase 3
                if(GetComponent<Snekzel_AI>().state == Snekzel_AI.BossPhase.PHASE_3)
                {
                    GetComponent<Snekzel_AI>().UpdateHealth(175);
                    GetComponentInParent<Snekzel_AI>().LeaveTransition = false;
                    GetComponent<Transform>().GetChild(2).gameObject.SetActive(true);
                    GameObject.Find("Phase 2").SetActive(false);
                }
            }
        }
    }
    //Phase 1 Attack
    public void SaltThrow()
    {
        //Finds the players locations and the angle it to hit the player
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform Head = GameObject.Find("P1Head").transform;
        for(int i = 0; i < 7; i++)
        {
            //Randomly checks if some should fire out faster bullets
            int Speed = Random.Range(1, 11);
            //bullets that are fired from the head
            if (Speed < (8 - Variables.Difficulties))
            {
                Instantiate(Salt, Head.position, Quaternion.Euler(0, 0, angle - (i + 6) * 10), GameObject.Find("ProjectileStorage").transform);
            }
            if (Speed >= (8 - Variables.Difficulties))
            {
                Instantiate(SuperSalt, Head.position, Quaternion.Euler(0, 0, angle - (i + 6) * 10), GameObject.Find("ProjectileStorage").transform);
            }
        }
    }

    //Phase 1 and 2 automatic attacks that is just salt dropping off of snekzel
    public void SaltDrop(Transform SaltShaker)
    {
        Instantiate(Salt, SaltShaker.position, Quaternion.Euler(0, 0, 180), GameObject.Find("ProjectileStorage").transform);
    }

    public IEnumerator Screencharge(bool IsBoss)
    {
        //This decides what side of the screen he will start to travel from and at what height on the screen to do so
        int ScreenWidth = Random.Range(150, Screen.height + 40);
        Vector2 Pos = new(0, ScreenWidth);
        int Screenside = Random.Range(1, 3);
        if (Screenside == 1)//Right
        {
            Pos.x = Screen.width + 900;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 180, 0));
        }
        if(Screenside == 2)//Left
        {
            Pos.x = -540 ;
            transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        }
        //This checks if its Snekzel or Snekzlette is using the position decider
        if (IsBoss)
        {
            //Then waits for a 0.75 seconds to show a tell to the player of where Snekzel is about to charge fromm
            yield return new WaitForSeconds(0.75f);
            Charge = true;
        }
    }
    bool HasMoved = false;
    int MineCount;

    public Animator P3Anim;
    public IEnumerator TunnelUp()
    {
        //Places a mine every 2 times he stops tunneling up
        if (HasMoved == true && MineCount == 2)
        {
            GameObject Toasty = Instantiate(Toaster, GameObject.Find("Phase 3").transform.position, Quaternion.identity, GameObject.Find("ProjectileStorage").transform);
            //Accelerates the mine to explode faster
            Toasty.transform.GetChild(2).GetComponent<Timer>().totalTime = 2.5f;
            Toasty.transform.GetChild(2).GetComponent<Timer>().countdown = 2.5f;
            MineCount = 0;
        }
        //Sets the head to false so the tell can show
        GameObject.Find("Phase 3").transform.GetChild(1).gameObject.SetActive(false);
        //Picks a random place on the screen to appear at
        int ScreenY = Random.Range(200, (Screen.height - 200));
        int ScreenX = Random.Range(850, (Screen.width - 400));
        //Sets the positions which is shown with the tell
        Vector2 Pos = new(ScreenX, ScreenY);
        transform.SetPositionAndRotation(Pos, Quaternion.Euler(0, 0, 0));
        //Waits so the player can see the tell
        yield return new WaitForSeconds(0.5f);
        //Then sets the head to be true
        GameObject.Find("Phase 3").transform.GetChild(1).gameObject.SetActive(true);
        P3Anim.SetTrigger("NextAnim");
        yield return new WaitForSeconds(0.65f);
        //Then uses the heads position and then launches salt all over the screen
        Transform Head = GameObject.Find("P3Head").transform;
        for (int i = 0; i < 36; i++)
        {
            Instantiate(Salt, Head.position, Quaternion.Euler(0, 0, 10*i), GameObject.Find("ProjectileStorage").transform);
        }
        P3Anim.SetTrigger("NextAnim");
        yield return new WaitForSeconds(0.5f);
        HasMoved = true;
        MineCount += 1;
    }
}
