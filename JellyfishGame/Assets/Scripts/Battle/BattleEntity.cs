using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    public float startHP;
    float hp;
    public GameObject[] attackOptions;
    public bool isAttackDone;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHP;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAttack()
    {
        transform.SetParent(null);
        if (hp > 0)
        {
            GameObject obj = Instantiate(attackOptions[0], Vector2.zero, Quaternion.identity, null) as GameObject; // Creates new attack
            obj.transform.SetParent(null); 
            obj.GetComponent<BattleEntityAttack>().entity = GetComponent<BattleEntity>(); // Gives a reference to parent
            print("YAY ATTACK" + obj);
        }
    }
    public void Damage(int hpDec)
    {
        hp -= Mathf.Abs(hpDec);
    }

}
