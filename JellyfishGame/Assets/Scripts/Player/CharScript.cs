using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    // Update is called once per frame
    void Update()
    {
        float translation = speed;
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        // Move translation along the object's z-axis
        if (Input.GetKey("w"))
        {
            transform.Translate(0,translation,0);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-translation,0,0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(translation,0,0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0,-translation,0);
        }
    }
}
