using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralingSpread : MonoBehaviour
{
    public float bulletSpeed;
    public int numOfBullets;
    public float rotationSpeed;
    ArrayList bulletSpreads;
    public int maxBulletSpreads = 20;
    public bool isRandomRotation = false;
    public float bulletCooldown;
    float bulletTimer;
    public GameObject customObject = null;
    public Sprite customSprite = null;
    int rF = 1;
    
    void Start()
    {
        bulletSpreads = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTimer <= 0)
        {
            // Timer
            bulletTimer = bulletCooldown;

            // Calculating Rotation
            var r = 0f;
            if (isRandomRotation)
                r = Random.Range(-rotationSpeed, rotationSpeed);
            else
            {
                r = rotationSpeed * rF;
                rF *= -1;
            }

            // Instantiating Bullet
            var bSpread = BulletSpread.Create(transform.position, numOfBullets, bulletSpeed: bulletSpeed, runTimer: false, translate: true, isParent: true);
            bSpread.transform.eulerAngles = new Vector3(0, 0, r);
            var bullets = bSpread.GetComponent<BulletSpread>().Attack(customObj: customObject);
            bulletSpreads.Add(bSpread);

            // Checking for Max Bullets
            if (bulletSpreads.Count >= maxBulletSpreads)
            {
                Destroy(bulletSpreads[0] as GameObject);
                bulletSpreads.RemoveAt(0);
            }

            
            // If we want a customSprite the custom Sprite will be applied to each of the bullets
            if (customSprite != null)
            {
                foreach (var bullet in bullets)
                    bullet.GetComponent<SpriteRenderer>().sprite = customSprite;
            }
            RotateBy.Add(bSpread, r);

        }
        bulletTimer -= Time.deltaTime;
    }
}
