using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
