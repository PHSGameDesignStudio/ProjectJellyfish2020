using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public Transform amon;
    public Transform stel;
    public EventManager eventManager;
    public Text_Manager textManager;
    public Transform newPosition;
    public int atEnd = 0;
    public bool atEnd2 = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("loookokok");
        StartCoroutine(Setup(stel, 5));
        
        
        //eventManager.StartFadeOut();
        //eventManager.StartFadeIn();
        //
    }

    private void Update()
    {
        if (atEnd2)
        {
            if (atEnd == 1) { StartCoroutine(Setup(amon, 6)); }
            else if (atEnd == 2) { StartCoroutine(Setup(stel, 7)); }
            else if (atEnd == 3) 
            { 
                StartCoroutine(eventManager.Teleport(newPosition));
                atEnd++;
            }
            else if (atEnd == 4) { DestroyObject(this); }
        }
    }
    public void TurnOnNewMessage()
    {
        textManager.enabled = false;
        textManager.enabled = true;
    }
    public IEnumerator Setup(Transform lookingObject, int dialouge)
    {
        atEnd2 = false;
        eventManager.MoveCamera(lookingObject);
        textManager.Dialouge = dialouge;
        TurnOnNewMessage();
        while (textManager.TextBox.activeSelf == true)
        {
            yield return null;
        }
        atEnd++;
        atEnd2 = true;
        StopAllCoroutines();
    }
}
