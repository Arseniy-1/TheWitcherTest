using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private InputHandler _inputHandler;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float currentSpeed;

        if (_inputHandler.IsRunning)
        {
            currentSpeed = _runSpeed;
        }
        else
        {
            currentSpeed = _speed;
        }

        if (_inputHandler.HorizontalDirection == 0 && _inputHandler.VerticalDirection == 0)
            _animator.SetFloat("Speed", 0);
        else
            _animator.SetFloat("Speed", currentSpeed);

        float currentHorizontalSpeed = _inputHandler.HorizontalDirection * currentSpeed;
        float currentVerticalSpeed = _inputHandler.VerticalDirection * currentSpeed;

        _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
    }
}
