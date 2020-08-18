using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Transform player;
    public Text_Manager textManager;
    public SpriteRenderer jumpCut;
    public Cinemachine.CinemachineVirtualCamera Camera;
    public bool atEnd = true;

    public IEnumerator Teleport(Transform newPos)
    {
        StartCoroutine(FadeOut());
        Debug.Log("yeet");
        while (!atEnd)
        {
            yield return null;
        }
        player.position = newPos.position;
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOut()
    { 
        for(int i = 0; i < 255; i++)
        {
            jumpCut.color = new Color(1f, 1f, 1f, i);
            yield return new WaitForSeconds(.0078f);      
        }
        atEnd = false;
        StopCoroutine(FadeOut());
    }
    IEnumerator FadeIn()
    {
        for (int i = 255; i > 0; i = i-1)
        {
            jumpCut.color = new Color(1f, 1f, 1f, i);
            yield return new WaitForSeconds(.0078f);
        }
        atEnd = true;
        StopCoroutine(FadeIn());
    }
    public void MoveCamera(Transform newPos)
    {
        Camera.Follow = newPos;
    }
}
