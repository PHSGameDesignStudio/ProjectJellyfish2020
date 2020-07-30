using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Script : MonoBehaviour
{
    public Collider2D collision;
    public Component TextManager;
    public Text_Manager Canvas;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Canvas.Dialouge = 1;
        TextManager.GetComponent<Camera>().enabled = false;
    }
}
