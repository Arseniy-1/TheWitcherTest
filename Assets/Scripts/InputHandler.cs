using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;
    
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private KeyCode _runButton = KeyCode.LeftShift;

    public float HorizontalDirection { get; private set; }
    public float VerticalDirection { get; private set; }

    public bool IsRunning { get; private set; } = false;

    private void Update()
    {
        VerticalDirection = Input.GetAxisRaw(Vertical);
        HorizontalDirection = Input.GetAxisRaw(Horizontal);

        if (_joystick.Direction != Vector2.zero)
        {
            VerticalDirection = _joystick.Vertical;
            HorizontalDirection = _joystick.Horizontal;
        }
        
        if (Input.GetKey(_runButton))
            IsRunning = true;
        else
            IsRunning = false;
    }
}
