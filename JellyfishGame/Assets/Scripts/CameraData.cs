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
        width = height * (1 / cam.aspect); // getting reciprical
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
