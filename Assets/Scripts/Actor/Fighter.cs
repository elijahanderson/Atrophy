using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    // stats
    public int level;
    public float hitpoint;
    public float maxHitpoint;
    public float healthRegenRate;
    public float mana;
    public float maxMana;
    public float manaRegenRate;
    public float stamina;
    public float maxStamina;
    public float staminaRegenRate;
    public bool isDead;
    // resistances
    public float flatDamageReduction;
    public float physicalResistance;
    public float aetherResistance;
    public float timeResistance;

    protected virtual void Start() {

    }
}
