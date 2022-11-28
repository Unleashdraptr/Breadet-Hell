using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtilla_AI : MonoBehaviour
{
    public enum BossPhase { PHASE_1, PHASE_2, PHASE_3, WIN, LOSE };
    public BossPhase state;
    public int Health;
    public float InvisTimer;
    public bool Attacking;
    public GameObject Player;
    public GameObject P1sprite;
    public int spinTarget;
    int spinDirection = 1;
    float Xdirect = 250;
    float Ydirect = 250;

    // Start is called before the first frame update
    void Start()
    {
        //Set all the variables to be used by boss
        state = BossPhase.PHASE_1;
        int TempHealth = 250;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (250 * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;

        Xdirect += Variables.Difficulties * 100;
        Ydirect += Variables.Difficulties * 100;
        spinTarget = Variables.Difficulties;
    }




    void Update()
    {
        //Will stop if the game is paused
        if (Variables.Pause == false)
        {
            if (Attacking == false)
            {
                InvisTimer += 1 * Time.deltaTime;
            }

            //Starts boss' first attack
            if (state == BossPhase.PHASE_1 && InvisTimer >= 0.5f && GetComponent<TurtillaAttackLibrary>().Snapping == false)
            {
                StartCoroutine(GetComponent<TurtillaAttackLibrary>().SnapAttack());
                InvisTimer = 0;
            }
            //Starts boss' second attack
            if (state == BossPhase.PHASE_2 && InvisTimer >= 0.5f)
            {
                StartCoroutine(GetComponent<TurtillaAttackLibrary>().ShedAttack());
                InvisTimer = 0;
            }
            //Starts boss' third attack
            if (state == BossPhase.PHASE_3 && InvisTimer >= 0.5f)
            {
                StartCoroutine(GetComponent<TurtillaAttackLibrary>().SplitUp());
                InvisTimer = 0;
            }
        }


        if (state == BossPhase.PHASE_1)
        {
            //moves turtilla around the screen when in phase 1
            transform.position += new Vector3(Xdirect * Time.deltaTime, Ydirect * Time.deltaTime, 0);
            //Only pins the sprite child of turtilla so that the direction isn't affected
            print(spinDirection * (P1sprite.transform.rotation.eulerAngles.z + (100 + 75 * Variables.Difficulties) * Time.deltaTime));
            P1sprite.transform.rotation = Quaternion.Euler(0, 0,  P1sprite.transform.rotation.eulerAngles.z + spinDirection * (100 + 100*Variables.Difficulties) * Time.deltaTime);
        }    
    }

    //Activates when entering another object's collider
    void OnCollisionEnter2D(Collision2D other)
    {
        float YOriginal = Ydirect;
        float XOriginal = Xdirect;

        //Checks if the objected entered has the PlayField tag
        if (other.gameObject.tag != "PlayField")
            return;

        if (other.gameObject.name == "Left Wall" || other.gameObject.name == "Right Wall")
        {
            //Flips the X direction force when hitting left or right
            Xdirect *= -1;
            spinTarget++;
        }
        if (other.gameObject.name == "Top Wall" || other.gameObject.name == "Bottom Wall")
        {
            //Flips the Y direction force when hitting top or bottom wall
            Ydirect *= -1;
            spinTarget++;
        }
        if (spinTarget > 5 && Variables.Difficulties != 1)
        {
            spinTarget = Variables.Difficulties;
            Vector3 dir = Player.transform.position - transform.position;
            float totalForce = (Mathf.Sqrt(Xdirect*Xdirect) + Mathf.Sqrt(Ydirect * Ydirect)) / (Mathf.Sqrt(dir.x*dir.x) + Mathf.Sqrt(dir.y*dir.y));
            Ydirect = totalForce * dir.y;
            Xdirect = totalForce * dir.x;

            if (((XOriginal > 0) && (Xdirect < 0) || ((XOriginal < 0) && (Xdirect < 0)) && (other.gameObject.name == "Top Wall" || other.gameObject.name == "Bottom Wall")))
                spinDirection *= -1;
            if (((YOriginal > 0) && (Ydirect < 0) || ((YOriginal < 0) && (Ydirect < 0)) && (other.gameObject.name == "Right Wall" || other.gameObject.name == "Left Wall")))
                spinDirection *= -1;
        }

    }










    public void DeathCheck()
    {
        //Kills Boss if final phase and has no health left
        if (Health <= 0 && state == BossPhase.PHASE_3)
        {
            state = BossPhase.WIN;
            GameObject.Find("Canvas").GetComponent<GameState>().EnemyDead = true;
            Destroy(gameObject);
        }
        //Transition to the second phase if on Burnt or Breadendary
        if (Health <= 0 && state == BossPhase.PHASE_1 && Variables.Difficulties > 2 && GetComponent<TurtillaAttackLibrary>().Snapping == false)
        {
            state = BossPhase.PHASE_2;
            UpdateHealth(175);
        }
        //Transition to Phase 3
        if ((Health <= 0 && state == BossPhase.PHASE_1 && Variables.Difficulties < 3 && GetComponent<TurtillaAttackLibrary>().Snapping == false) || (Health <= 0 && state == BossPhase.PHASE_2))
        {
            state = BossPhase.PHASE_3;
            UpdateHealth(175);
        }
    }




    //Function for updating boss' health after beating phase
    public void UpdateHealth(int LowestHealth)
    {
        int TempHealth = LowestHealth;
        for (int i = 0; i < Variables.Difficulties - 1; i++)
        {
            TempHealth += (TempHealth * Variables.BossMultiplers[0]) / 100;
        }
        Health = TempHealth;
    }




}