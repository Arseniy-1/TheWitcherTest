using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHeadler;

    private bool _facingRight = true;

    private void FixedUpdate()
    {
        CorrectFlip();
    }

    private void CorrectFlip()
    {
        if (!_facingRight && _inputHeadler.HorizontalDirection > 0)
            Flip();
        else if (_facingRight && _inputHeadler.HorizontalDirection < 0)
            Flip();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
