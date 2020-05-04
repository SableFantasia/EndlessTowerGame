using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float mainAttack;
    float powerfulAttack;
    public float mainDefence = 0.0f;
    float health = 10.0f;
    float maxHealth = 10.0f;
    float healthRegenerationRate = 1f;
    float stamina;
    float staminaRegen;
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

    float GetDefence()
    {
        return helmet.getFireResist() + mainDefence;
    }

    void Start()
    {
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
