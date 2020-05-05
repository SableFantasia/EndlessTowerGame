using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public UIScript ui;

    [HideInInspector]
    public int Strength; //increases the hit of the attack and Health

    public float attackModifier = 1.0f;
    public float weaponAttack = 1.0f;
    public float weaponSpecialAttack = 1.5f;
    float physicalAttack;
    float specialAttack;
    float criticalAttack;

    public float baseHealth = 10.0f;
    float health;
    public float maxHealth;
    float initialHealthRegenerationRate = 1f;
    float healthRegenerationRate = 1f;
    public float healthModifier;
    public float healthRegenModifier;

    [HideInInspector]
    public int Endurance; //increases speed recovery and defence

    float mainDefence = 1.0f;
    float defence;
    [HideInInspector]
    public float totalDefence; // basically defence of all the armour pieces.
    public float armourModifier;
    float damageReduction;

    float damage;

    float recoverySpeed;

    [HideInInspector]
    public int Agility; //Increases Attack Speed and Movement Speed

    float baseAttackSpeed = 1.0f;
    float attackSpeed;
    float attackSpeedDelay;
    public float attackSpeedModifier;
    float stamina;
    float staminaRegen;
    public float baseMovementSpeed;
    float movementSpeed;
    public float movementSpeedModifier;

    [HideInInspector]
    public int Chance; //Increases Critical Rate and evasion to attacks

    float criticalChance = 0.01f;
    public float criticalModifier;
    float dodgingChance = 0.01f;
    float evasion;
    public float evasionModifier;

    [HideInInspector]
    public int Intelligence; //increases special points and elemental attack

    float elementalAttack = 1.0f;
    int basespecialPoints = 10;
    int specialPoints = 10;
    public float specialPointsModifier;

    [HideInInspector]
    public int Control; //number of active placement type abilities you can have at one time and special recovery speed

    public float abilityModifier = 1.0f;
    int numberOfActiveAbilities;
    float specialRecoverySpeed;

    public int crystalsAvaliable = 0;

    public Armour helmet;
    public Armour chestplate;
    public Armour platelegs;
    public Armour boots;
    public Armour gloves;
    public Armour necklace;

    float GetDefence()
    {
        float[] defenceStats = new float[6];
        float sum = 0;
        if (helmet == null)
        {
            defenceStats[0] = 0;
        }
        else
        {
            defenceStats[0] = helmet.TotalDefence();
        }
        if (chestplate == null)
        {
            defenceStats[1] = 0;
        }
        else
        {
            defenceStats[1] = chestplate.TotalDefence();
        }
        if (platelegs == null)
        {
            defenceStats[2] = 0;
        }
        else
        {
            defenceStats[2] = platelegs.TotalDefence();
        }
        if (boots == null)
        {
            defenceStats[3] = 0;
        }
        else
        {
            defenceStats[3] = boots.TotalDefence();
        }
        if (gloves == null)
        {
            defenceStats[4] = 0;
        }
        else
        {
            defenceStats[4] = gloves.TotalDefence();
        }
        if (necklace == null)
        {
            defenceStats[5] = 0;
        }
        else
        {
            defenceStats[5] = necklace.TotalDefence();
        }

        for (int i = 0; i < defenceStats.Length; i++)
        {
            sum += defenceStats[i];
        }

        return sum + mainDefence;
    }

    void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        physicalAttack = weaponAttack + (Strength * attackModifier);
        criticalAttack = ((Strength * attackModifier) / 2) + (2 * weaponAttack);
        specialAttack = weaponSpecialAttack + (Intelligence * abilityModifier) + (Strength * attackModifier);

        maxHealth = baseHealth + Strength * healthModifier;
        healthRegenerationRate = Endurance * healthRegenModifier;

        defence = Endurance * armourModifier;

        damageReduction = damage - (defence + (totalDefence * damage));

        attackSpeedDelay = baseAttackSpeed - Agility * attackSpeedModifier;
        movementSpeed = baseMovementSpeed + Agility * movementSpeedModifier;

        specialPoints = Mathf.RoundToInt(basespecialPoints + (Intelligence * specialPointsModifier));

        evasion = Chance * evasionModifier;

        criticalChance = Chance * criticalModifier;
    }

    public void ChangeInLevel()
    {
        ui.UpdateStats();
    }

    void Update()
    {
        if (health >= maxHealth)
        {
            RegenerateHealth(healthRegenerationRate);
        }
    }

    void TakeDamage(float Damage)
    {
        health -= Damage;
    }

    void HealDamage(float Damage)
    {
        health += Damage;
    }

    IEnumerator RegenerateHealth(float rate)
    {
        yield return new WaitForSeconds(rate);
        health += 0.1f;
    }
}
