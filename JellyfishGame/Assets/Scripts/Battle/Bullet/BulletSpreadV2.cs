using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpreadV2 : MonoBehaviour
{
    public int numOfBullets;
    public float minRotation;
    public float maxRotation;
    public float bulletCooldown;
    public float minBulletSpeed;
    public float bulletSpeed;
    public bool isRandom = false;
    public bool usingCustomSprite = false;
    public Sprite customSprite;
    public GameObject customObj = null;
    float[] rots;
    float bulletTimer;

    public void Start()
    {
        rots = new float[numOfBullets];
        bulletTimer = bulletCooldown;

        if (minBulletSpeed == 0f)
            minBulletSpeed = bulletSpeed;
    }
    public void Update()
    {
        if (bulletTimer <= 0)
        {
            DetermineRots();
            var bullets = Bullet.Attack.UsingTransform(transform, numOfBullets, bulletSpeed, rots, _customObject: customObj);
            if (usingCustomSprite)
            {
                foreach (GameObject bullet in bullets)
                {
                    bullet.GetComponent<SpriteRenderer>().sprite = customSprite;
                }
            }
            bulletTimer = bulletCooldown; 
        }
        bulletTimer -= Time.deltaTime;
    }
    public void DetermineRots()
    {
        if (isRandom)
        {
            for (int i = 0; i < numOfBullets; i++)
                rots[i] = Random.Range(minRotation, maxRotation);
        } else
        {
            var diff = maxRotation - minRotation; // Difference from min to max Rotation
            for (int i = 0; i < numOfBullets; i++)
            {
                var d = (i / (numOfBullets - 1)) * diff; // Difference from min to bullet rotation
                rots[i] = minRotation + d;
            }
        }
    }
}
