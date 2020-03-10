using UnityEngine;
using System.Collections;
public class Fade : MonoBehaviour
{
    public float maxTime;
    public bool fadeIn;
    float currentTime;
    int m; // Determines whether we are fading in or out.
    SpriteRenderer spRenderer;
    public GameObject spriteObj = null; // Allows for setting this object to a child. By default this is the parent gameObject
    Color mainColor;
    private void Start()
    {
        var f = 1;
        if (fadeIn) f = 0;
        currentTime = maxTime * f;

        m = -1;
        if (fadeIn) m = 1;

        if (spriteObj == null)
            spriteObj = gameObject;

        spRenderer = spriteObj.GetComponent<SpriteRenderer>();
        mainColor = spRenderer.color;
    }
    void Update()
    {
        spRenderer.color = Color.Lerp(new Color(mainColor.r, mainColor.g, mainColor.b, 0), mainColor, currentTime / maxTime);
        currentTime += Time.deltaTime * m;
        if (currentTime <= 0) Destroy(this);
    }

    public static IEnumerator Do(string type, GameObject obj, float time)
    {
        var f = obj.AddComponent<Fade>();
        f.maxTime = time / 2;
        f.fadeIn = false;
        if (type == "in") f.fadeIn = true;
        f.spriteObj = obj;
        yield return new WaitForSeconds(time);
        Destroy(f);
        Destroy(obj.GetComponent<Fade>());
    }
    public static void MakeOverlay(bool fadeIn = true, float seconds = 1.0f)
    {
        var f = ((GameObject)Instantiate(Resources.Load("FadeOverlay"))).GetComponent<Fade>();
        f.fadeIn = fadeIn;
        f.maxTime = seconds;

    }
}
