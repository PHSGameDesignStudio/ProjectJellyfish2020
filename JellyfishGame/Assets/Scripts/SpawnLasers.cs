using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLasers : MonoBehaviour
{
    public string laserName;
    GameObject laserObjRef;
    public float minX;
    public float maxX;
    public float cooldown;
    float timer;
    ArrayList activeLasers;
    void Start()
    {
        laserObjRef = Resources.Load(laserName) as GameObject;
        activeLasers = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            var lObj = Instantiate(laserObjRef);
            var l = lObj.GetComponent<Laser>();
            l.transform.SetParent(transform);
            l.transform.localScale = l.scale = new Vector3(0.1f / 3f, 10);
            l.transform.localPosition = l.pos = new Vector3(Random.Range(minX, maxX), 0);
            timer = cooldown;
        }
        timer -= Time.deltaTime;
    }
}
