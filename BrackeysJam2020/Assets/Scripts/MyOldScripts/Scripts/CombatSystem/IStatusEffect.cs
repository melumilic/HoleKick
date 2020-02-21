using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffect
{
    string StatusName { get; set; }
    float duration { get; set; }
}
