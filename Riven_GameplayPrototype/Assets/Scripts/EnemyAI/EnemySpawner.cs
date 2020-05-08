using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public EnemyNames enemyNames;
    //public EnemyProperties[] properties;
    public SpawnState spawnState;
    public EnemyType enemyTypes;
    public enum PlayState { _Play, _StageCleared, _FloorCleared, _Begin, _Defeat, _NextFloor}
    public PlayState playState;
    public GameObject[] enemyPrefabs;
    public GameObject[] enemiesSpawned;
    public EnemyProperties[] enemyProperties;
    public List<GameObject> spawnedEnemies;
    public GameObject[] Floors;
    public GameObject CurrentFloor;
    public SpawnArea spawnArea;

    private int FloorID;
    public static int maxFloors = 10;

    public int maxEnemies = 0;
    public int minimumEnemies = 6;
    public float enemyMultiplier = 4;

    public float globalTimer = 0f;
    public float globalTicker = 60f;

    public float spawnTimer = 0f;
    public float spawnTicker = 5f;
    public float _tMultiplier = 0f;

    public void RemoveEnemyByIdentity(GameObject enemy)
    {
        Debug.Log("How many enemies in list of enemies " + spawnedEnemies.Count);

        spawnedEnemies.RemoveAt(spawnedEnemies.IndexOf(enemy));
        GameObject.Destroy(enemy);
    }

    bool CheckToSpawnEnemies()
    {
        /*if (globalTimer >= globalTicker)
        {
            _tMultiplier = globalTicker;
        }*/
        /*_tMultiplier = globalTimer / globalTicker;
        if (_tMultiplier < 1f)
        {

            //Debug.Log("Show Multiplier value: " + (maxEnemies + maxEnemies * _tMultiplier));
            if (enemySpawnIndex + 1 < maxEnemies + maxEnemies * _tMultiplier)
            {
                //Debug.Log("Show Multiplier value: " + (maxEnemies + maxEnemies * _tMultiplier));
                spawnTimer += Time.deltaTime;

                if (spawnTimer >= spawnTicker)
                {
                    spawnTimer = 0f;
                    //Debug.Log("Definitely spawn a new enemy");
                    return true;
                }
            }
        }*/

        if (spawnedEnemies.Count < minimumEnemies)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > spawnTicker)
            {
                spawnTimer = 0f;
                //Debug.Log("Definitely spawn a new enemy");
                return true;
            }
        }
        
        return false;
    }

    void SpawnEnemy()
    {
        while (!spawnArea.SpawnNewAgent())
        {
            GameObject.Destroy(spawnArea._ThisAgentReference);
            Debug.Log("This is a test enemy");
        }

        for (int p = 0; p < enemyProperties.Length; p++)
        {
            if (enemyProperties[p].name == "TestEnemy")
            {
                
                int i = spawnedEnemies.Count;

                spawnedEnemies.Add((GameObject)Instantiate(enemyPrefabs[p], spawnArea.GetThisAgent(), Quaternion.identity));
                

                spawnedEnemies[i].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], spawnArea.GetThisAgent(), spawnState, i);
                
                //Debug.Log("Spawn Index: " + enemySpawnIndex);
                
            }
        }

        GameObject.Destroy(spawnArea._ThisAgentReference);
    }




    void SetFloor ()
    {
        if (FloorID == maxFloors - 1)
        {
            FloorID = 0;
        }
        else FloorID++;
    }

    void InitializeFloor()
    {
        FloorID = 0;
        CurrentFloor = Floors[FloorID];
        //maxEnemies = minimumEnemies + enemyMultiplier * FloorID;
        spawnArea = CurrentFloor.GetComponent<FloorProperties>().GetSpawnArea();

        _tMultiplier = 0f;
        globalTimer = 0f;
        spawnTimer = 0f;
    }

    
    void SpawnEnemies()
    {
        for (int l = 0; l < enemiesSpawned.Length; l++)
        {
            for (int p = 0; p < enemyProperties.Length; p++)
            {
                if (enemyProperties[p].name == "TestEnemy")
                {
                    //enemiesSpawned[l].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], new Vector3(0, 0, 0));
                    Debug.Log("This is a test enemy");
                }
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {

        playState = PlayState._Begin;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playState)
        {
            case PlayState._Begin:
                {
                    InitializeFloor();
                    playState = PlayState._Play;
                    break;
                }
            case PlayState._Play:
                {

                    globalTimer += Time.deltaTime;

                    if (CheckToSpawnEnemies())
                    {
                        SpawnEnemy();
                    }

                    break;
                }
            case PlayState._FloorCleared:
                {

                    break;
                }
            case PlayState._NextFloor:
                {

                    break;
                }
            case PlayState._Defeat:
                {

                    break;
                }
            case PlayState._StageCleared:
                {

                    break;
                }
        }
    }


}
