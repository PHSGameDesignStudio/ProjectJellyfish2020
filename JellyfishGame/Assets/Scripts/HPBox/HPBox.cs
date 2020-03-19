using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBox : MonoBehaviour
{
    public void SetHP(float hp, float totalhp)
    {
        var text = transform.Find("Text").GetComponent<TMPro.TextMeshPro>();
        var hpGraphics = transform.Find("Base").transform.Find("hpGraphics");
        var y = hp / totalhp;
        if (y <= 0.05f) y = 0;
        hpGraphics.transform.localScale = new Vector3(hpGraphics.transform.localScale.x, y);
        text.text = hp.ToString() + "/" + totalhp.ToString();
    }
    public void SetColor(Color color)
    {
        var hpGraphics = transform.Find("Base").transform.Find("hpGraphics").GetComponent<SpriteRenderer>();
        hpGraphics.color = color;
    }
    public Color GetColor()
    {
        return transform.Find("Base").transform.Find("hpGraphics").GetComponent<SpriteRenderer>().color;
    }
}
