using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public CharacterStats characterStats;

    public Text specialization, description, stats;

    private void Start()
    {
        DisplayDetails();
    }
    public void DisplayDetails()
    {
        specialization.text = characterStats.chosenSpec.ToString();
        description.text = characterStats.classDescription;
        stats.text = "Dexterity: " + characterStats.dexterity;
    }
}
