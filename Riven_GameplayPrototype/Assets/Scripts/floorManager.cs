using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorManager : MonoBehaviour
{
    int currentFloor;

    public void ProgressFloor()
    {
        currentFloor++;
    }

    public int GetFloor()
    {
        return currentFloor;
    }

    public void Start()
    {
        currentFloor = 1;
    }
}
