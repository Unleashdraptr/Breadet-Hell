using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 9.99f;
    public float countdown;
    public Text disvar;
    public bool StartTimer = false;

    private void Start()
    {
        countdown = totalTime;
    }

    void Update()
    {
        if (countdown > 0 && StartTimer == true)
        {
            countdown -= Time.deltaTime;
            double b = System.Math.Round(countdown, 3);
            disvar.text = b.ToString();
        }
        if (countdown < 0)
        {
            disvar.text = "0.00";
        }
    }
}