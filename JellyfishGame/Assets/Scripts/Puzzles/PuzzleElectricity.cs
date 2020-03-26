using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElectricity : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }
    bool isVerticalRotation()
    {
        // If returns true theres no remainder, degree must be 360, 180, 0. Thinking of algebra terminal rays here.
        return transform.eulerAngles.z % 0 == 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleReflector")
        {
            //   45 looks like this -> \
            if (collision.transform.eulerAngles.z == 45)
            {
                if (isVerticalRotation()) transform.eulerAngles += new Vector3(0, 0, 90);
                else                        transform.eulerAngles += new Vector3(0, 0, -90);
            }

            //   135 looks like this -> /
            if (collision.transform.eulerAngles.z == 135)
            {
                if (isVerticalRotation()) transform.eulerAngles += new Vector3(0, 0, -90);
                else                        transform.eulerAngles += new Vector3(0, 0, 90);
            }
        }
        if (collision.tag == "PuzzleGoal")
        {
            // Open Door
        }
    }
    
}
