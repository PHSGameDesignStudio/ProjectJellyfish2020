using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Manager : MonoBehaviour
{
    public int TextBoxWidth;
    public GameObject TextBox;
    Vector3 theWidth;
    public GameObject[] textDialougeList = new GameObject[] { };
    public int Dialouge = 0;
    void Start()
    {
        TextBox.SetActive(true);
        theWidth = TextBox.transform.localScale;
        theWidth.x = 0;
        TextBox.transform.localScale = theWidth;
        StartCoroutine(TextboxAnimate());
    }
    IEnumerator TextboxAnimate()
    {
        theWidth = TextBox.transform.localScale;
        for (int i = 0; i < (TextBoxWidth) + 1; i = i+25)
        {
            theWidth.x = i;
            TextBox.transform.localScale = theWidth;
            yield return new WaitForSeconds(.01f);
        }
        textDialougeList[Dialouge].SetActive(true);
        
    }
    IEnumerator TextBoxAnimateOff()
    {
        textDialougeList[Dialouge].SetActive(false);
        theWidth = TextBox.transform.localScale;
        for (int i = TextBoxWidth; i > 0; i = i - 25)
        {
            theWidth.x = i;
            TextBox.transform.localScale = theWidth;
            yield return new WaitForSeconds(.01f);
        }
        TextBox.SetActive(false);
        Dialouge += 1;
    }
    // Update is called once per frame
    public void Close()
    {
        StartCoroutine(TextBoxAnimateOff());
    }
    private void OnEnable()
    {
        Start();
    }
}
