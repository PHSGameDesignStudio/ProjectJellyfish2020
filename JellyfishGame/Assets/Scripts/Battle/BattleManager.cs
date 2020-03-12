using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public GameObject[] RefEntities;
    public static ArrayList entities;
    public int minEnemies;
    public int maxEnemies;
    public string battleState = "PLAYER";
    void Start()
    {
        var l = new object();
        lock (l)
        {
            DontDestroyOnLoad(gameObject);
            entities = new ArrayList();
            InitEntities();
        }
    }
    // WAIT A SEC IM NOT CHANGING ENTITIES!

    // Update is called once per frame
    void Update()
    {
        if (battleState == "ENTITY")
            if (isAllBattlesOver())
                StartCoroutine(GotoPlayerTurn());

        // HERE JUST FOR TESTING THIS WILL START WHEN BUTTON PRESSED
        if (battleState == "PLAYER")
        {
            battleState = "ENTITY";
            StartCoroutine(StartBattle());
            print("BATTLE STARTO");
        }

                

    }
    bool isAllBattlesOver()
    {
        if (entities.Count != 0)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                // If One of the Battles are not over
                var entity = entities[i] as GameObject;
                if (!entity.GetComponent<BattleEntity>().isAttackDone)
                    return false;
            }
            return true;
        }
        return false;
        // If no falses have been returned we can assume true.
        
    }

    // MODE = PLAYER
    public IEnumerator GotoPlayerTurn()
    {
        battleState = "PLAYER";
        Fade.MakeOverlay();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Battle_PlayerTurn");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle_PlayerTurn"));
    }

    // MODE = ENTITY
    public void InitEntities()
    {
        var n = Random.Range(minEnemies, maxEnemies);
        transform.SetParent(null); // ABLE TO INSTANTIATE
        for (int i = 0; i <= n; i++)
        {
            
            GameObject obj = Instantiate(RefEntities[Random.Range(0, RefEntities.Length)]) as GameObject;
            entities.Add(obj);
        }
        DontDestroyOnLoad(gameObject); // UNABLE TO INSTANTIATE
        print("SCENE STARTO");
    }
    public IEnumerator StartBattle()
    {
        SceneManager.LoadScene("Battle_EntityTurn", LoadSceneMode.Single);
        yield return new WaitForSeconds(0.5f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle_EntityTurn"));


        battleState = "ENTITY";
        for (int i = 0; i < entities.Count; i++)
        {
            ((GameObject)entities[i]).transform.SetParent(null);
            ((GameObject)entities[i]).GetComponent<BattleEntity>().StartAttack();
        }
    }
}
