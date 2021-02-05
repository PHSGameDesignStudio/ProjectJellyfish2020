using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player_Manager Player;
    public CharScript player;
    public GameObject Object;
    public int Event;
    public Text_Manager textManager;
    public int itemNumber;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey("e"))
        {
            if (Player.Inventory[0] != 0)
            {
                InventoryFull();
            }
            else
            {
                for (int h = 0; h < Player.Inventory.Length; h++)
                {
                    if (Player.Inventory[h] == 0)
                    {
                        Player.Inventory[h] = itemNumber;
                        break;
                    }
                }
                CollectedItem();
            }
        }
    }
    private void InventoryFull()
    {
        textManager.Dialouge = 4;
        Setup();
    }
    private void CollectedItem()
    {
        textManager.Dialouge = Event;
        Setup();
        Destroy(Object);
    }
    private void Setup()
    {
        textManager.Dialouge = Event;
        Debug.Log(Event);
        textManager.enabled = false;
        textManager.enabled = true;
        player.animator.SetBool("Backward", false);
        player.animator.SetBool("Forward", false);
        player.animator.SetBool("Walking", false);
        player.Flip();
    }
}
