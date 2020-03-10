using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Vector2 destination;
    public float speed;
    bool usingFade = true;
    public float fadeTime = 0.5f;

    float fadeTimer;
    void Start()
    {
        StartCoroutine(Fade.Do("in",gameObject, fadeTime));
        usingFade = true;
        fadeTimer = fadeTime;
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
                Destroy(gameObject);
            }
        }
        
        
        fadeTimer -= Time.deltaTime;
        
    }
    
}
