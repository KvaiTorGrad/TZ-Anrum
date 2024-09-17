using UnityEngine;
using UniRx;
public class CharacterHealthSystem : MonoBehaviour, ISpecifications
{
    [SerializeField] private StartSpecificationCharacter _specificationCharacter;
    [SerializeField] private ReactiveProperty<int> _hp = new();

    public int HP { get => _hp.Value; set => _hp.Value = value; }

    private void Awake()
    {
        HP = _specificationCharacter.MaxHp;
    }
    public void ApplyDamage(int damage)
    {
        HP = Mathf.Clamp(HP -= damage, 0, _specificationCharacter.MaxHp);
    }
}

public interface ISpecifications
{
    public int HP { get; set; }

    public void ApplyDamage(int damage);
}
