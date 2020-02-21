using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{ 
    [Header("Basic Info")]
    [SerializeField] private new string name = "New Status Effect Name";
    [SerializeField] private Sprite icon = null;

    public string Name => name;
    public Sprite Icon { get; }
    public abstract string GetInfoDisplayText();
}
