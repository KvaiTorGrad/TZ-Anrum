using UnityEngine;

[CreateAssetMenu(fileName = "StartSpecificationCharacter", menuName = "Character/StartSpecification")]
public class StartSpecificationCharacter : ScriptableObject
{
    [SerializeField] private int _maxHp;
    public int MaxHp => _maxHp;
}
