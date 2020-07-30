using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Typewriter : MonoBehaviour
{
    public Text textBox;
    public Text goatTalkingText;
    public Text Check;
    public string[] goatText = new string[] {""};
    public string[] Face = new string[] {};
    //Store all your text in this string array
    bool AtEnd = false;
    int currentlyDisplayingText = 0;
    GameObject[] Faces = new GameObject[] { };
    public Text_Manager other;
    void Start()
    {
        Faces = other.Faces;
        AtEnd = false;
        currentlyDisplayingText = 0;
        StartCoroutine(AnimateText());
        ChooseFace(currentlyDisplayingText);
    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();

        for (int g = 0; g < Faces.Length; g++) { Faces[g].SetActive(false); }
        currentlyDisplayingText++;
        AtEnd = false;
        //If we've reached the end of the array, do anything you want. I just restart the example text

        StartCoroutine(AnimateText());
        ChooseFace(currentlyDisplayingText);
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
        if (Input.GetKeyDown(KeyCode.Space) && AtEnd)
        {
            if (currentlyDisplayingText+1 == goatText.Length)
            {
                for (int g = 0; g < Faces.Length; g++) { Faces[g].SetActive(false); }
                goatTalkingText.text = "";
                StopAllCoroutines();
                this.enabled = false;
            }
            else {SkipToNextText(); 
            }
        }
    }
    void Update()
    {CheckIf();}
    void OnDisable()
    {
        goatTalkingText.text = " ";
        other.Close();
    }
    private void Awake()
    {Start();}
    private void ChooseFace(int i)
    {
        if (Face[i] == "stel") { Faces[0].SetActive(true); }
        else if (Face[i] == "jel") { Faces[1].SetActive(true); }
        else if (Face[i] == "stelSurprise") { Faces[2].SetActive(true); }
    }
}