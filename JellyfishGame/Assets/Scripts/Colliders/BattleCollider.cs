using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleCollider : MonoBehaviour
{
    public BattleManagerObject battleData;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            BattleManager.battleSettings = battleData;
            SceneManager.LoadScene("Battle");
        }
    }
}
