using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerupStat", menuName ="Powerup/Powerup Stats")]
public class PowerupStats : ScriptableObject
{
    [SerializeField] private float value;

    public float GetValue() => value;
}
