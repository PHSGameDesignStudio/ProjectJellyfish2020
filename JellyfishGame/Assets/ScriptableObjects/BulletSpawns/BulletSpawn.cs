using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawn", order = 1)]
public class BulletSpawn : ScriptableObject
{
    public Sprite bulletSprite;
    public GameObject bulletObject;
    public int numOfBullets;
    public float minRotation;
    public float maxRotation;
    public float minBulletSpeed;
    public float bulletSpeed;
    public float cooldown;
    public bool isRandom = false;
    public bool isParent = false;
}
