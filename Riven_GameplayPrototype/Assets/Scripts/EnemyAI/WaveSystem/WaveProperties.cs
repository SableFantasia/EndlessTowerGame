using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveType", menuName = "Create New Wave Type")]
public class WaveProperties : ScriptableObject
{
    public enum WaveType { _Random, _Specific, _Variable };
    public enum Frequency { _Frequent, _NonFrequent };

    public WaveType waveType;
    public Frequency frequency;

    public bool CheckIfRandom;
    public int NoOfEnemiesToSpawn;
    public float setEnemyFrequency; //How long in seconds you want to spawn an enemy;
    public List<EnemyType.EnemyTypes> randomEnemyTypes;
    //public List<int> RandomRange; // Use Dictionary

    public bool CheckIfSpecific; // spawn enemies in a specific order
    public List<EnemyType.EnemyTypes> specificEnemyOrder;

    public bool CheckIfVariable;
    public enum SetVariable { _NoOfSpecificEnemiesFrequent, _NoOfSpecificEnemiesNonFrequent, _NoOfRandomEnemiesFrequent, _NoOfRandomEnemiesNonFrequent };
    public List<SetVariable> setVariable;
    public List<int> VariableQuantity;

    private int enemiesRemaining;
    private int TotalRange;

    private float waveTicker = 0, waveTimer = 0;
    private bool currentWave = true;

    public struct Flags { public bool timerSet; public int variableFrequency; };
    public Flags flags;
    //public Dictionary<EnemyType.EnemyTypes, int>
    //private int variableIndex;
    //private EnemyType.EnemyTypes variableEnemyType;

    public void InitializeWaveProperties()
    {
        flags.timerSet = false;
        flags.variableFrequency = 0;

        foreach (SetVariable _setVariableFrequency in setVariable)
        {
            if (_setVariableFrequency == SetVariable._NoOfSpecificEnemiesFrequent || _setVariableFrequency == SetVariable._NoOfRandomEnemiesFrequent)
            {
                flags.variableFrequency++;
            }
        }
        TotalRange = 0;

        /*foreach (int range in RandomRange)
        {
            TotalRange += range;
        }*/
    }

    public int GetNoOfEnemies()
    {
        switch (waveType)
        {
            case WaveType._Random:
                {
                    switch (frequency)
                    {
                        case Frequency._Frequent:
                            {
                                if (NoOfEnemiesToSpawn <= 0)
                                {
                                    Debug.Log("No of enemies to spawn is zero");
                                    flags.timerSet = false;
                                    currentWave = !currentWave;
                                }
                                Debug.Log("returning number of enemies");
                                return  NoOfEnemiesToSpawn;
                            }
                        case Frequency._NonFrequent:
                            {
                                if (NoOfEnemiesToSpawn <= 0)
                                {
                                    Debug.Log("No of enemies to spawn is zero");
                                    //flags.timerSet = false;
                                    currentWave = !currentWave;
                                }
                                Debug.Log("returning number of enemies");
                                return NoOfEnemiesToSpawn;
                            }
                    }
                    break;
                }
            case WaveType._Specific:
                {
                    break;
                }
            case WaveType._Variable:
                {
                    break;
                }
        }

        Debug.Log("return zero enemies");
        return 0;
    }

    public bool CheckSpawnTimer()
    {
        waveTimer += Time.deltaTime;
        if (waveTimer >= waveTicker)
        {
            waveTimer = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckCurrentWave()
    {
        if (currentWave)
        {
            // Check flags
            switch (waveType)
            {
                case WaveType._Random:
                    {
                        //Debug.Log("Checking Randomness and hope for the best");
                        switch (frequency)
                        {
                            case Frequency._Frequent:
                                {
                                    if (!flags.timerSet)
                                    {
                                        Debug.Log("Timer has not been set, setting timer");
                                        waveTicker = setEnemyFrequency;
                                        flags.timerSet = true;
                                    }
                                    return true;
                                }
                            case Frequency._NonFrequent:
                                {

                                    return true;
                                }
                        }
                        return false;
                    }
                case WaveType._Specific:
                    {
                        Specific();
                        break;
                    }
                case WaveType._Variable:
                    {
                        Variable();
                        break;
                    }
            }



            return true;
        }
        else
        {
            Debug.Log("This equals to false aklsjdf;alskjdf;alskjf;lkjs");
            return false;
        }
    }

    /*public EnemyType.EnemyTypes GetRandomEnemy()
    {
        float setRandomEnemyTo = Random.Range(0f, TotalRange);

        int maxRange = 0;
        int minRange = 0;
        int rangeIndex = 0;
        foreach (int checkRange in RandomRange) {
            maxRange = RandomRange[rangeIndex] + minRange;
            if (setRandomEnemyTo >= minRange && setRandomEnemyTo < maxRange)
            {
                Debug.Log("Set Random Enemy To This range: " + setRandomEnemyTo);
                Debug.Log("Return Random Enemy Index: " + randomEnemyTypes[rangeIndex]);
                return randomEnemyTypes[rangeIndex];
            }
            minRange = maxRange;
            rangeIndex++;
        }
        Debug.Log("No enemy found");
        return EnemyType.EnemyTypes._NoEnemy;
    }*/


    public List<EnemyType.EnemyTypes> GetCurrentEnemyType()
    {
        switch (waveType)
        {
            case WaveType._Random:
                {
                    switch (frequency)
                    {
                        case Frequency._Frequent:
                            {
                                Debug.Log("Resetting spawn timer, no of enemies to spawn: " + NoOfEnemiesToSpawn);
                                waveTimer = 0f;
                                if (NoOfEnemiesToSpawn > 0)
                                {
                                    NoOfEnemiesToSpawn--;
                                    //EnemyType.EnemyTypes _setEnemy = GetRandomEnemy();
                                    //Debug.Log("Setting random enemy type: " + _setEnemy);
                                    return randomEnemyTypes;
                                }

                                break;
                            }
                        case Frequency._NonFrequent:
                            {
                                NoOfEnemiesToSpawn = 0;
                                return randomEnemyTypes;
                            }
                    }
                    break;
                }
            case WaveType._Specific:
                {
                    break;
                }
            case WaveType._Variable:
                {
                    break;
                }
        }
        return null;

        /*}
        else if (waveType == WaveType._Specific)
        {
            return EnemyType.EnemyTypes._NoEnemy;
        }
        else if (waveType == WaveType._Variable)
        {
            return EnemyType.EnemyTypes._NoEnemy;
        }
        else return EnemyType.EnemyTypes._NoEnemy;
        */
        //check for enemy type
            //return _thisEnemy;
    }

    public void SetCurrentWave() {
        currentWave = !currentWave;
        }


    private void Specific()
    {

    }

    private void Variable()
    {

    }
}
