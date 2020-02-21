using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "GameObjects/Keybindings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        public KeybindingActions keybindingActions;
        public KeyCode keyCode;
    }
    public KeybindingCheck[] keybindingChecks;











    /*
    [Header("Movement")]
    public KeyCode moveForward, moveLeft, moveRight, moveBack, jump;
    [Header("Combat")]
    public KeyCode hotbar1, hotbar2, hotbar3, hotbar4, hotbar5,
        heal, dodge, soulRelease;
    [Header("General")]
    public KeyCode interact, pause, inventory;

    public KeyCode CheckKey(string key)
    {
        
        switch (key)
        {
            ///////////////////////
            case "MoveForward":
                return moveForward;
            case "MoveLeft":
                return moveLeft;
            case "MoveRight":
                return moveRight;
            case "MoveBack":
                return moveBack;
            case "Jump":
                return jump;
            ///////////////////////
            case "Hotbar1":
                return hotbar1;
            case "Hotbar2":
                return hotbar2;
            case "Hotbar3":
                return hotbar3;
            case "Hotbar4":
                return hotbar4;
            case "Hotbar5":
                return hotbar5;
            case "Heal":
                return heal;
            case "Dodge":
                return dodge;
            case "SoulRelease":
                return soulRelease;
            ///////////////////////
            case "Interact":
                return interact;
            case "Pause":
                return pause;
            case "Inventory":
                return inventory;
            ///////////////////////
            default:
                return KeyCode.None;
            ///////////////////////
        }
        
    }*/
}
