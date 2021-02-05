using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BattleEntityObject", order = 1)]
public class BattleEntityObject : ScriptableObject
{
    public GameObject[] ObjectAtks;
    public BattleEntityAttack[] scriptAtks;
}
