using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    Camera cam;
    public static float width;
    public static float height;
    void Start()
    {
        cam = GetComponent<Camera>();
        height = cam.orthographicSize * 2;
        width = height * cam.aspect; // getting reciprical
        print(width);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
