using System.Collections;
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
    void Start()
    {
        attackKey = KeyCode.Return;
        endX = Mathf.Abs(transform.position.x);
        print(endX);
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
            DamageEntity();
            attackSent = true;
        }
        
    }
    public void SliderHit()
    {
        var hitFeedback = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        Destroy(hitFeedback.GetComponent<AttackSlider>());
        hitFeedback.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        hitFeedback.transform.localScale = new Vector3(0.1f, hitFeedback.transform.localScale.y, 0);
    }
    public void DamageEntity()
    {
        EntitySelector.GetSelectedEntity().GetComponent<BattleEntity>().Damage(hitpts);
        BattleManager.battleState = BattleManager.BattleState.EntityTurn; // Need to call StartBattle();
        BattleManager.GetScript().StartBattle();
        var attBox = transform.parent.GetComponent<AttackBox>();
        attBox.DestroyAreas();
        Destroy(attBox.gameObject);
        Destroy(gameObject);
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
