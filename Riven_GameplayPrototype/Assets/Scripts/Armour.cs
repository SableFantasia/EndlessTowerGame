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

    void Start()
    {
        SetProperties(1.0f, 1.0f, "Helm");
    }

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

    public float getEarthResist()
    {
        return EarthEleResist;
    }

    public float getWaterResist()
    {
        return WaterEleResist;
    }

    public float getAirResist()
    {
        return AirEleResist;
    }

    public float getDarkResist()
    {
        return DarkEleResist;
    }

    public float getLightResist()
    {
        return LightEleResist;
    }

    public string getArmourPiece()
    {
        return armourType;
    }
}
