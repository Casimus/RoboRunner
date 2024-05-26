
using UnityEngine;

[CreateAssetMenu (fileName = "Magnet", menuName = "Powerup/Magnet")]
public class Magnet : Powerup
{
    [SerializeField] private PowerupStats range;
    [SerializeField] private PowerupStats speed;

    public float GetRange() => range.GetValue();
    public float GetSpeed() => speed.GetValue();
}
