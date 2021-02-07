using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BattleManagerObject", order = 2)]
public class BattleManagerObject : ScriptableObject
{
    public string audioRef = "Get_battle"; // audio reference
    public string[] entitiesRef = new string[3] { "ent_anglerFish", "ent_Jelly", "ent_meanFish" }; // entities reference
    public string sceneName = "Ocean";
    public int minEnemies = 1; // Inclusive
    public int maxEnemies = 3; // Inclusive
}
