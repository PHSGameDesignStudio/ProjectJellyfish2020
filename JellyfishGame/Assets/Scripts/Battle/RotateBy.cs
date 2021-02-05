using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBy : MonoBehaviour
{
    public float rotationSpeed;
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + (rotationSpeed * Time.deltaTime));
    }
    public static void Add(GameObject obj, float rSpeed)
    {
        var s = obj.AddComponent<RotateBy>();
        s.rotationSpeed = rSpeed;
        
    }
}
