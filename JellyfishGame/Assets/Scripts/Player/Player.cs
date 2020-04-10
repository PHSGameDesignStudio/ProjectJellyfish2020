using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Default Values
    public static int hp = -100;
    public static float speed = 5;
    public static int attackDmg = 2;
    public static int magicDmg = 4;
    public static int maxHp = 20;
    

    // Item Boosters you can select in inventory
    public struct ItemBoosterID
    {
        // -1 means null if we code it right
        public static int speed = -1;
        public static int attackDmg = -1;
        public static int magicDmg = -1;
    }
    void Start()
    {
        if (hp == -100)
        {
            hp = maxHp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Heal(int hpToHeal)
    {
        hp += hpToHeal;
        if (hp > maxHp) hp = maxHp; // So that hp doesn't go over the limit.

        BattlePlayer.player.UpdateHPUI();
    }

    #region Get Values With Item Boosters
    public static float GetSpeed()
    {
        if (ItemBoosterID.speed != -1) // If we are using an item booster
        {
            return Item_Manager.items[ItemBoosterID.speed].booster_speed;
            // I may consider code here that reduces the durability of an item to the point that its ded.
        } 
        else // If we aren't using an item booster
        {
            return speed;
        }
    }
    public static int GetAttackDmg()
    {
        if (ItemBoosterID.attackDmg != -1) // If we are using an item booster
        {
            return Item_Manager.items[ItemBoosterID.attackDmg].booster_attackDmg;
            // I may consider code here that reduces the durability of an item to the point that its ded.
        }
        else // If we aren't using an item booster
        {
            return attackDmg;
        }
    }
    public static int GetMagicDmg()
    {
        if (ItemBoosterID.magicDmg != -1) {// If we are using an item booster
            return Item_Manager.items[ItemBoosterID.magicDmg].booster_magicDmg;
            // I may consider code here that reduces the durability of an item to the point that its ded.
        }
        else // If we aren't using an item booster
        {
            return magicDmg;
        }
    }
    #endregion

    #region SaveSystem
    void Save()
    {

    }
    void Open()
    {

    }
    #endregion
}
