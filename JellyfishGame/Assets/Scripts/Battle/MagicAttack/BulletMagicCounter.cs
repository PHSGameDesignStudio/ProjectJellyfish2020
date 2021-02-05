using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagicCounter : MonoBehaviour
{
    int hitpts = 0;
    public string targetTag;
    public float amountOfTime;
    float timer;
    void Start()
    {
        timer = amountOfTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            DamageEntity();
        }
        timer -= Time.deltaTime;
    }
    public void DamageEntity()
    {
        EntitySelector.GetSelectedEntity().GetComponent<BattleEntity>().Damage(hitpts);
        BattleManager.battleState = BattleManager.BattleState.EntityTurn; // Need to call StartBattle();
        BattleManager.GetScript().StartBattle();
        Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            hitpts += 1;
            SFXManager.ResetSFX("SwordDraw" + hitpts);
            Destroy(collision.gameObject);
        }
    }
}
