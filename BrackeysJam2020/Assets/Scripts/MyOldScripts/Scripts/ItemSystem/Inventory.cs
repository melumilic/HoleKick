using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "GameObject/Inventory")]
public class Inventory : ScriptableObject
{
    [Header("Inventory")]
    public List<Item> inventory = new List<Item>();

}
