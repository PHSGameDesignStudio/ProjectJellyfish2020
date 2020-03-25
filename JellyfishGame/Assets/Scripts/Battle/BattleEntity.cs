using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEntity : MonoBehaviour
{
    public float startHP;
    float hp;
    public GameObject[] attackOptions;
    public bool isAttackDone;
    public SpriteRenderer spRenderer = null;
    public int n, i;
    SpriteRenderer selectUI;
    public HPBox hpbox;
    public BattleManager battleManager;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHP;
        DontDestroyOnLoad(gameObject);
        if (spRenderer == null) spRenderer = GetComponent<SpriteRenderer>();
        selectUI = transform.Find("selectUI").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    
    public void StartAttack()
    {
        transform.SetParent(null);
        if (hp > 0)
        {
            var o = Random.Range(0, attackOptions.Length);
            print("AO: " + o);
            GameObject obj = Instantiate(attackOptions[o]) as GameObject; // Creates new attack
            obj.transform.SetParent(null);
            obj.GetComponent<BattleEntityAttack>().entity = this; // Gives a reference to parent
            print("YAY ATTACK" + obj.scene.name);
        } else
        {
            isAttackDone = true;
            // Make it so that this entity dissapears, maybe do it in animation or crap!
        }
    }
    public void Damage(int hpDec)
    {
        hp -= Mathf.Abs(hpDec);
    }
    public void Update()
    {
        spRenderer.enabled = BattleManager.isItPlayerTurn();
        gameObject.SetActive(!isAttackDone);
        SetPosition();
        hpbox.SetHP(hp, startHP);

        // If we arent selecting any entities there is no need to show the select sprite.
        if (BattleManager.battleState != BattleManager.BattleState.PlayerSelectEntity) 
            selectUI.enabled = false;
    }
    public void SetPosition()
    {
        if (n != 0)
        {
            transform.position = new Vector3(
                (CameraData.width / 2) * (5f / 6f),
                (((float)i / (float)n) * (CameraData.height / 2f)) - (CameraData.height / 4f)
            );
        }
        else
        {
            transform.position = new Vector3(
                (CameraData.width / 2) * (5f / 6f), 0
            );
        }
    }
    

}
