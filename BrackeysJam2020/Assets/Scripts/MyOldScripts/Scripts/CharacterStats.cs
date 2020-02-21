using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "GameObjects/Character")]
public class CharacterStats : ScriptableObject
{
    public enum ChosenSpec { none, rogue, warrior, mage }

    [Header("ClassDesc")]
    public string classDescription = "default";
    public ChosenSpec chosenSpec = ChosenSpec.none;

    [Header("Stats")]
    public int health = 100;
    public int currentHealth = 100;
    public int mana = 100;
    public int maxMana = 100;
    public int exp = 0;
    public float movementSpeed = 3f;
    public float jumpHeight = 8f;
    public float weight = 20f; // linked to falling in CharacterMovement Script
    [Header("Attributes")]
    public int strength = 10;
    public int dexterity = 10;
    public int vitality = 10;
    public int intelligence = 10;
    //[Header("Runtime Stats")]
    //public float currentMovementSpeed;
}
