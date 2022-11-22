using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSet : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the camera to cover the entire screen of the phone and then resets the bottom left corner to 0,0 (Work in progress)
        Camera.orthographicSize = Screen.height/2;
        Vector3 Pos = new(Screen.height+40, Screen.height / 2, -10);
        transform.SetPositionAndRotation(Pos, transform.rotation);
        GetComponent<BoxCollider2D>().size = new(Screen.width, Screen.height);
    }
}
