using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet")]

    public static GameObject defaultObj; // The default bullet to be used

    #region Determiners
    public bool useDeterminers; // What should level manager do with these objects?
    public bool determineIsDestroyable;
    public bool determineIsPoolable;
    #endregion Determiners
    #region Translate Features
    public bool useTranslateFeatures;
    public Vector3 translatedVelocity;
    #endregion
    public string objectType; // use where applicable.

    // Relocate children of a parent from one parent to another
    public static void RelocateChildrenFromTo(GameObject fromObj, GameObject toObj, bool worldPositionStays = true)
    {
        for (int i = 0; i < fromObj.transform.childCount; i++)
            fromObj.transform.GetChild(i).SetParent(toObj.transform, worldPositionStays);
    }

    public struct Attack
    {
        // An attack but using Transform.Translate so rotations are possible, not great for straight directions.
        public static GameObject[] UsingTransform(Transform transform, int bulletNumber, float bulletSpeed, float[] pointRots, bool isParent = false, GameObject _customObject = null)
        {
            GameObject[] rBullets = new GameObject[bulletNumber];
            for (int i = 0; i < bulletNumber; i++)
            {
                rBullets[i] = Bullet.Create(transform.position, Vector2.zero, pointRots[i], _bullet: _customObject);
                rBullets[i].GetComponent<Bullet>().useTranslateFeatures = true;
                rBullets[i].GetComponent<Bullet>().translatedVelocity = Vector2.up * bulletSpeed;
                if (isParent) rBullets[i].transform.SetParent(transform, true);
            }
            return rBullets;
        }
        // An attack but using Vector2.MoveTowards. Great if you want a straight location to pin point to.
        public static GameObject[] UsingVector(Transform transform, int bulletNumber, float bulletSpeed, Vector2[] pointDirs, bool isParent = false, GameObject _customObject = null)
        {
            GameObject[] rBullets = new GameObject[bulletNumber];
            for (int i = 0; i < bulletNumber; i++)
            {
                rBullets[i] = Bullet.Create(transform.position, pointDirs[i] * bulletSpeed, 0, _bullet: _customObject);
                if (isParent) rBullets[i].transform.SetParent(transform, true);
            }
            return rBullets;
        }
    }

    // Bullets don't need update functions. It is a simple bullet. This might change in the future.
    public static GameObject Create(Vector2 pos, Vector2 velocity, float rotation, string tag = "Hostile", bool poolable = true, bool destroyable = false, bool usingPool = true, GameObject _bullet = null)
    {
        // So we can spawn custom bullets [Shouldnt use pool with custom bullets]
        GameObject objRef = defaultObj;
        if (_bullet != null)
        {
            objRef = _bullet;
        }
        GameObject returnBullet = null;
        //
        if (usingPool)
        {
            returnBullet = BulletManager.Pooling.Get("bullet");
            BulletManager.Pooling.Remove(returnBullet);
        }
        if (returnBullet == null) returnBullet = Instantiate(objRef, pos, Quaternion.identity) as GameObject;
        // returnBullet.GetComponent<ObjectType>().SetWantedComponents();
        returnBullet.GetComponent<Bullet>().determineIsPoolable = poolable;
        returnBullet.GetComponent<Bullet>().determineIsDestroyable = destroyable;
        returnBullet.transform.position = pos;
        returnBullet.transform.eulerAngles = new Vector3(0, 0, rotation);
        returnBullet.GetComponent<Rigidbody2D>().velocity = velocity;
        returnBullet.tag = tag;
        return returnBullet;
    }
    // Sets an object to be a poolable object
    // Start is called before the first frame update
    void Start()
    {
        defaultObj = (GameObject)Resources.Load("bullet");
    }

    // Update is called once per frame
    void Update()
    {
        #region Translate Features
        if (useTranslateFeatures)
            transform.Translate(translatedVelocity * Time.deltaTime);
        #endregion

    }
}
