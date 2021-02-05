using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemObject : ScriptableObject
{
    [SerializeField] public IItem item;
}

[Serializable]
public class IItem
{
    public Sprite image;
    public string imageResourcePath;

    public string Name;
    public string Description;
    public string Type;

    public int booster_hp;
    public float booster_speed;
    public int booster_attackDmg;
    public int booster_magicDmg;

    public float durability;
}
