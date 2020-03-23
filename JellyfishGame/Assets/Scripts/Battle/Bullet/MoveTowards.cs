using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Vector2 destination;
    public float speed;
    bool usingFade = true;
    public float fadeTime = 0.5f;
    public bool useRandomX;
    public bool useRandomY;

    float fadeTimer;
    void Start()
    {
        StartCoroutine(Fade.Do("in",gameObject, fadeTime));
        usingFade = true;
        fadeTimer = fadeTime;
        var pos = transform.position;
        if (useRandomX) {
            var x = destination.x;
            pos.x = destination.x = Random.Range(-x, x);
            transform.position = pos;
        }
        if (useRandomY)
        {
            var y = destination.y;
            pos.y = destination.y = Random.Range(-y, y);
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != (Vector3)destination)
        {
            if (fadeTimer <= 0)
            {
                usingFade = false;
                transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }
        }
        else
        {
            if (!usingFade)
            {
                usingFade = true;
                fadeTimer = fadeTime;
                StartCoroutine(Fade.Do("out", gameObject, fadeTime));
            }
            if (fadeTimer <= 0)
            {
                GetComponent<BattleEntityAttack>().entity.isAttackDone = true;
                Destroy(gameObject);
            }
        }
        
        
        fadeTimer -= Time.deltaTime;
        
    }
    
}
