using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public int numOfAttackAreas;
    public float max_x;
    void Start()
    {
        for (int i = 0; i < numOfAttackAreas; i++)
        {
            var init_x = Random.Range((float)i / numOfAttackAreas, (float)(i + 1) / numOfAttackAreas);
            var adjust_x = (init_x * max_x * 2) - max_x;
            var v = new Vector2(adjust_x, 0);
            var thisArea = Instantiate(Resources.Load("AttackArea"), v, Quaternion.identity) as GameObject;
            thisArea.transform.localScale = new Vector3(thisArea.transform.localScale.x * 0.7f, thisArea.transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
