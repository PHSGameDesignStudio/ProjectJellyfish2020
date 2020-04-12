using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Typewriter : MonoBehaviour
{
    public Text textBox;
    public Text goatTalkingText;
    public Text Check;
    public string[] goatText = new string[] {""};
    //Store all your text in this string array
    bool AtEnd = false;
    int currentlyDisplayingText = 0;
    public Text_Manager other;
    void Start()
    {
        AtEnd = false;
        currentlyDisplayingText = 0;
        StartCoroutine(AnimateText());
    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        AtEnd = false;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        StartCoroutine(AnimateText());
    }
    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {
        for (int i = 0; i < (goatText[currentlyDisplayingText].Length)+1; i++)
        {
            goatTalkingText.text = goatText[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.04f);
        }
        AtEnd = true;
        
    }
    public void CheckIf()
    {
        if (Input.GetButton("Fire1") && AtEnd)
        {
            if (currentlyDisplayingText+1 == goatText.Length)
            {
                goatTalkingText.text = "";
                StopAllCoroutines();
                this.enabled = false;
            }
            else { SkipToNextText(); }
        }
    }
    void Update()
    {
        CheckIf();
    }
    void OnDisable()
    {
        goatTalkingText.text = " ";
        other.Close();
    }
    private void Awake()
    {
        Start();
    }
}