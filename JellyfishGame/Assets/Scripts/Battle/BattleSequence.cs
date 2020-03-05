using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
/// <summary>
/// A manager for most battles in game.
/// </summary>
namespace BattleEngine {
    public class BattleSequence : MonoBehaviour {
        public Vector2[] battleTimes;
        public GameObject[] battles;
        private int i = 0;
        public float timer = 0;
        private void Awake()
        {
            

        }
        private void Start()
        {
            NextBattle();
        }
        void Update()
        {
            if (timer <= 0)
            {
                EndBattle();
                NextBattle();
            }
            timer -= Time.deltaTime;
        }
        void NextBattle()
        {
            timer = Random.Range(battleTimes[i].x, battleTimes[i].y);
            battles[i].SetActive(true);
        }
        void EndBattle()
        {
            battles[i].SetActive(false);
            i += 1;
            if (i == battles.Length) i = 0;
        }
    }
}
