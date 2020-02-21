using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private string id;
    public string ItemName;
    public Sprite Icon;
    List<ItemAttribute> itemAttributes = new List<ItemAttribute>();
    public string ID { get { return id; } }
    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
}
