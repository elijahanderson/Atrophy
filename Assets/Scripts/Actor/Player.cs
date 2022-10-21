using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    // for adjusting UI
    // public HealthBar healthBar;
    // public ManaBar manaBar;
    // public StaminaBar staminaBar;

    // attributes
    public int constitution;
    public int strength;
    public int intelligence;
    public int spirituality;
    public int endurance;
    public int totalGold;

    protected Vector2 target;

    protected override void Start() {
        base.Start();
        // attributes
        constitution = GameManager.gameManagerInstance.constitution;
        strength = GameManager.gameManagerInstance.strength;
        intelligence = GameManager.gameManagerInstance.intelligence;
        spirituality = GameManager.gameManagerInstance.spirituality;
        endurance = GameManager.gameManagerInstance.endurance;

        // stats
        level = GameManager.gameManagerInstance.playerLevel;
        totalGold = GameManager.gameManagerInstance.totalGold;

        hitpoint = 100 + (constitution * 20);
        maxHitpoint = 100 + (constitution * 20);
        GameManager.gameManagerInstance.playerMaxHitpoint = maxHitpoint;

        healthRegenRate = 2.0f + (constitution * 0.10f);
        GameManager.gameManagerInstance.playerHealthRegenRate = healthRegenRate;

        mana = 10 + (intelligence * 10);
        maxMana = 10 + (intelligence * 10);
        GameManager.gameManagerInstance.playerMaxMana = maxMana;

        manaRegenRate = 0.5f + (intelligence * 0.05f);
        GameManager.gameManagerInstance.playerManaRegenRate = manaRegenRate;

        stamina = 10 + (endurance * 10);
        maxStamina = 10 + (endurance * 10);
        GameManager.gameManagerInstance.playerMaxStamina = maxStamina;

        staminaRegenRate = 2.0f + (endurance * 0.05f);
        GameManager.gameManagerInstance.playerStaminaRegenRate = staminaRegenRate;

        // movement
        moveSpeed = 0.75f + (endurance * 0.02f);
        GameManager.gameManagerInstance.playerMoveSpeed = moveSpeed;

        // resistances
        flatDamageReduction = GameManager.gameManagerInstance.playerFlatDamageReduction;
        physicalResistance = GameManager.gameManagerInstance.playerPhysicalResistance;
        aetherResistance = GameManager.gameManagerInstance.playerAetherResistance;
        timeResistance = GameManager.gameManagerInstance.playerTimeResistance;

        isMoving = false;
        target = transform.position;
    }

    // attributes setters
    private void SetConstitution(int nConstitution) {
        GameManager.gameManagerInstance.constitution = nConstitution;
        constitution = nConstitution;
        maxHitpoint = 100 + (constitution * 20);
        GameManager.gameManagerInstance.playerMaxHitpoint = maxHitpoint;
        hitpoint = maxHitpoint + 100 + (constitution * 20);
        healthRegenRate = 2.0f + (constitution * 0.10f);
        GameManager.gameManagerInstance.playerHealthRegenRate = healthRegenRate;
        // healthBar.UpdateContainerLength();
    }
    private void SetStrength(int nStrength) {
        GameManager.gameManagerInstance.strength = nStrength;
        strength = nStrength;
    }
    private void SetIntelligence(int nIntelligence) {
        GameManager.gameManagerInstance.intelligence = nIntelligence;
        intelligence = nIntelligence;
        mana = intelligence + 10 + (intelligence * 10);
        maxMana = intelligence + 10 + (intelligence * 10);
        GameManager.gameManagerInstance.playerMaxMana = maxMana;
        manaRegenRate = intelligence + 0.5f + (intelligence * 0.05f);
        GameManager.gameManagerInstance.playerManaRegenRate = manaRegenRate;
        // manaBar.UpdateContainerLength();
    }
    private void SetSpirituality(int nSpirituality) {
        GameManager.gameManagerInstance.spirituality = nSpirituality;
        spirituality = nSpirituality;
    }
    private void SetEndurance(int nEndurance) {
        GameManager.gameManagerInstance.endurance = nEndurance;
        endurance = nEndurance;
        stamina = endurance + 10 + (endurance * 10);
        maxStamina = endurance + 10 + (endurance * 10);
        GameManager.gameManagerInstance.playerMaxStamina = maxStamina;
        staminaRegenRate = endurance + 2.0f + (endurance * 0.05f);
        GameManager.gameManagerInstance.playerStaminaRegenRate = staminaRegenRate;
        moveSpeed = endurance + 0.75f + (endurance * 0.02f);
        GameManager.gameManagerInstance.playerMoveSpeed = moveSpeed;
        // staminaBar.UpdateContainerLength();
    }

    // stats setters
    private void SetLevel(int nLevel) {
        GameManager.gameManagerInstance.playerLevel = nLevel;
        level = nLevel;
    }
    private void SetGold(int nGold) {
        GameManager.gameManagerInstance.totalGold = nGold;
        totalGold = nGold;
    }
    private void SetMaxHitpoint(float nMaxHitpoint) {
        GameManager.gameManagerInstance.playerMaxHitpoint = nMaxHitpoint;
        maxHitpoint = nMaxHitpoint;
        // healthBar.UpdateContainerLength();
    }
    private void SetHealthRegenRate(float nHealthRegenRate) {
        GameManager.gameManagerInstance.playerHealthRegenRate = nHealthRegenRate;
        healthRegenRate = nHealthRegenRate;
    }
    private void SetMaxMana(float nMaxMana) {
        GameManager.gameManagerInstance.playerMaxMana = nMaxMana;
        maxMana = nMaxMana;
        // manaBar.UpdateContainerLength();
    }
    private void SetManaRegenRate(float nManaRegenRate) {
        GameManager.gameManagerInstance.playerManaRegenRate = nManaRegenRate;
        manaRegenRate = nManaRegenRate;
    }
    private void SetMaxStamina(float nMaxStamina) {
        GameManager.gameManagerInstance.playerMaxStamina = nMaxStamina;
        maxStamina = nMaxStamina;
        // staminaBar.UpdateContainerLength();
    }
    private void SetStaminaRegenRate(float nStaminaRegenRate) {
        GameManager.gameManagerInstance.playerStaminaRegenRate = nStaminaRegenRate;
        staminaRegenRate = nStaminaRegenRate;
    }
    private void SetMoveSpeed(float nMoveSpeed) {
        GameManager.gameManagerInstance.playerMoveSpeed = nMoveSpeed;
        moveSpeed = nMoveSpeed;
    }
    private void SetFlatDamageReduction(float nFlatDamageReduction) {
        GameManager.gameManagerInstance.playerFlatDamageReduction = nFlatDamageReduction;
        flatDamageReduction = nFlatDamageReduction;
    }
    private void SetPhysicalResistance(float nPhysicalResistance) {
        GameManager.gameManagerInstance.playerPhysicalResistance = nPhysicalResistance;
        physicalResistance = nPhysicalResistance;
    }
    private void SetAetherResistance(float nAetherResistance) {
        GameManager.gameManagerInstance.playerAetherResistance = nAetherResistance;
        aetherResistance = nAetherResistance;
    }
    private void SetTimeResistance(float nTimeResistance) {
        GameManager.gameManagerInstance.playerTimeResistance = nTimeResistance;
        timeResistance = nTimeResistance;
    }
}
