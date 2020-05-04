using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int Strength; //increases the hit of the attack and Health

    float attackModifier = 1.0f;
    float weaponAttack = 1.0f;
    float weaponSpecialAttack = 1.5f;
    float physicalAttack;
    float specialAttack;
    float criticalAttack;

    float baseHealth = 10.0f;
    float health;
    float maxHealth;
    float initialHealthRegenerationRate = 1f;
    float healthRegenerationRate = 1f;
    float healthModifier;
    float healthRegenModifier;

    int Endurance; //increases speed recovery and defence

    float mainDefence = 1.0f;
    float defence;
    float totalDefence; // basically defence of all the armour pieces.
    float armourModifier;
    float damageReduction;

    float damage;

    float recoverySpeed;

    int Agility; //Increases Attack Speed and Movement Speed

    float baseAttackSpeed = 1.0f;
    float attackSpeed;
    float attackSpeedDelay;
    float attackSpeedModifier;
    float stamina;
    float staminaRegen;
    float baseMovementSpeed;
    float movementSpeed;
    float movementSpeedModifier;

    int Chance; //Increases Critical Rate and evasion to attacks

    float criticalChance = 0.01f;
    float criticalModifier;
    float dodgingChance = 0.01f;
    float evasion;
    float evasionModifier;

    int Intelligence; //increases special points and elemental attack

    float elementalAttack = 1.0f;
    int basespecialPoints = 10;
    int specialPoints = 10;
    float specialPointsModifier;

    int Control; //number of active placement type abilities you can have at one time and special recovery speed

    float abilityModifier = 1.0f;
    int numberOfActiveAbilities;
    float specialRecoverySpeed;

    public Armour helmet;
    public Armour chestplate;
    public Armour platelegs;
    public Armour boots;
    public Armour gloves;
    public Armour necklace;

    float GetDefence()
    {
        return helmet.getFireResist() + mainDefence;
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

        health = maxHealth;

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
