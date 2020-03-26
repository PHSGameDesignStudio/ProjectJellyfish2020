using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReflector : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchState()
    {
        switch(transform.eulerAngles.z)
        {
                // switches back to 135.
            case 45:
                transform.eulerAngles += Vector3.forward * 90;
                break;

                // switches back to 45.
            case 135:
                transform.eulerAngles -= Vector3.forward * 90;
                break;
        }
    }
}
