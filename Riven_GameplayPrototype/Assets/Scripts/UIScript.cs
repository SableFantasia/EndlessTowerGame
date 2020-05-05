using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerStats playerStats;

    public Text Strength;
    public Text Endurance;
    public Text Agility;
    public Text Chance;
    public Text Intelligence;
    public Text Control;

    public Text DefenceBonus;
    public Text ElementalDefence;
    public Text Health;

    void Start()
    {
        Strength.text = "Strength: " + playerStats.Strength;
        Endurance.text = "Endurance: " + playerStats.Endurance;
        Agility.text = "Agility: " + playerStats.Agility;
        Chance.text = "Chance: " + playerStats.Chance;
        Intelligence.text = "Intelligence: " + playerStats.Intelligence;
        Control.text = "Control: " + playerStats.Control;

        DefenceBonus.text = "Defence Bonus: " + playerStats.totalDefence;
        Health.text = "Health: " + playerStats.totalDefence;
    }

    public void UpdateStats()
    {
        Start();
    }
}
