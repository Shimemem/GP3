using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Items
{
    public string Name;
    public string Description;
    public int ID;
    public GameObject Model;
}
public enum EquipedWeapons
{
    Pistol,
    AK47,
    MP7,
    AWP
}
public class GameManager : MonoBehaviour
{
    [Header("Player_Stats")]
    public float basePlayerDamage;
    public float finalPlayerDamage;

    [Header("WeaponsEquipped")]
    public EquipedWeapons equipedWeapons;

    [Header("ExpSystem")]
    public float expToAdd;
    public float maxXP;
    public float curXP;
    public int playerLevel;

    [Header("ItemsList")]

    [SerializeField]
    private List<Items> itemList = new();

    public List<Items> ItemList
    {
        get { return itemList; }
    }

    // Start is called before the first frame update
    void OnValidate()
    {
        #region WeaponEqquiped
        Weapons weapon = new Weapons();
        switch (equipedWeapons)
        {
            case EquipedWeapons.Pistol:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_Pistol;
                break;
            case EquipedWeapons.AWP:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_AWP;
                break;
            case EquipedWeapons.AK47:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_AK47;
                break;
            case EquipedWeapons.MP7:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_MP7;
                break;
            
            default:
                break;
        }


        #endregion
        ExpSystem();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //DamagePowerUp_Concentration();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //DamagePowerup_Focus();
        }

    }
    public void DamagePowerUp_Concentration()
    {
        DamagePowerUp powerUp = new DamagePowerUp();
        float powerUpPlayerDamage = (finalPlayerDamage * (powerUp.Concentration / 100));
        finalPlayerDamage = powerUpPlayerDamage + finalPlayerDamage;
    }

    public void DamagePowerUp_Focus()
    {
        DamagePowerUp powerUp = new DamagePowerUp();
        finalPlayerDamage += powerUp.Focus;
    }

    public void ExpSystem()
    {
        ExpHandler addExp = new ExpHandler();
        playerLevel = addExp.CurrentLevel;
        maxXP = addExp.MaxExperience;
        curXP = addExp.CurrentExperience;
    }
    public void AddExp(float experienceToAdd)
    {
        curXP += experienceToAdd;
        if (curXP >= maxXP)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        playerLevel++;
        curXP = 0f;
        maxXP *= 1.5f; // Increase max experience by 50% on each level up

        // Additional actions on level up (e.g., reward skill points, update UI)
    }
    public void ResetValues()
    {
        Weapons weapon = new Weapons();
        switch (equipedWeapons)
        {
            case EquipedWeapons.Pistol:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_Pistol;
                break;
            case EquipedWeapons.AK47:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_AK47;
                break;
            case EquipedWeapons.MP7:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_MP7;
                break;
            case EquipedWeapons.AWP:
                finalPlayerDamage = basePlayerDamage + weapon.Damage_AWP;
                break;
            default:
                break;
        }
    }

}