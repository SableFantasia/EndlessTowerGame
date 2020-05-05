using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    float FireEleResist, WaterEleResist, EarthEleResist, AirEleResist, DarkEleResist, LightEleResist;

    public enum armourPieces { helmet, chestplate, platelegs, boots, gloves, necklace }
    public armourPieces pieces;

    string label;
    string description;
    int id = 0;
    Sprite sprite;

    string armourType;
    string elementResistance;

    void Start()
    {
        int randPiece = UnityEngine.Random.Range(0, 5);
        int randResist = UnityEngine.Random.Range(0, 5);

        if(randPiece == 0)
        {
            armourType = "helm";
        }
        else if (randPiece == 1)
        {
            armourType = "chestplate";
        }
        else if (randPiece == 2)
        {
            armourType = "platelegs";
        }
        else if (randPiece == 3)
        {
            armourType = "boots";
        }
        else if (randPiece == 4)
        {
            armourType = "gloves";
        }
        else if (randPiece == 5)
        {
            armourType = "necklace";
        }

        SetProperties(0.0f, 0.0f, getArmourPiece());

        if (randResist == 0)
        {
            FireEleResist++;
        }
        else if (randResist == 1)
        {
            WaterEleResist++;
        }
        else if (randResist == 2)
        {
            EarthEleResist++;
        }
        else if (randResist == 3)
        {
            AirEleResist++;
        }
        else if (randResist == 4)
        {
            LightEleResist++;
        }
        else if (randResist == 5)
        {
            DarkEleResist++;
        }
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

    public float TotalDefence()
    {
        return getFireResist() + getEarthResist() + getWaterResist() + getAirResist() + getDarkResist() + getLightResist();
    }

    public string getArmourPiece()
    {
        return armourType;
    }


}
