using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpread : MonoBehaviour
{
    // Maximum is 8 as of now. More will be added later.
    public int attackNumber;
    public float cooldown, bulletSpeed;
    float timer;
    // If run timer is true it will attack automatically. If not then the level designer is expected to code attacking in manually.
    public bool runTimer, translate, isParent;

    public static GameObject dfBulletSpread;
    void Update()
    {
        if (timer <= 0 && runTimer)
        {
            Attack();
            timer = cooldown;
        } 
        if (runTimer) timer -= Time.deltaTime;
    }
    public GameObject[] Attack(GameObject customObj = null)
    {
        if (translate) return Bullet.Attack.UsingTransform(transform, attackNumber, bulletSpeed, BulletManager.Pointers.Rots, isParent, _customObject: customObj);
        else return Bullet.Attack.UsingVector(transform, attackNumber, bulletSpeed, BulletManager.Pointers.Dirs, isParent, _customObject: customObj);
    }
    public static GameObject Create(Vector2 pos, int attackNumber, float cooldown = 1, float bulletSpeed = 5, bool runTimer = true, bool translate = false, bool isParent = true) {
        GameObject rObj = Instantiate(dfBulletSpread, pos, Quaternion.identity) as GameObject;
        BulletSpread rScript = rObj.GetComponent<BulletSpread>();
        rScript.attackNumber = attackNumber;
        rScript.bulletSpeed = bulletSpeed;
        rScript.cooldown = rScript.timer = cooldown;
        rScript.runTimer = runTimer;
        rScript.translate = translate;
        rScript.isParent = isParent;
        return rObj;
    }
    public float GetTimer() { return timer; }
}
