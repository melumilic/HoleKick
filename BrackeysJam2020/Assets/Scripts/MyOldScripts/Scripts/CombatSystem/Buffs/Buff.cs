using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : StatusEffect
{
    [Header("Buff")]
    [Min(0f)] private float _duration = 1f;
    public float duration => _duration;
}
