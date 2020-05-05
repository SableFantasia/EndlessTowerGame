using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public enum CrystalTypes { Strength, Endurance, Agility, Chance, Intelligence, Control }
    public CrystalTypes crystalTypes;

    public string Description;

    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();

        

        switch (crystalTypes)
        {
            case CrystalTypes.Strength:
                mesh.material.SetColor("_Color", Color.red);
                break;
            case CrystalTypes.Endurance:
                mesh.material.SetColor("_Color", Color.blue);
                break;
            case CrystalTypes.Agility:
                mesh.material.SetColor("_Color", Color.yellow);
                break;
            case CrystalTypes.Chance:
                mesh.material.SetColor("_Color", new Color(1, 0, 1));
                break;
            case CrystalTypes.Intelligence:
                mesh.material.SetColor("_Color", Color.green);
                break;
            case CrystalTypes.Control:
                mesh.material.SetColor("_Color", new Color(0, 0, 0));
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
            switch (crystalTypes)
            {
                case CrystalTypes.Strength:
                    stats.Strength++;
                    Debug.Log("Strength Level: " + stats.Strength);
                    break;
                case CrystalTypes.Endurance:
                    stats.Endurance++;
                    Debug.Log("Endurance Level: " + stats.Endurance);
                    break;
                case CrystalTypes.Agility:
                    stats.Agility++;
                    Debug.Log("Agility Level: " + stats.Agility);
                    break;
                case CrystalTypes.Chance:
                    stats.Chance++;
                    Debug.Log("Chance Level: " + stats.Chance);
                    break;
                case CrystalTypes.Intelligence:
                    stats.Intelligence++;
                    Debug.Log("Intelligence Level: " + stats.Intelligence);
                    break;
                case CrystalTypes.Control:
                    stats.Control++;
                    Debug.Log("Control Level: " + stats.Control);
                    break;
            }
            stats.ChangeInLevel();
            Destroy(this.gameObject);
        }
        
    }
}
