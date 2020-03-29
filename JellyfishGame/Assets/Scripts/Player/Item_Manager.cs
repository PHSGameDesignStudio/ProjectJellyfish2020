using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//mental note, make sure if script is actually getting GameObject
public class Item_Manager : MonoBehaviour
{
    Button[] Boxes = new Button[8];
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
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
    void Update()
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
    public void Selector(int ButtonNum)
    {
        myButtonNum = ButtonNum-1;
        if(Boxes[myButtonNum].image.sprite == Image1) //Sword 
        {
            //DealDamage()
            Type = "Weapon";
        }
        else if(Boxes[myButtonNum].image.sprite == Image2) //Trident
        {
            //DealDamage()
            Type = "Weapon";
        }
        else if(Boxes[myButtonNum].image.sprite == Image3) //Consumable
        {
            //Heal()
            //DeleteItem()
            Type = "Consumable";
        }
        else if(Boxes[myButtonNum].image.sprite == Image4) //Map
        {
            //OpenMap()
            Type = "Map";
        }
        else{Type = "Null";}
        Debug.Log(Type);
    }
    public void Drop()
    {
        Boxes[myButtonNum].image.sprite = null;
        Type = "null";
    }
    public void Use()
    {
        if(Type == "Consumable")
        {
            HPBar.value += 5;
            Drop();
        }
    }
    public void Explination()
    {
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
        }
    }
}
