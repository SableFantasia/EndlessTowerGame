using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentList equiped;

    public enum ArmourPiece { Head, Chest, Legs, Feet, Hands, Necklace }
    public ArmourPiece typeOfEquipment;

    public enum elemental { Fire, Earth, Water, Air, Light, Dark }
    elemental elementalResistance;
    elemental propertyModifier;

    public float defence;
    public float strengthBonus;

    public int cost; //buy value
    //public float sellMultiplier = .05f;
    //int value; //sell value, formulate that.

    void Start()
    {
        int randInt = UnityEngine.Random.Range(0, 6);
        //value = Mathf.RoundToInt(cost * sellMultiplier);
    }

    void OnMouseDown()
    {
        int randInt = UnityEngine.Random.Range(0, 6);

        OnEquip(0);
    }

    void OnEquip(int armour)
    {
        ArmourPiece armourSelect = (ArmourPiece)armour;
        Debug.Log(armourSelect);

        switch (armourSelect)
        {
            case ArmourPiece.Head:
                equiped.helm = this;
                

                break;

            /*case ArmourPiece.Chest:
                equiped.chest = this;
                break;

            case ArmourPiece.Legs:
                equiped.legs = this;
                break;

            case ArmourPiece.Feet:
                equiped.boots = this;
                break;

            case ArmourPiece.Hands:
                equiped.gloves = this;
                break;

            case ArmourPiece.Necklace:
                equiped.necklace = this;
                break;*/
        }
        
        //Destroy(this);
    }
}