using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public struct Pooling
    {
        public static GameObject[] poolable = new GameObject[9999];

        // This function will get a poolable object with a specific bullet type by going through filters.
        public static GameObject GetPoolableObject(string objectType)
        {
            for (int i = 0; i < poolable.Length; i++)
                if (poolable[i] != null) // Gets poolable objects that aren't null.
                    if (poolable[i].GetComponent<Bullet>().objectType == objectType) // Gets poolable objects that are a specific type.
                        return poolable[i];
            return null;
        }

        /* 
         * This function removes un-needed components and only keeps the wanted components.
         * NOTE: Is this function nessecary as simplifying objects does allow more flexibility, but is also more confusing.
         * Allow the option to be there for level designers? But don't include it in the core game code?
         */
        public static GameObject SimplifyObjectTo(GameObject bullet, string[] wantedComponents)
        {
            Component[] components = bullet.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                bool isComponentWanted = false;
                for (int j = 0; j < wantedComponents.Length && !isComponentWanted; j++)
                {
                    if (components[i].ToString() == wantedComponents[j]) isComponentWanted = true;
                    // print("c " + components[i].ToString() + ", w " + wantedComponents[j]);
                }
                if (isComponentWanted) continue;
                Destroy(bullet.GetComponents<Component>()[i]);
            }
            return bullet;
        }
        public static void Add(GameObject obj)
        {
            obj.transform.SetParent(null); // Makes sure parent is null before pooling it.
            bool objectFound = false;
            for (int i = 0; i < poolable.Length && !objectFound; i++)
                if (poolable[i] == null)
                {
                    poolable[i] = obj;
                    // SimplifyObjectTo(obj, obj.GetComponent<ObjectType>().wantedComponents);
                    obj.SetActive(false);
                    objectFound = true;
                }

        }
        public static GameObject Get(string bulletType, bool setActive = true)
        {
            GameObject obj = GetPoolableObject(bulletType);
            // if (obj != null) obj = SimplifyObjectTo(obj, obj.GetComponent<ObjectType>().GetWantedComponents());
            if (obj != null) obj.SetActive(setActive);
            return obj;
        }
        public static void Remove(GameObject obj)
        {
            for (int i = 0; i < poolable.Length; i++)
                if (poolable[i] == obj) poolable[i] = null;
        }
    }
    public struct Pointers
    {
        public static Vector2[] Dirs = new Vector2[8] { Vector2.up, Vector2.right, Vector2.down, Vector2.left, new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1) };
        public static float[] Rots = new float[8] { 0f, 90f, 180f, 270f, 45f, 135f, 225f, 315f };
        public static Vector2[] ShipDirs = new Vector2[3] { Vector2.left, new Vector2(-1, -1), new Vector2(-1, 1) };
        public static float[] ShipRots = new float[3] { 270f, 225f, 315f };
    }
    public void Start()
    {
        // Initialize Pool
        for (int i = 0; i < Pooling.poolable.Length; i++) Pooling.poolable[i] = null;
        Bullet.defaultObj = Resources.Load("Bullet") as GameObject;
        BulletSpread.dfBulletSpread = Resources.Load("BulletSpread") as GameObject;

    }
}
