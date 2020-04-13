using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Manager : MonoBehaviour
{
    public int TextBoxWidth;
    public GameObject TextBox;
    Vector3 theWidth;
    public GameObject[] textDialougeList = new GameObject[] { };
    public GameObject[] textDialougeTriggers = new GameObject[] { };
    public int Dialouge = 0;
    public GameObject Player;
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
        Player.GetComponent<CharScript>().enabled = false;
        for (int i = 0; i < (TextBoxWidth) + 1; i = i + 25)
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
        Player.GetComponent<CharScript>().enabled = true;
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
    private void Checkif()
    {
        for (int i = 0; i < textDialougeTriggers.Length+1; i = i + 2)
        {
            if (textDialougeTriggers[i] != null)
            {
                Transform triggerPosTL = textDialougeTriggers[i].GetComponent<Transform>();
                Transform triggerPosBR = textDialougeTriggers[i + 1].GetComponent<Transform>();
                Transform playerPos = Player.GetComponent<Transform>();
                Debug.Log("yote");
                if (playerPos.localPosition.x > triggerPosTL.localPosition.x && playerPos.localPosition.y < triggerPosTL.localPosition.y && playerPos.localPosition.x < triggerPosBR.localPosition.x && playerPos.localPosition.y > triggerPosBR.localPosition.y)
                {
                    Debug.Log("yeet");
                    Destroy(textDialougeTriggers[i]);
                    Destroy(textDialougeTriggers[i + 1]);
                    textDialougeTriggers[i] = textDialougeTriggers[i + 1] = null;
                    Dialouge = i / 2 + 1;
                    Start();
                }
            }

        }
    }
    private void Update()
    {
        Checkif();
    }
}
