using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP1UP : MonoBehaviour
{
    // The effect that makes the amount of HP appear above the health bar.
    public static void MakeAt(string hp, Vector3 pos, Color color)
    {
        GameObject hp1Up = Instantiate(Resources.Load("HP/HPText1UP_Parent")) as GameObject; // Parent
        hp1Up.transform.position = pos; // Position
        var tmpro = hp1Up.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>();
        tmpro.text = hp;
        tmpro.color = color;
    }

}
