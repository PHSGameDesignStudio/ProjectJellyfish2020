using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattlePlayer : MonoBehaviour
{
    int hp;
    public int maxHp = 20;
    void Start()
    {
        
        hp = maxHp;
        print(hp);
        UpdateHPUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Disables our player object if the entity isnt fighting us [Think battle player, not overworld player]
        transform.Find("PlayerController").gameObject.SetActive( BattleManager.battleState == BattleManager.BattleState.EntityTurn );

        // If HP <= 0 We want to go to death screen
        if (hp <= 0) SceneManager.LoadScene("StelDed");
    }
    public void UpdateHPUI()
    {
        var hpBox = transform.Find("hpSlider").GetComponent<HPBox>();
        hpBox.SetHP(hp, maxHp);
        hpBox.SetColor(
            Color.Lerp(Color.red, Color.green, (float)hp / (float)maxHp)
        );
    }
    public int GetHP()
    {
        return hp;
    }
    public void SetHP(int _hp)
    {
        if (hp > 0)
            hp = _hp;
    }
}
