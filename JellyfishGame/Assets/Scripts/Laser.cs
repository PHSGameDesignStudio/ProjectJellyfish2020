using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject emptyObj;
    public Vector2 scale;
    public Vector2 pos;
    public float increment;
    GameObject helper;
    GameObject attack;
    bool isHelperCreated;
    bool isAttackCreated;
    public float waitTime;
    public float laserTime;
    float tWait;
    float tLaser;
    float tLaserInc = 1;
    void Start()
    {
        emptyObj = (GameObject)Resources.Load("emptyObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHelperCreated)
        {
            isHelperCreated = true;
            helper = Instantiate((GameObject)Resources.Load("Helper"), pos, Quaternion.identity) as GameObject;
            helper.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
            helper.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("SquareTop");
            helper.transform.localScale = scale; 
            tWait = waitTime;
        } else
        {
            tWait -= Time.deltaTime;
        }
        if (!isAttackCreated && tWait <= 0)
        {
            isAttackCreated = true;
            attack = Instantiate((GameObject)Resources.Load("SquareObj"), pos, Quaternion.identity) as GameObject;
            attack.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("SquareTop");
            Destroy(helper);
            tLaser = 0;
        }
        if (isAttackCreated)
        {
            if (tLaser >= laserTime)
                tLaserInc = -1;
            tLaser += tLaserInc * Time.deltaTime;
            attack.transform.localScale = Vector3.Lerp(Vector3.zero, scale, tLaser / laserTime);
            if (tLaser < 0)
            {
                Destroy(attack);
                Destroy(gameObject);
            }
        }

    }
}
