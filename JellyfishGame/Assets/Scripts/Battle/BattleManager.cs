﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public static BattleManagerObject battleSettings;
    //public GameObject[] RefEntities;
    public static ArrayList entities;
    public enum BattleState
    {
        PlayerMain,
        PlayerAttack,
        PlayerMagic,
        PlayerInventory,
        PlayerInteract,
        Player,
        PlayerSelectEntity,
        EntityTurn,
    }
    public static BattleState battleState;
    public GameObject playerMainUI;
    public GameObject playerMagicUI;
    public GameObject playerInventoryUI;
    public GameObject playerInteractUI;
    public GameObject entityUI;
    public GameObject entitySelectorUI;
    public Dictionary<BattleState, GameObject> currentUI;
    public static string objName;

    public static BattleManager manager;
    void Start()
    {
        manager = this;
        objName = gameObject.name;
        battleState = BattleState.PlayerMain;
        currentUI = new Dictionary<BattleState, GameObject>() {
            { BattleState.PlayerMain, playerMainUI },
            { BattleState.PlayerMagic, playerMagicUI },
            { BattleState.PlayerInventory, playerInventoryUI },
            { BattleState.PlayerInteract, playerInteractUI },
            { BattleState.PlayerSelectEntity, entitySelectorUI },
            { BattleState.EntityTurn, entityUI },

        };
        var l = new object();
        lock (l)
        {
            entities = new ArrayList();
            InitEntities();
            InitScene();
            InitAudio();
        }
        // We don't want to use mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // WAIT A SEC IM NOT CHANGING ENTITIES!

    // Update is called once per frame
    void Update()
    {
        //print(battleState.ToString());
        if (battleState == BattleState.EntityTurn)
            if (isAllBattlesOver())
            {
                battleState = BattleState.PlayerMain;

                // Setting attacks back to false so we can redo the entire process
                foreach (GameObject entity in entities)
                {
                    var e = entity.GetComponent<BattleEntity>();
                    e.isAttackDone = false;
                }
            }

        foreach (var item in currentUI)
        {
            // The UI will only show up if the key for that value is the same as the current battleState.
            item.Value.SetActive(item.Key == battleState);
        }

        // HERE JUST FOR TESTING THIS WILL START WHEN BUTTON PRESSED
        /*if (battleState == "PLAYER")
        {
            battleState = "ENTITY";
            StartCoroutine(StartBattle());
            print("BATTLE STARTO");
        }*/




    }
    bool isAllBattlesOver()
    {
        print("b --");
        if (entities.Count != 0)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                // If One of the Battles are not over
                var entity = entities[i] as GameObject;
                print(entity.GetComponent<BattleEntity>().isAttackDone);
                if (!entity.GetComponent<BattleEntity>().isAttackDone)
                    return false;
            }
            return true;
        }
        print("b --");
        return false;
        // If no falses have been returned we can assume true.

    }
    // MODE = ENTITY
    public void InitEntities()
    {
        var n = Random.Range(battleSettings.minEnemies, battleSettings.maxEnemies + 1);
        transform.SetParent(null); // ABLE TO INSTANTIATE
        for (int i = 0; i <= n; i++)
        {
            GameObject obj = Instantiate(Resources.Load("BattleEntities/" + battleSettings.entitiesRef[Random.Range(0, battleSettings.entitiesRef.Length)])) as GameObject;
            var e = obj.GetComponent<BattleEntity>();
            e.i = i; // Item in list
            e.n = n; // length of list
            entities.Add(obj);
        }
        DontDestroyOnLoad(gameObject); // UNABLE TO INSTANTIATE
        print("SCENE STARTO");
    }
    public void InitScene()
    {
        var sceneParent = GameObject.Find("SceneGrid");
        var count = sceneParent.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            var child = sceneParent.transform.GetChild(i);
            child.gameObject.SetActive(child.name.Equals(battleSettings.sceneName));
        }
    }
    public void InitAudio()
    {
        GameObject.Find("BattleMusic").GetComponent<AudioSource>().clip = Resources.Load("Audio/" + battleSettings.audioRef) as AudioClip;
    }
    public void StartBattle()
    {
        battleState = BattleState.EntityTurn;
        for (int i = 0; i < entities.Count; i++)
        {
            ((GameObject)entities[i]).transform.SetParent(null);
            ((GameObject)entities[i]).GetComponent<BattleEntity>().StartAttack();
        }
    }
    public static bool isItPlayerTurn() {
        var playerStates = new ArrayList()
        {
            BattleState.PlayerMain,
            BattleState.PlayerMagic,
            BattleState.PlayerInventory,
            BattleState.PlayerInteract,
            BattleState.PlayerSelectEntity,
        };
        foreach (BattleState state in playerStates)
        {
            if (battleState == state) return true;
        };
        return false;
    }
    // This is called when we want to select an enemy
    public void SelectEntity(BattleState nextState)
    {
        EntitySelector.nextBattleState = nextState;
        battleState = BattleState.PlayerSelectEntity;
    }

    #region Button Functions
    public void AttackSelectEntity()
    {
        SelectEntity(BattleState.PlayerAttack);
    }
    public void MagicSelectEntity()
    {
        SelectEntity(BattleState.PlayerMagic);
    }
    public void ItemsSelectEntity()
    {
        battleState = BattleState.PlayerInventory;
    }



    #endregion

    // The attack UI called when enemy is selected
    public void AttackUI()
    {
        battleState = BattleState.PlayerAttack;
        Instantiate(Resources.Load("AttackBox"));
    }
    // Executes a turn if you select the enemy
    public void ExecuteTurnOnEnemy()
    {
        if (battleState == BattleState.PlayerAttack) AttackUI();
        if (battleState == BattleState.PlayerMagic) {
            Instantiate(Resources.Load("Magic/Magic Nav") as GameObject);
        }
    }

    public static BattleManager GetScript()
    {
        return GetObj().GetComponent<BattleManager>();
    }
    public static GameObject GetObj()
    {
        return GameObject.Find(objName);
    }

}
