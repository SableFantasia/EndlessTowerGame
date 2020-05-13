using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    //public EnemyNames enemyNames;
    //public EnemyProperties[] properties;
    public SpawnState spawnState;
    public enum PlayState { _Play, _StageCleared, _FloorCleared, _Begin, _Defeat, _NextFloor }
    public PlayState playState;
    public GameObject[] enemyPrefabs;
    public GameObject[] enemiesSpawned;
    public EnemyProperties[] enemyProperties;
    public List<GameObject> spawnedEnemies;
    public GameObject[] Floors;
    public GameObject CurrentFloor;
    public SpawnArea spawnArea;
    public List<WaveProperties> WaveTypes;


    public Dictionary<EnemyType.EnemyTypes, int> SpawnRatio;
    private int spawnRatioTotal = 400;

    private System.Random rng;

    private int FloorID;
    public static int maxFloors = 10;

    public int maxEnemies = 0;
    public int minimumEnemies = 6;
    public float enemyMultiplier = 4;

    private float globalTimer = 0f;
    public float globalTicker = 60f;

    private float spawnTimer = 0f;
    public float spawnTicker = 5f;
    private WaveProperties currentWave;

    public void RemoveEnemyByIdentity(GameObject enemy)
    {
        Debug.Log("How many enemies in list of enemies " + spawnedEnemies.Count);

        spawnedEnemies.RemoveAt(spawnedEnemies.IndexOf(enemy));
        GameObject.Destroy(enemy);
    }

    bool CheckToSpawnEnemies()
    {
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

    void SpawnEnemy(EnemyType.EnemyTypes setEnemyType)
    {
        while (!spawnArea.SpawnNewAgent())
        {
            GameObject.Destroy(spawnArea._ThisAgentReference);
            Debug.Log("This is a test enemy");
        }

        for (int p = 0; p < enemyProperties.Length; p++)
        {
            //Assign enemy 
            if (setEnemyType == enemyProperties[p].GetEnemyType())
            {
                int i = spawnedEnemies.Count;
                spawnedEnemies.Add((GameObject)Instantiate(enemyPrefabs[p], spawnArea.GetThisAgent(), Quaternion.identity));
                spawnedEnemies[i].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], spawnArea.GetThisAgent(), spawnState, i);
            }
        }
        GameObject.Destroy(spawnArea._ThisAgentReference);
    }

    /*void SpawnRandomEnemy(List<EnemyType.EnemyTypes> randomEnemyTypes)
    {
        EnemyType.EnemyTypes setEnemyType;

        /*


        double numericValue = r.NextDouble() * RatioSum;

        foreach (var parameter in Parameters)
        {
            numericValue -= parameter.Ratio;

            if (!(numericValue <= 0))
                continue;

            parameter.Func();
            return;


        

        int setRandomRange = rng.Next(0,spawnRatioTotal);

        int indexOfType = 0;
        int checkSpawnRatio = spawnRatioTotal;

        foreach (KeyValuePair<EnemyType.EnemyTypes, int> setRandomEnemyType in SpawnRatio)
        {
            //setRandomRange -= setRandomEnemyType.Value;
            
            
            

            if (setRandomRange <= 0)
            {
                continue;
            }


            setEnemyType = setRandomEnemyType.Key;
            indexOfType++;
        }




        while (!spawnArea.SpawnNewAgent())
        {
            GameObject.Destroy(spawnArea._ThisAgentReference);
            Debug.Log("This is a test enemy");
        }

        for (int p = 0; p < enemyProperties.Length; p++)
        {
            //Assign enemy 
            if (setEnemyType == enemyProperties[p].GetEnemyType())
            {
                int i = spawnedEnemies.Count;
                spawnedEnemies.Add((GameObject)Instantiate(enemyPrefabs[p], spawnArea.GetThisAgent(), Quaternion.identity));
                spawnedEnemies[i].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], spawnArea.GetThisAgent(), spawnState, i);
            }
        }
    }*/

    void SpawnRandomEnemy(List<EnemyType.EnemyTypes> randomEnemyTypes)
    {
        EnemyType.EnemyTypes setEnemyType = EnemyType.EnemyTypes._NoEnemy;

        /*


        double numericValue = r.NextDouble() * RatioSum;

        foreach (var parameter in Parameters)
        {
            numericValue -= parameter.Ratio;

            if (!(numericValue <= 0))
                continue;

            parameter.Func();
            return;


        */

        //--------------------Get Random Enemy------------------------

        int setRandomRange = rng.Next(0, spawnRatioTotal);

        foreach (KeyValuePair<EnemyType.EnemyTypes, int> setRandomEnemyType in SpawnRatio)
        {
            //setEnemyType
            setRandomRange -= setRandomEnemyType.Value;

            if (setRandomRange <= 0)
            {
                Debug.Log("---------------Output Spawned Enemy------------- " + setRandomEnemyType.Key);
                setEnemyType = setRandomEnemyType.Key;
                break;
            }
        }

        /*int setEnemyTypeValue = spawnRatioTotal;

        foreach (KeyValuePair<EnemyType.EnemyTypes, int> setRandomEnemyType in SpawnRatio)
        {
            //setEnemyType
            setEnemyTypeValue -= setRandomEnemyType.Value;

            setRandomRange -= setRandomEnemyType;

            if (setRandomRange <= 0)
            {
                setEnemyType = setRandomEnemyType.Key;
            }
        }*/


        //--------------------Spawn Enemy------------------------

        while (!spawnArea.SpawnNewAgent())
        {
            GameObject.Destroy(spawnArea._ThisAgentReference);
            Debug.Log("This is a test enemy");
        }

        for (int p = 0; p < enemyProperties.Length; p++)
        {
            //Assign enemy 
            if (setEnemyType != EnemyType.EnemyTypes._NoEnemy)
            {
                if (setEnemyType == enemyProperties[p].GetEnemyType())
                {
                    int i = spawnedEnemies.Count;
                    spawnedEnemies.Add((GameObject)Instantiate(enemyPrefabs[p], spawnArea.GetThisAgent(), Quaternion.identity));
                    spawnedEnemies[i].GetComponent<EnemyTestAI>().InitializeEnemy(enemyProperties[p], spawnArea.GetThisAgent(), spawnState, i);
                }
            }
            else
            {
                Debug.Log("No Enemy Assigned");
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
        spawnArea = CurrentFloor.GetComponent<FloorProperties>().GetSpawnArea();

        globalTimer = 0f;
        spawnTimer = 0f;

        currentWave = ScriptableObject.Instantiate<WaveProperties>(WaveTypes[0]);
        currentWave.InitializeWaveProperties();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnRatio = new Dictionary<EnemyType.EnemyTypes, int>
        {
            { EnemyType.EnemyTypes._TestEnemy, 200 },
            { EnemyType.EnemyTypes._AnotherEnemy, 200 }
        };

        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        rng = new System.Random();

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

                    if (WaveTypes.Count > 0)
                    {
                        if (currentWave.CheckCurrentWave())
                        {
                            Debug.Log("Checking no of enemies: ");
                            // Frequent (check for random or specific
                            switch (currentWave.waveType)
                            {
                                case WaveProperties.WaveType._Random:
                                    {
                                        switch (currentWave.frequency)
                                        {
                                            case WaveProperties.Frequency._Frequent:
                                                {
                                                    if (currentWave.CheckSpawnTimer())
                                                    {
                                                        if (currentWave.GetNoOfEnemies() > 0)
                                                        {
                                                            Debug.Log("Checking no of enemies: " + currentWave.GetNoOfEnemies());

                                                            // This is where set Enemy checks for current enemy
                                                            List<EnemyType.EnemyTypes> randomEnemyTypes = currentWave.GetCurrentEnemyType();
                                                            if (randomEnemyTypes != null)
                                                            {
                                                                SpawnRandomEnemy(randomEnemyTypes);
                                                                Debug.Log("Enemy Type set to an instance of enemy");
                                                            }
                                                            else
                                                                Debug.Log("Enemies is null");
                                                        }
                                                    }
                                                    break;
                                                }
                                            case WaveProperties.Frequency._NonFrequent:
                                                {
                                                    int NoOfEnemies = currentWave.GetNoOfEnemies();
                                                    
                                                    if (NoOfEnemies != 0)
                                                    {
                                                        List<EnemyType.EnemyTypes> randomEnemyTypes = currentWave.GetCurrentEnemyType();
                                                        if (randomEnemyTypes != null)
                                                        {
                                                            for (int enemies = 0; enemies < NoOfEnemies; enemies++)
                                                            {
                                                                //Debug.Log("Checking no of enemies: " + currentWave.GetNoOfEnemies());

                                                                // This is where set Enemy checks for current enemy


                                                                SpawnRandomEnemy(randomEnemyTypes);
                                                                Debug.Log("Enemy Type set to an instance of enemy");

                                                                //SpawnEnemy(currentWave.GetCurrentEnemyType());
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case WaveProperties.WaveType._Specific:
                                    {
                                        break;
                                    }
                                case WaveProperties.WaveType._Variable:
                                    {
                                        break;
                                    }
                            }
                        }
                        else if (spawnedEnemies.Count <= 0)
                        {
                            WaveTypes.RemoveAt(0);
                            if (WaveTypes.Count >= 0)
                            {
                                currentWave = ScriptableObject.Instantiate<WaveProperties>(WaveTypes[0]);
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("You have cleared the floor");
                        playState = PlayState._FloorCleared;
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
