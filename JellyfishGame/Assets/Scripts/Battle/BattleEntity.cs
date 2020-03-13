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
    SpriteRenderer spRenderer;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHP;
        DontDestroyOnLoad(gameObject);
        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spRenderer.enabled = (BattleManager.battleState == "PLAYER");
    }
    public void StartAttack()
    {
        transform.SetParent(null);
        if (hp > 0)
        {
            GameObject obj = GameObject.Find("InstantiateRunner").GetComponent<InstantiateRunner>().Make(attackOptions[0]) as GameObject; // Creates new attack
            obj.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
            print(SceneManager.GetActiveScene().name);
            obj.GetComponent<BattleEntityAttack>().entity = GetComponent<BattleEntity>(); // Gives a reference to parent
            print("YAY ATTACK" + obj.scene.name);
        }
    }
    public void Damage(int hpDec)
    {
        hp -= Mathf.Abs(hpDec);
    }

}
