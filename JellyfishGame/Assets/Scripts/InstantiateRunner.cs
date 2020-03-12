using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject Make(GameObject obj)
    {
        return Instantiate(obj) as GameObject;
    }
    public GameObject Make(GameObject obj, Transform trans)
    {
        return Instantiate(obj, trans) as GameObject;
    }
    public GameObject Make(GameObject obj, Vector3 trans, Quaternion quat)
    {
        return Instantiate(obj, trans, quat) as GameObject;
    }
    public GameObject Make(GameObject obj, Vector3 trans, Quaternion quat, Transform parent)
    {
        return Instantiate(obj, trans, quat, parent) as GameObject;
    }
}
