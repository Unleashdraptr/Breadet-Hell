using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSet : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera.orthographicSize = Screen.height/2;
        Vector3 Pos = new(Screen.height, Screen.height / 2, -10);
        transform.SetPositionAndRotation(Pos, transform.rotation);
    }
}
