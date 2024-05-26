
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public bool isActive;

    [SerializeField] protected PowerupStats duration;

    public float GetDuration() => duration.GetValue();
}
