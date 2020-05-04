using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    float FireEleResist, WaterEleResist, EarthEleResist, AirEleResist, DarkEleResist, LightEleResist;

    string label;
    string description;
    int id = 0;
    Sprite sprite;

    string armourType;

    public void SetProperties(float ElementalMod, float LightDarkMod, string setArmourType)
    {
        FireEleResist = ElementalMod;
        WaterEleResist = ElementalMod;
        EarthEleResist = ElementalMod;
        AirEleResist = ElementalMod;
        DarkEleResist = LightDarkMod;
        LightEleResist = LightDarkMod;

        armourType = setArmourType;
    }

    public float getFireResist()
    {
        return FireEleResist;
    }

    public string getArmourPiece()
    {
        return armourType;
    }
}
