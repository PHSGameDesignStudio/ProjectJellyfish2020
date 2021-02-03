using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardBehaviour : MonoBehaviour
{
    Card card;
    Vector3 localScale;
    void Start()
    {
        localScale = Vector3.one;
        card = new Card();
    }
    void Update()
    {
        
    }
    public void UpdateThisCard(Card _card)
    {
        card = _card;
        transform.Find("rune").GetComponent<SpriteRenderer>().sprite = _card.icon;
        transform.Find("name").GetComponent<TextMeshPro>().text = _card.name;
        transform.Find("description").GetComponent<TextMeshPro>().text = _card.description;
    }
    public Vector3 GetVariableLocalScale()
    {
        return localScale;
    }
}
