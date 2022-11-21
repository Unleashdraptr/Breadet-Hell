using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new(0, 0, 1);
        GetComponent<Rigidbody2D>().AddForce(new(0, -9.8f*Time.deltaTime));
    }
}
