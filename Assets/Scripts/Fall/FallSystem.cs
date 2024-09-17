using Quantum;
using UnityEngine;

public class FallSystem : MonoBehaviour
{
    [SerializeField] private FallParametrs _fallParametrs;
    private float _startYPosition;
    private bool _isFalling;
    private EntityView _view;
    private CharacterController3D _characterController;
    private Frame _frame;
    private ISpecifications _specifications;
    private void Awake()
    {
        _view = GetComponent<EntityView>();
        _frame = QuantumRunner.Default.Game.Frames.Predicted;
        _specifications = GetComponent<ISpecifications>();
    }

    private void Update()
    {
        _characterController = _frame.Get<CharacterController3D>(_view.EntityRef);
        if (IsFalling())
        {
            _startYPosition = transform.position.y;
            _isFalling = true;
        }

        if (_characterController.Grounded && _isFalling)
        {
            float fallDistance = _startYPosition - transform.position.y;

            if (fallDistance > _fallParametrs.MinimumHeightForDamage)
                ApplyFallDamage(fallDistance);
            _isFalling = false;
        }
    }

    private bool IsFalling() => _characterController.Velocity.Y.AsFloat < 0 && !_characterController.Grounded;

    private void ApplyFallDamage(float fallDistance)
    {
        int damage = (int)(fallDistance * 10);
        _specifications.ApplyDamage(damage);
    }
}
