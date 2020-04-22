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
        print(mainColor);
    }
    void Update()
    {
        spRenderer.color = Color.Lerp(new Color(mainColor.r, mainColor.g, mainColor.b, 0), new Color(mainColor.r, mainColor.g, mainColor.b, 1), currentTime / maxTime);
        currentTime += Time.deltaTime * m;
        //print(currentTime);
        //print(Time.deltaTime * m);
        if (currentTime <= 0) Destroy(this);
    }

    public static IEnumerator Do(string type, GameObject obj, float time)
    {
        var f = obj.AddComponent<Fade>();
        f.spriteObj = obj;
        f.maxTime = time;
        f.fadeIn = false;
        if (type == "in") f.fadeIn = true;
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
