using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentList : MonoBehaviour
{
    PlayerStats stats;
    public Equipment helm = null;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        AddStats();
    }

    void AddStats()
    {

        //stats.mainDefence = helm.defence + chest.defence + legs.defence + boots.defence + gloves.defence + necklace.defence;
    }
}
