using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpray : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceFromCenter;
    public float bulletSpeed;
    public float timeSpraying;
    public float timePerBullet;
    public float timeWaiting;
    public GameObject spriteObj;
    float sprayTimer;
    float bulletTimer;
    float waitTimer;
    int mode = 0;
    Dictionary<Vector2, float[]> sprayRots = new Dictionary<Vector2, float[]>();
    ArrayList bullets = new ArrayList();
    Vector2 currentDir; // Temp var
    float[] currentRot; // Temp var
    bool usingWaitTransition = false;
    public float scriptTime; // How much time the script will run for
    float timer;
    void Start()
    {
        // We get a vector around the map and pin point it to the rotations we want to animate with.
        sprayRots.Add(BulletManager.Pointers.Dirs[4], new float[2] { 90, 180 } ); // First Quadrant
        sprayRots.Add(BulletManager.Pointers.Dirs[5], new float[2] { 90, 0 }); // Second Quadrant
        sprayRots.Add(BulletManager.Pointers.Dirs[6], new float[2] { -90, 0 }); // Third Quadrant
        sprayRots.Add(BulletManager.Pointers.Dirs[7], new float[2] { -90, -180 }); // Fourth Quadrant

        NewPos();
        timer = scriptTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (sprayTimer <= 0) 
        {
            EndSpray();
            if (!usingWaitTransition) StartCoroutine(WaitTransition());
        } else 
        {
            var z = Mathf.Lerp(currentRot[0], currentRot[1], sprayTimer / timeSpraying);
            transform.eulerAngles = new Vector3(0, 0, z);
        }
        if (bulletTimer <= 0 && !usingWaitTransition) NewBullet();

        // SCRIPT TIME
        if (timer <= 0)
        {
            GetComponent<BattleEntityAttack>().entity.isAttackDone = true;
            Destroy(gameObject);
        }
        
        // Timers
        sprayTimer -= Time.deltaTime;
        bulletTimer -= Time.deltaTime;
        waitTimer -= Time.deltaTime;
        timer -= Time.deltaTime;
    }
    void NewBullet()
    {
        var r = 180f; // Depending on the quadrant you need a different rotation
        if (mode == 2 || mode == 3) r = 0f; // QUAD 3 || 4 -> 0f ; QUAD 1 || 2 -> 180f

        var b = Bullet.Create(transform.position, Vector2.zero, Random.Range(r - 45f, r + 45f)).GetComponent<Bullet>();
        bullets.Add(b);
        b.transform.SetParent(transform);
        b.useTranslateFeatures = true;
        b.translatedVelocity = new Vector2(0, bulletSpeed);
        bulletTimer = timePerBullet;
    }
    
    void EndSpray()
    {
        // Remove Bullets From Parent
        for (int i = 0; i < bullets.Count; i++)
        {
            var b = (Bullet)bullets[i];
            b.transform.SetParent(null, true);
            bullets.Remove(i);
        }
    }
    void NewSpray()
    {
        // Reset Timer
        sprayTimer = timeSpraying;
        // Iteration
        mode += 1;
        if (mode == 4) mode = 0;
        usingWaitTransition = false;
    }
    void NewPos()
    {
        // Position
        Vector2 thisDir = BulletManager.Pointers.Dirs[mode + 4];
        transform.position = thisDir * distanceFromCenter;
        // Rotation
        sprayRots.TryGetValue(thisDir, out currentRot);
        transform.eulerAngles = new Vector3(0, 0, currentRot[1]);
    }
    public IEnumerator WaitTransition()
    {
        // Set it to true so the script knows this is being used
        usingWaitTransition = true;

        // Fade Out
        StartCoroutine(Fade.Do("out", spriteObj, timeWaiting * 0.45f));
        yield return new WaitForSeconds(timeWaiting * 0.45f);
        // Change Position
        NewPos();
        yield return new WaitForSeconds((timeWaiting * 0.1f));
        // Fade In
        StartCoroutine(Fade.Do("in", spriteObj, timeWaiting * 0.45f));
        yield return new WaitForSeconds((timeWaiting * 0.45f));
   
        // Continue
        NewSpray();

        // USE Fade.Do();

        
    }
}
