using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListValue : ScriptableObject
{
    public List<Vector2> positions = new List<Vector2>();
    public List<Vector2> Positions => positions;
}
