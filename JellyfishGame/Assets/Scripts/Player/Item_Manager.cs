using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
//mental note, make sure if script is actually getting GameObject
public class Item_Manager : MonoBehaviour
{
    public Text EquipButtonText; // This is the button that is equipping/using items
    private string useButtonTextStr = "Use";
    // ^^ Can be out of three options "use", "equip", "unequip".


    Button[] Boxes = new Button[8];
    public static IItem[] items = new IItem[8] { // Temporary inventory, testing. When the player starts the game they'll obviously start with nothing.
            Items.sushi,
            Items.sword,
            Items.trident,
            Items.map,
            null,
            null,
            null,
            null,
        };
    // Bruh Miguel consider using an array list. Array Lists CAN BE EDITED IN THE INSPECTOR -samuel
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;
    public Sprite Image7;
    public Sprite Image8;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Slider HPBar;
    public Text Explain;
    private string Type;
    private int myButtonNum;

    

    public bool battleMode;
    private void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(Button1.gameObject);
        SetBoxes();
        SetImages();
    }
    void Update()
    {
        SetBoxes(); // Should this always be in update miguel? This is being called each frame! -sam
        if (items[myButtonNum].Type == "Consumable" || items[myButtonNum].Type == "SpeedPotion") EquipButtonText.text = "Use";
        else if (items[myButtonNum].Type == "AttackDmg")
        {
            print("WEAPON");
            if (isItemEquipped()) EquipButtonText.text = "Equip";
            else EquipButtonText.text = "Unequip";
        }

    }
    void SetBoxes()
    {
        Boxes[0] = Button1;
        Boxes[1] = Button2;
        Boxes[2] = Button3;
        Boxes[3] = Button4;
        Boxes[4] = Button5;
        Boxes[5] = Button6;
        Boxes[6] = Button7;
        Boxes[7] = Button8;
    }
    void SetImages()
    {
        for (int i = 0; i < Boxes.Length; i++)
        {

            if (items[i] != null)
            {
                Texture2D texture = Resources.Load(items[i].imageResourcePath) as Texture2D;
                Boxes[i].image.sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                
            }
        }
    }
    public void Selector(int ButtonNum)
    {
        // Types are Weapon, Consumable, ManaConsumable, SpeedPotion, Map
        myButtonNum = ButtonNum-1; // Because code counts from 0

        if (items[myButtonNum] != null) Type = items[myButtonNum].Type;
        else { Type = "Null"; }
        Debug.Log(Type);
    }
    public void Drop()
    {
        Boxes[myButtonNum].image.sprite = null;
        Type = "null";
    }
    public void Use()
    {
        if (EquipButtonText.text == "Use") RegularUse();
        else if (EquipButtonText.text == "Equip" || EquipButtonText.text == "Unequip") Equip();

        // At the end we need to figure out where to go next
        if (battleMode) {
            BattleManager.manager.StartBattle();
            BattleManager.battleState = BattleManager.BattleState.EntityTurn; 
        }
    }
    public void RegularUse() 
    {
        if (Type == "Consumable")
        {
            Player.Heal(items[myButtonNum].booster_hp);
            print(items[myButtonNum].booster_hp);
            Drop();
        }
        if (Type == "SpeedPotion")
        {
            Player.ItemBoosterID.speed = myButtonNum;
            Drop();
        }
    }
    public void Equip()
    {
        if (Type == "AttackDmg")
        {
            if (isItemEquipped()) // Is this item already equipped?
                Player.ItemBoosterID.attackDmg = myButtonNum; // Equip
            else Player.ItemBoosterID.attackDmg = -1; // Dont Equip
        }
                    
                    
                    // if this is already equipped maybe change equip button to unequip??
    }
    bool isItemEquipped() 
    {
        return Player.ItemBoosterID.attackDmg != myButtonNum;
    }
    public void Explination()
    {
        Explain.text = items[myButtonNum].Description;
        /*
        if(Boxes[myButtonNum].image.sprite == Image2)
        {
            Explain.text = "A Basic Swinging Weapon";
        }
        else if(Boxes[myButtonNum].image.sprite == Image1)
        {
            Explain.text = "A Sharp Fork";
        }
        else if(Boxes[myButtonNum].image.sprite == Image4)
        {
            Explain.text = "A Map of the Surrounding Area";
        }
        else
        {
            Explain.text = "No Explination for this item yet";
        }*/
    }
}
