using UnityEngine;

[CreateAssetMenu(fileName = "FallParametrs", menuName = "Fall/FallParametrs")]
public class FallParametrs : ScriptableObject
{
    [SerializeField] private float _minimumHeightForDamage;

    public float MinimumHeightForDamage => _minimumHeightForDamage;
}
