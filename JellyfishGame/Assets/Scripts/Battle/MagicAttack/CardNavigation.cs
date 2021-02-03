using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNavigation : MonoBehaviour
{
    public static int selected = 0;
    public static ArrayList cards = new ArrayList() {
        Cards.acidicrainshower,
        Cards.thunderstorm,
    };
    public static ArrayList cardsWithMagicLvl = new ArrayList();
    public static ArrayList cardObjects = new ArrayList();
    public static int magicLevel = 1000; // May be able to move to a player class
    public GameObject cardReference;
    public float cardDistance;
    public float selectionCooldown;
    float selectionTimer;
    public void Start()
    {
        cardsWithMagicLvl = GetCardsWithMagicLevel();
        for(int i = 0; i < cardsWithMagicLvl.Count; i++)
        {
            Card card = cardsWithMagicLvl[i] as Card;
            print(card.name);
            var cardObj = Instantiate(cardReference) as GameObject;
            cardObj.GetComponent<CardBehaviour>().UpdateThisCard(card);
            cardObj.transform.position = new Vector3(cardDistance * i, 0);
            cardObjects.Add(cardObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cardDistance * selected, 0, -10);
        // Update Selected
        var axis = Input.GetAxisRaw("Horizontal");
        if ( axis != 0 && selectionTimer <= 0)
        {
            // If statements ensure we dont go outside the array
            if (axis > 0 && selected < cardsWithMagicLvl.Count - 1) selected += 1;
            if (axis < 0 && selected > 0) selected -= 1;
            selectionTimer = selectionCooldown;

            // Set selected sprite
            SetSelectedSprite();
        }
        if (Input.GetButtonDown("Submit"))
        {
            Instantiate(Resources.Load(
                ((Card)cardsWithMagicLvl[selected]).MinigameResourceName
            ));
            BattleManager.battleState = BattleManager.BattleState.Player;
            PackUp(); // Time to pack up / destroy these objects
        }
        selectionTimer -= Time.deltaTime;
    }
    public ArrayList GetCardsWithMagicLevel()
    {
        ArrayList _cards = new ArrayList();
        foreach (Card card in CardNavigation.cards)
        {
            if (card.requiredMagicLevel <= magicLevel)
                _cards.Add(card);
        }
        return _cards;
    }
    public void SetSelectedSprite()
    {
        for (var i = 0; i < cardsWithMagicLvl.Count; i++)
        {
            var cardObj = (GameObject)cardObjects[i];
            cardObj.transform.Find("selected").gameObject.SetActive(i == selected);
            if (i == selected)
                cardObj.transform.localScale = cardObj.GetComponent<CardBehaviour>().GetVariableLocalScale() * 1.25f;
            else
                cardObj.transform.localScale = cardObj.GetComponent<CardBehaviour>().GetVariableLocalScale() * 1f;
        }   
    }
    // Destroys everything related to cards in game.
    public void PackUp()
    {
        foreach (GameObject obj in cardObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
