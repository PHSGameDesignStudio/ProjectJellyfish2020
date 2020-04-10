﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlider : MonoBehaviour
{
    public float speed;
    KeyCode attackKey;
    bool isInArea = false;
    bool isInGoal = false;
    bool sliderHit = false;
    int hitpts = 0;
    float endX; // Where the slider ends
    bool attackSent = false;
    ArrayList feedbackItems;
    void Start()
    {
        attackKey = KeyCode.Return;
        endX = Mathf.Abs(transform.position.x);
        print(endX);
        feedbackItems = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
        if (isInArea) {
            if (Input.GetKeyDown(attackKey)) {
                if (isInGoal && !sliderHit)
                {
                    hitpts += 1;
                    SFXManager.ResetSFX("SwordDraw" + hitpts); // It will add different hit points so we can have changes in pitch.
                }
                sliderHit = true;
                SliderHit();
            }
        } else
        {
            sliderHit = false;
        }
        print(hitpts);
        if (transform.position.x > endX && !attackSent)
        {
            attackSent = true;
            SFXManager.ResetSFX("EnemyHit");
            DamageEntity();
        }
        
    }
    public void SliderHit()
    {
        var hitFeedback = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        Destroy(hitFeedback.GetComponent<AttackSlider>());
        hitFeedback.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        hitFeedback.transform.localScale = new Vector3(0.1f, hitFeedback.transform.localScale.y, 0);
        feedbackItems.Add(hitFeedback);
    }
    public void DamageEntity()
    {
        var chancesToHit = 4; // this is the amount of chances spawned by AttackBox.cs
        var realHitPts = ((float)hitpts / (float)chancesToHit) * Player.GetAttackDmg(); // multiply so we can change the amount of dmg
        EntitySelector.GetSelectedEntity().GetComponent<BattleEntity>().Damage((int)realHitPts);
        BattleManager.battleState = BattleManager.BattleState.EntityTurn; // Need to call StartBattle();
        BattleManager.GetScript().StartBattle();
        var attBox = transform.parent.GetComponent<AttackBox>();
        attBox.DestroyAreas();
        DestroyFeedbackItems();
        Destroy(attBox.gameObject);
        Destroy(gameObject);
    }
    public void DestroyFeedbackItems()
    {
        foreach (GameObject item in feedbackItems)
            Destroy(item);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "AttackArea":
                isInArea = true;
                break;
            case "AttackGoal":
                isInGoal = true;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "AttackArea":
                isInArea = false;
                break;
            case "AttackGoal":
                isInGoal = false;
                break;
        }
    }
}
