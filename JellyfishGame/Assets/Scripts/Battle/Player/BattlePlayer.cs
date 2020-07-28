using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattlePlayer : MonoBehaviour
{
    public static BattlePlayer player;
    void Start()
    {
        player = this;
        UpdateHPUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Disables our player object if the entity isnt fighting us [Think battle player, not overworld player]
        transform.Find("PlayerController").gameObject.SetActive( BattleManager.battleState == BattleManager.BattleState.EntityTurn );

        // If HP <= 0 We want to go to death screen
        if (Player.hp <= 0) SceneManager.LoadScene("StelDed");
    }
    public void UpdateHPUI()
    {
        var hpBox = transform.Find("hpSlider").GetComponent<HPBox>();
        hpBox.SetHP(Player.hp, Player.maxHp, ease: true);
        hpBox.SetColor(
            Color.Lerp(Color.red, Color.green, (float)Player.hp / (float)Player.maxHp)
        );
    }
    public void UpdateManaUI()
    {
        var hpBox = transform.Find("manaSlider").GetComponent<HPBox>();
        hpBox.SetHP(Player.mana, Player.maxMana, ease: true, setColor: false);
    }
    public int GetHP()
    {
        return Player.hp;
    }
    public void SetHP(int _hp)
    {
        if (Player.hp > 0)
            Player.hp = _hp;
    }
}
