using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Manager : MonoBehaviour
{
    public int HPLevel;
    public int XPLevel;
    public string charName;
    public int[] Inventory = new int[8] {0,0,0,0,0,0,0,0};
    public Slider HPSlider;
    public Slider XPSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
