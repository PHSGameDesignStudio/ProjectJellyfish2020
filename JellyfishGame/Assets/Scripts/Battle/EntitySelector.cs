using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySelector : MonoBehaviour
{
    public BattleManager battleManager;
    public static BattleManager.BattleState nextBattleState; // Battle State to switch to once enemy is selected.
    public static int selectedEntity = 0;
    public float cooldown;
    float timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < BattleManager.entities.Count; i++)
        {
            var e = (GameObject)BattleManager.entities[i];
            var s = e.transform.Find("selectUI").GetComponent<SpriteRenderer>();
            s.enabled = (i == selectedEntity);
        }
        if (Input.GetAxisRaw("Vertical") != 0 && timer <= 0)
        {
            selectedEntity += (int)Mathf.Round(Input.GetAxisRaw("Vertical"));
            if (selectedEntity == BattleManager.entities.Count) selectedEntity = 0;
            timer = cooldown;
        }
        timer -= Time.deltaTime;
        if (Input.GetButtonDown("Submit"))
        {
            BattleManager.battleState = nextBattleState;
            battleManager.ExecuteTurnOnEnemy();
        }
    }
    public static GameObject GetSelectedEntity()
    {
        return BattleManager.entities[selectedEntity] as GameObject;
    }
}
