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
        if (spRenderer == null) spRenderer = transform.Find("sprite").GetComponent<SpriteRenderer>();
        selectUI = transform.Find("selectUI").GetComponent<SpriteRenderer>();
        hpbox.SetHP(hp, startHP);
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
        if (hp == 1 && hpDec >= 1)
        {
            // Called when the player wants to destroy the entity
            BattleManager.entities.Remove(gameObject); // removing the entities so we dont get null errors
            Destroy(gameObject); // Destroying this object.
        }
        else
        {
            // So that the player has the chance to spare
            hp -= Mathf.Abs(hpDec);
            if (hp < 1) hp = 1;
        }
        hpbox.SetHP(hp, startHP);
    }
    public void DamageFeedback(int hpDec)
    {
        HP1UP.MakeAt(hpDec + "-", transform.position, Color.red);
        int newHp = (int)hp - hpDec;
        if (newHp < 1) newHp = 1;
        hpbox.SetHP(newHp, startHP);
    }
    public void Update()
    {
                            
        //gameObject.SetActive(attackDone);
        SetPosition();
        

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
