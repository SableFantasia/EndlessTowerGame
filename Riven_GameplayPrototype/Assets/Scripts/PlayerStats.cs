using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float mainAttack;
    float powerfulAttack;
    public float mainDefence = 0.0f;
    float health = 10.0f;
    float healthRegenerationRate = 0.1f;
    float stamina;
    float mana;
    float speed;
    float attackSpeed;
    float criticalChance = 0.01f;

    public Armour helmet;
    public Armour chestplate;
    public Armour platelegs;
    public Armour boots;
    public Armour gloves;
    public Armour necklace;

    // Start is called before the first frame update
    float GetDefence()
    {
        return helmet.getFireResist() + mainDefence;
    }
}
