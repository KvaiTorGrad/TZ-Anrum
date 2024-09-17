using UnityEngine;

public class SpecificationsCharacter : MonoBehaviour, ISpecifications
{
    [SerializeField] private int _maxHp;
    [SerializeField] private int _hp;
    public int HP { get => _hp; set => _hp = value; }

    private void Awake()
    {
        HP = _maxHp;
    }
    public void ApplyDamage(int damage)
    {
        HP = Mathf.Clamp(HP -= damage, 0, _maxHp);
    }
}

public interface ISpecifications
{
    public int HP { get; set; }

    public void ApplyDamage(int damage);
}
