using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum WeaponType { Nothing, Bow, Pistol }



public class RangedWeaponHandler : MonoBehaviour
{

    [Header("General Variables")]
    private PlayerStates playerStates;

    public WeaponType weaponEquipped;

    public GameObject mouseCursor;

    public Transform firePoint;


    

    [Header("Weapons")]

    public Pistol pistol;
    
    public Bow bow;


    

    // Start is called before the first frame update
    void Start()
    {
        weaponEquipped = WeaponType.Pistol;

        playerStates = GetComponent<PlayerStates>();

    }





    public void WeaponBehavioursFunction()
    {
        switch (weaponEquipped)
        {
            case WeaponType.Pistol:
            {
                    pistol.PistolBehaviour();
                break;
            }
            case WeaponType.Bow:
            {
                    bow.ShootBow();
                break;
            }
        }




    }
}
