using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBox : MonoBehaviour
{
    public void SetHP(float hp, float totalhp, bool ease = true, bool setColor = true)
    {
        var text = transform.Find("Text").GetComponent<TMPro.TextMeshPro>();
        var hpGraphics = transform.Find("Base").transform.Find("hpGraphics");
        var y = hp / totalhp;
        if (y <= 0.05f) y = 0;
        if (!ease) hpGraphics.localScale = new Vector3(hpGraphics.transform.localScale.x, y);
        else LeanTween.scaleY(hpGraphics.gameObject,y,1).setEase(LeanTweenType.easeInSine);
        text.text = hp.ToString() + "/" + totalhp.ToString();
        if (setColor) SetColor(hp, totalhp);
    }
    public void SetColor(Color color)
    {
        var hpGraphics = transform.Find("Base").transform.Find("hpGraphics").GetComponent<SpriteRenderer>();
        hpGraphics.color = color;
    }
    public void SetColor(float hp, float totalHp)
    {
        SetColor(Lerp3(Color.red, Color.yellow, Color.green, (float)hp / (float)totalHp));
    }
    public Color GetColor()
    {
        return transform.Find("Base").transform.Find("hpGraphics").GetComponent<SpriteRenderer>().color;
    }

    Color Lerp3(Color a, Color b, Color c, float t)
    {
        if (t < 0.5f) // 0.0 to 0.5 goes to a -> b
            return Color.Lerp(a, b, t / 0.5f);
        else // 0.5 to 1.0 goes to b -> c
            return Color.Lerp(b, c, (t - 0.5f) / 0.5f);
    }
}
